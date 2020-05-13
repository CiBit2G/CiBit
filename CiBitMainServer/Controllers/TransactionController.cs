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
using CiBitMainServer.Mapping;

namespace CiBitMainServer.Controllers
{
    public class TransactionController : Controller
    {
        //INSERT: Transaction/AddTransaction/CreateUserRequest
        public bool AddTransaction([FromBody]AddTransactionRequest request)
        {
            var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            var verify = new ValidateUser();
            var userinfo = TypeMapper.Mapper.Map<AddTransactionRequest, TransactionDTO>(request);

            var reader = context.StoredProcedureSql("getBlock", null);// Get the leatest block and generate a new block if needed
            while (reader.Read())
            {
                userinfo.BlockchainNumber = int.Parse(reader["blockId"].ToString());
            }

            //TODO: verify CoinID with pythone API

            var spObj = Converters.AddTransactionConverter(userinfo);
            reader = context.StoredProcedureSql("AddTransaction", spObj);

            context.Connection.Close();
            return true;
        }

        // DELETE: Transaction/RemoveCoin/RemoveCoinRequest
        public bool RemoveCoin([FromBody]RemoveCoinRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            ValidateUser valid = new ValidateUser();

            var userinfo = TypeMapper.Mapper.Map<RemoveCoinRequest, TransactionDTO>(request);

            //verify CoinID with pythone API

            var spObj = Converters.RemoveCoinConverter(userinfo);
            var reader = context.StoredProcedureSql("RemoveCoin", spObj);

            context.Connection.Close();
            return true;
        }

        public GetTransactionReponse GetTransaction([FromBody]GetTransactionRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            
            var Transactioninfo = TypeMapper.Mapper.Map<GetTransactionRequest, TransactionDTO>(request);

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
                    Fragment = int.Parse(reader["fragment"].ToString())
                };
            }
            context.Connection.Close();
            response.transaction.Coins = new List<string>();
            Transactioninfo = TypeMapper.Mapper.Map< Transaction, TransactionDTO >(response.transaction);
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


        public BlockReadyResponse BlockInfo(getBlockRequest request)
        {

            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            var config = new MapperConfiguration(mc => mc.CreateMap<GetTransactionRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var Transactioninfo = mapper.Map<getBlockRequest, TransactionDTO>(request);
            var spObj = Converters.GetBlockConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("getBlockInfo", spObj);

            

            BlockReadyResponse response = null;
            while (reader.Read())
            {
                response = new BlockReadyResponse()
                {
                    TransactionId = int.Parse(reader["transactionId"].ToString()),
                    BlockchainNumber = int.Parse(reader["blockNumber"].ToString()),
                    Amount = int.Parse(reader["amount"].ToString()),
                };
            }
            context.Connection.Close();

            return response;
        }
        public GetHashResponse GetHash(GetHashRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var Transactioninfo = TypeMapper.Mapper.Map<GetHashRequest, TransactionDTO>(request);

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

            var Transactioninfo = TypeMapper.Mapper.Map<SetHashRequest, TransactionDTO>(request);

            var spObj = Converters.GetHashResponseConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("InsertHashFromBank", spObj);

            var compare = GetHash(new GetHashRequest() { BlockchainNumber = request.BlockchainNumber });

            context.Connection.Close();

            return request.Hash.Equals(compare.Hash);
        }

        public bool CoinExist([FromBody]GetCoinRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var Transactioninfo = TypeMapper.Mapper.Map<GetCoinRequest, TransactionDTO>(request);

            var spObj = Converters.GetCoinResponseConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("getCoin", spObj);

            string answer = null;
            while (reader.Read())
            {
                answer = reader["coinId"].ToString();
            }
            context.Connection.Close();
            if (answer != null)
                return true;
            return false;
        }

        public bool ConfirmCoins([FromBody]GetAllCoinsRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;

            var Transactioninfo = TypeMapper.Mapper.Map<GetAllCoinsRequest, TransactionDTO>(request);

            var spObj = Converters.GetCoinResponseConverter(Transactioninfo);

            var reader = context.StoredProcedureSql("getCoin", spObj);

            string answer = null;
            while (reader.Read())
            {
                answer = reader["coinId"].ToString();
            }
            context.Connection.Close();
            if (answer != null)
                return true;
            return false;
        }
    }
}