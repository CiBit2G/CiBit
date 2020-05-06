using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitUtil.Validation;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using System;
using System.Linq;

namespace CiBitMainServer.Controllers
{
    public class TransactionController : Controller
    {
        // INSERT: Transaction/AddTransaction/CreateUserRequest
        public bool AddTransaction([FromBody]AddTransactionRequest request)
        {
            var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
            var verify = new ValidateUser();

            var config = new MapperConfiguration(mc => mc.CreateMap<AddTransactionRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<AddTransactionRequest, TransactionDTO>(request);

            if (!verify.VerifyCoinId(userinfo.CoinId, userinfo.SenderId))
                return false;

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

            var config = new MapperConfiguration(mc => mc.CreateMap<RemoveCoinRequest, TransactionDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<RemoveCoinRequest, TransactionDTO>(request);

            valid.VerifyCoinId(userinfo.CoinId, userinfo.SenderId);

            var spObj = Converters.RemoveCoinConverter(userinfo);
            var reader = context.StoredProcedureSql("RemoveCoin", spObj);

            context.Connection.Close();
            return true;
        }

        public TransactionDTO GetTransaction([FromBody]GetTransactionRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;
            int i=0;
            var config = new MapperConfiguration(mc => mc.CreateMap<GetUserRequest, UserDTO>());
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
                    Date = DateTime.Parse(reader["dateTime"].ToString()),
                    Amount = int.Parse(reader["coinAmount"].ToString()),
                    BlockchainNumber = int.Parse(reader["blockNumber"].ToString())
                };
            }

            GetCoinResponse cRespone = new GetCoinResponse();
            spObj = Converters.GetCoinsConverter(response.transaction.SenderId, response.transaction.Amount);
            reader = context.StoredProcedureSql("getCoins", spObj);
            while((reader.Read()))
            {
                cRespone.Coins.Add(new Coin()
                {
                    CoinId = reader["coinId"].ToString()
                });
                response.transaction.Coins.Add(cRespone.Coins.TakeLast(i);
                i ++;
            }
            context.Connection.Close();
            return response;
        }
    }
}