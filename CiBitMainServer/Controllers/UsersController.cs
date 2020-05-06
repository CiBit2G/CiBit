using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitMainServer.DBLogic;
using CiBitUtil.Validation;
using AutoMapper;
using CiBitMainServer.Models;

namespace CiBitMainServer.Controllers
{
    public class UsersController : Controller
    {

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
            var context = HttpContext.RequestServices.GetService(typeof(CibitDb)) as CibitDb; ;
            var hash = new ValidateUser();

            //test
            if (string.IsNullOrEmpty(request.FName ))
                request = new CreateUserRequest
                {
                    FName = "Nadav",
                    LName = "Voloch",
                    DOB = System.DateTime.Now,
                    Email = "a@b.com",
                    Password = "testPassword",
                    VerifyPassword = "testPassword",
                    ArticleName = "An Access Control model for data security in Online Social Networks based on role and user credibility",
                    CitationCount = 0,
                    University = "Ben-Gurion University"
                };

            var config = new MapperConfiguration(mc => mc.CreateMap<CreateUserRequest, UserDTO>());
            var mapper = new Mapper(config);
            var userinfo = mapper.Map<CreateUserRequest, UserDTO>(request);

            userinfo.Password = hash.Hash(userinfo.Password); //hash Password
            userinfo.CibitId = hash.CreateCibitId();
            userinfo.ArticleName = userinfo.ArticleName.ToLower();
            var spObj = Converters.CreateUserConverter(userinfo);
            var reader = context.StoredProcedureSql("CreateUser", spObj);

            IPythonAPI py = new PythonAPI();
            string message;
            string response = py.CSharpPythonRestfulApiSimpleTest("https://localhost:44357/api/v1.0/newUser", userinfo.CibitId,out message);
            
            context.Connection.Close();
            if (response == "OK")
                return true;
            else
                return false;
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