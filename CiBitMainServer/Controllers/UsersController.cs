using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitMainServer.DBLogic;
using CiBitUtil.Validation;
using CiBitMainServer.Models;
using System;
using CiBitMainServer.Mapping;
using System.Collections.Generic;

namespace CiBitMainServer.Controllers
{
    public class UsersController : Controller
    {
        private static readonly string pyFullPath = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\CiBit\\PythonFiles\\Bot.py";

        public static CibitDb _context { get; set; }

        public UsersController(CibitDb context)
        {
            _context = context;
        }

        // GET: Users/GetUser/GetUserRequest
        public GetUserResponse GetUser([FromBody]GetUserRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if(!(new Tokens().VerifyToken(request.Token)))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(request);

            var spObj = Converters.GetUserConverter(userinfo);

            var reader = _context.StoredProcedureSql("getUser", spObj);

            GetUserResponse response = new GetUserResponse();

            while (reader.Read())
            {
                response.user = new User()
                {
                    CibitId = reader["cibitId"].ToString(),
                    FName = reader["fName"].ToString(),
                    LName = reader["lName"].ToString(),
                    Email = reader["email"].ToString(),
                    University = reader["university"].ToString()
                };
            }

            _context.Connection.Close();

            reader = _context.StoredProcedureSql("getUserTransactions", spObj);

            var transactionList = new List<UserTransactions>();

            while (reader.Read())
            {
                transactionList.Add(new UserTransactions()
                {
                    Receiver = reader["cibitReceiver"].ToString(),
                    Sender = reader["cibitSender"].ToString(),
                    TransactionDate = Convert.ToDateTime(reader["transactionDate"]).ToString("dd/MM/yyyy"),
                    Amount = int.Parse(reader["coinAmount"].ToString()),
                    Fragment = int.Parse(reader["fragment"].ToString()),
                    Status = reader["s_description"].ToString(),
                    FName = reader["fName"].ToString(),
                    LName = reader["lName"].ToString(),
                    ResearchName = reader["researchName"].ToString()
                });
            }

            response.TransactionList = new List<GetUserTransactionResponse>();

            int sum = 0;

            foreach (var item in transactionList)
            {
                if (item.Fragment == 0)
                {
                    response.TransactionList.Add(new GetUserTransactionResponse
                    {
                        Date = item.TransactionDate,
                        Amount = item.Amount + sum,
                        isReceiver = item.Receiver == response.user.CibitId,
                        Receiver = item.FName + " " + item.LName,
                        Research = item.ResearchName,
                        Status = item.Status
                    });
                    sum = 0;
                }
                else
                    sum += item.Amount;
            }

            return response;
        }

        // GET: Users/GetAllUsers/
        public GetAllUsersResponse GetAllUsers()
        {
            var reader = _context.StoredProcedureSql("getUsers", null);

            GetAllUsersResponse response = new GetAllUsersResponse();

            while (reader.Read())
            {
                response.Users.Add(new User()
                {
                    CibitId = reader["cibitId"].ToString(),
                    FName = reader["fName"].ToString(),
                    LName = reader["lName"].ToString(),
                    Email = reader["email"].ToString(),
                    University = reader["university"].ToString(),
                    CitationAmount = (int.TryParse(reader["citationAmount"].ToString(),out int number)) ? number : 0
                });
            }

            _context.Connection.Close();
            return response;
        }

        // POST: Users/CreateUser/CreateUserRequest
        [HttpPost]
        public bool CreateUser([FromBody]CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            try
            {
                var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb;
                var hash = new ValidateUser();

                var userinfo = TypeMapper.Mapper.Map<CreateUserRequest, UserDTO>(request);

                userinfo.Password = hash.Hash(userinfo.Password); //hash Password
                userinfo.CibitId = hash.CreateCibitId();
                userinfo.ArticleName = userinfo.ArticleName.ToLower();
                var spObj = Converters.CreateUserConverter(userinfo);
                var reader = context.StoredProcedureSql("CreateUser", spObj);

                //var bot = new RunPythonBot();
                //bot.run_cmd(pyFullPath, userinfo.CibitId);

                context.Connection.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        // DELETE: Users/RemoveUser/RemoveUserRequest
        [HttpPost]
        public bool RemoveUser([FromBody]RemoveUserRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;

            var userinfo = TypeMapper.Mapper.Map<RemoveUserRequest, UserDTO>(request);

            var spObj = Converters.RemoveUserConverter(userinfo);
            var reader = context.StoredProcedureSql("RemoveUser", spObj);

            context.Connection.Close();
            return true;
        }

        [HttpPost]
        public GetLoginResponse Login([FromBody]LoginRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(request);

            var spObj = Converters.RemoveUserConverter(userinfo);
            var reader = context.StoredProcedureSql("LoginInfo", spObj);

            var response = new GetLoginResponse();
            string pass = null;

            while (reader.Read())
            {
                pass = reader["pass"].ToString();
            }

            if(pass == null)
            {
                response.IsBank = true;

                context.Connection.Close();
                reader = context.StoredProcedureSql("BankLoginInfo", spObj);

                while (reader.Read())
                {
                    pass = reader["password"].ToString();
                }
            }

            if (pass == null)
                return response;

            var isPass = new ValidateUser().Verify(pass, request.Password);

            if (isPass)
                response.Token = Tokens.CreateToken(request.CibitId);

            context.Connection.Close();
            return response;
        }
    }
}