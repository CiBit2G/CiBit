using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitUtil.Validation;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiBitMainServer.Controllers
{
    public class TransactionController : Controller
    {
        //INSERT: Transaction/AddTransaction/CreateUserRequest
        public bool AddTransaction([FromBody]AddTransactionRequest request)
        {
            var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            var verify = new ValidateUser();

            var config = new MapperConfiguration(mc => mc.CreateMap<AddTransactionRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<AddTransactionRequest, TransactionDTO>(request);

            //verify CoinID with pythone API

            var spObj = Converters.AddTransactionConverter(userinfo);
            var reader = context.StoredProcedureSql("AddTransaction", spObj);

            context.Connection.Close();
            return true;
        }

        // DELETE: Transaction/RemoveCoin/RemoveCoinRequest
        public bool RemoveCoin([FromBody]RemoveCoinRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            ValidateUser valid = new ValidateUser();

            var config = new MapperConfiguration(mc => mc.CreateMap<RemoveCoinRequest, TransactionDTO>().ForMember(dest => dest.Coins,
                m => m.MapFrom(src => src.CoinId.ToList())));
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<RemoveCoinRequest, TransactionDTO>(request);

            //verify CoinID with pythone API

            var spObj = Converters.RemoveCoinConverter(userinfo);
            var reader = context.StoredProcedureSql("RemoveCoin", spObj);

            context.Connection.Close();
            return true;
        }

        public GetTransactionReponse GetTransaction([FromBody]GetTransactionRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            var config = new MapperConfiguration(mc => mc.CreateMap<GetTransactionRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var Transactioninfo = mapper.Map<GetTransactionRequest, TransactionDTO>(request);

            var spObj = Converters.GetTransactionConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("getTransaction", spObj);

            GetTransactionReponse response = new GetTransactionReponse();

            while (reader.Read())
            {
                response.transaction = new Transaction()
                {
                    TransactionId = int.Parse(reader["transactionId"].ToString()),
                    SenderId = reader["cibitSender"].ToString(),
                    ReceiverId = reader["cibitReceiver"].ToString(),
                    ResearchId = reader["researchId"].ToString(),
                    Date = DateTime.Parse(reader["transactionDate"].ToString()),
                    Amount = int.Parse(reader["coinAmount"].ToString()),
                };
            }
            context.Connection.Close();
            response.transaction.Coins = new List<string>();
            config = new MapperConfiguration(mc => mc.CreateMap<Transaction, TransactionDTO>());
            mapper = new Mapper(config);
            Transactioninfo = mapper.Map< Transaction, TransactionDTO >(response.transaction);
            spObj = Converters.GetCoinsConverter(Transactioninfo);
            reader = context.StoredProcedureSql("getTransactionCoins", spObj);
            while (reader.Read())
            {
                response.transaction.Coins.Add(reader["newCoinId"].ToString());
            }
            context.Connection.Close();
            return response;
        }

        //GET: Transaction/AddTransaction/BlockReady
        public BlockReadyResponse BlockReady()
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var reader = context.StoredProcedureSql("GetBlockReady", null);

            BlockReadyResponse response = null;
            while (reader.Read())
            {
                response = new BlockReadyResponse()
                {
                    TransactionId = int.Parse(reader["firstTransactionOnBlock"].ToString()),
                    BlockchainNumber = int.Parse(reader["lastBlock"].ToString()),
                    Amount = int.Parse(reader["amount"].ToString()),
                };
            }
            context.Connection.Close();

            return response;
        }

        public GetHashResponse GetHash(GetHashRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var config = new MapperConfiguration(mc => mc.CreateMap<GetHashRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var Transactioninfo = mapper.Map<GetHashRequest, TransactionDTO>(request);

            var spObj = Converters.GetHashResponseConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("GetHash", spObj);

            GetHashResponse response = null;
            while (reader.Read())
            {
                response = new GetHashResponse()
                {
                    Hash = reader["proof"].ToString()
                };
            }
            context.Connection.Close();

            return response;
        }

        public bool SetHash(SetHashRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var config = new MapperConfiguration(mc => mc.CreateMap<SetHashRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var Transactioninfo = mapper.Map<SetHashRequest, TransactionDTO>(request);

            var spObj = Converters.GetHashResponseConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("InsertHashFromBank", spObj);

            var compare = GetHash(new GetHashRequest() { BlockchainNumber = request.BlockchainNumber });

            context.Connection.Close();

            return request.Hash.Equals(compare.Hash);
        }
    }
}