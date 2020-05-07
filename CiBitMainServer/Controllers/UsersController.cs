using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitMainServer.DBLogic;
using CiBitUtil.Validation;
using AutoMapper;
using CiBitMainServer.Models;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CiBitMainServer.Controllers
{
    public class UsersController : Controller
    {
        private static readonly string pyFullPath = $"C:\\Users\\{Environment.UserName}\\Documents\\GitHub\\CiBit\\PythonFiles\\Bot.py";
        // GET: Users/GetUser/GetUserRequest
        public GetUserResponse GetUser([FromBody]GetUserRequest request)
        {
            if (!ModelState.IsValid)
                throw new System.Exception(ModelState.ErrorCount.ToString());

            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;

            var config = new MapperConfiguration(mc => mc.CreateMap<GetUserRequest, UserDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<GetUserRequest, UserDTO>(request);

            var spObj = Converters.GetUserConverter(userinfo);

            var reader = context.StoredProcedureSql("getUser", spObj);

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

            context.Connection.Close();
            return response;
        }

        // GET: Users/GetAllUsers/
        public GetAllUsersResponse GetAllUsers()
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;

            var reader = context.StoredProcedureSql("getUsers", null);

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

            context.Connection.Close();
            return response;
        }

        // INSERT: Users/CreateUser/CreateUserRequest
        public bool CreateUser([FromBody]CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                throw new System.Exception(ModelState.ErrorCount.ToString());

            try
            {
                var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;
                var hash = new ValidateUser();

                var config = new MapperConfiguration(mc => mc.CreateMap<CreateUserRequest, UserDTO>());
                var mapper = new Mapper(config);
                var userinfo = mapper.Map<CreateUserRequest, UserDTO>(request);

                userinfo.Password = hash.Hash(userinfo.Password); //hash Password
                userinfo.CibitId = hash.CreateCibitId();
                userinfo.ArticleName = userinfo.ArticleName.ToLower();
                var spObj = Converters.CreateUserConverter(userinfo);
                var reader = context.StoredProcedureSql("CreateUser", spObj);

                var bot = new RunPythonBot();
                bot.run_cmd(pyFullPath, userinfo.CibitId);

                context.Connection.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        // DELETE: Users/CreateUser/CreateUserRequest
        public bool RemoveUser([FromBody]RemoveUserRequest request)
        {
            CibitDb context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;

            var config = new MapperConfiguration(mc => mc.CreateMap<RemoveUserRequest, UserDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<RemoveUserRequest, UserDTO>(request);

            var spObj = Converters.RemoveUserConverter(userinfo);
            var reader = context.StoredProcedureSql("RemoveUser", spObj);

            context.Connection.Close();
            return true;
        }
    }
}