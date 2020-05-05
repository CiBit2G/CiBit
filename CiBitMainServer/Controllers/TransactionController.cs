using AutoMapper;
using CiBitMainServer.DBLogic;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Validation;
using Microsoft.AspNetCore.Mvc;

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
    }
}