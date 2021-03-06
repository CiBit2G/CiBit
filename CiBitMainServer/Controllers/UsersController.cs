﻿using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitMainServer.DBLogic;
using CiBitUtil.Validation;
using CiBitMainServer.Models;
using System;
using CiBitMainServer.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiBitMainServer.Controllers
{
    public class UsersController : Controller
    {
        private static readonly string pyFullPath = $"C:\\Users\\{Environment.UserName}\\OneDrive\\Documents\\GitHub\\CiBit\\PythonFiles\\Bot.py";

        public static CibitDb _context { get; set; }

        public UsersController(CibitDb context)
        {
            _context = context;
        }

        // GET: Users/GetUser/GetUserRequest
        [HttpPost]
        public GetUserResponse GetUser([FromBody]BaseWebRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest= new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(userRequest);

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
                    University = reader["university"].ToString(),
                    Picture = reader["Picture"].ToString(),
                    Balance =int.Parse( reader["balance"].ToString())
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
            int transactionLimit = 5;
            foreach (var item in transactionList)
            {
                if (item.Fragment == 0)
                {
                    if (transactionLimit == 0)
                        break;
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
                    transactionLimit--;
                }
                else
                    sum += item.Amount;  
            }

            return response;
        }

        // POST: Users/GetAllUsers/
        [HttpPost]
        public GetAllUsersResponse GetAllUsers([FromBody]BaseWebRequest request)
        {

            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest = new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var bankInfo = TypeMapper.Mapper.Map<GetUserRequest, BankDTO>(userRequest);
            var spObj = Converters.GetBankConverter(bankInfo);
            var reader = _context.StoredProcedureSql("newUsersPerBank", spObj);

            GetAllUsersResponse response = new GetAllUsersResponse();

            while (reader.Read())
            {
                response.Users.Add(new GetUserConfirmResponse()
                {

                    CiBitId = reader["cibitId"].ToString(),
                    FullName = reader["fName"].ToString() + " " + reader["lName"].ToString(),
                    Email = reader["email"].ToString(),
                    University = reader["university"].ToString(),
                    Status = reader["u_status"].ToString(),
                    Date = DateTime.Now  // Add created Date timr o user table 
                });
            }

            _context.Connection.Close();
            return response;
        }

        [HttpPost]
        public GetUserListResponse GetUserList([FromBody] BaseWebRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest = new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(userRequest);

            var spObj = Converters.GetUserConverter(userinfo);

            var reader = _context.StoredProcedureSql("GetAllOtherConfirmedUsers", spObj);

            GetUserListResponse response = new GetUserListResponse();

            while (reader.Read())
            {
                response.UserNamesList.Add(
                    reader["cibitId"].ToString(),
                    reader["fName"].ToString() + " " + reader["lName"].ToString()
                );
            }

            _context.Connection.Close();
            response.Token = Tokens.CreateToken(ciBitId);
            return response;
        }

        [HttpPost]
        public GetUserListResponse GetUserBank([FromBody] BaseWebRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest = new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(userRequest);

            var spObj = Converters.GetUserConverter(userinfo);

            var reader = _context.StoredProcedureSql("GetUserBank", spObj);

            GetUserListResponse response = new GetUserListResponse();

            while (reader.Read())
            {
                response.UserNamesList.Add(
                    reader["bankId"].ToString(),
                    reader["b_name"].ToString()
                );
            }

            _context.Connection.Close();
            response.Token = Tokens.CreateToken(ciBitId);
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
                var hash = new ValidateUser();

                var userinfo = TypeMapper.Mapper.Map<CreateUserRequest, UserDTO>(request);

                var spObj = Converters.VerifyUserConverter(userinfo);
                var reader = _context.StoredProcedureSql("GetUserByEmailAndUni", spObj);

                var id = string.Empty;

                while (reader.Read())
                {
                    id = reader["cibitId"].ToString();
                }

                if(!string.IsNullOrEmpty(id))
                    throw new Exception("User Exsits");

                _context.Connection.Close();

                userinfo.Password = hash.Hash(userinfo.Password); //hash Password

                do
                {
                    userinfo.CibitId = hash.CreateCibitId();
                } while (Tokens.IsUserExist(userinfo.CibitId)); // Verify CiBitId is unique.

                userinfo.ArticleName = userinfo.ArticleName.ToLower();
                
                spObj = Converters.CreateUserConverter(userinfo);
                reader = _context.StoredProcedureSql("CreateUser", spObj);
                _context.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public bool CreateBank([FromBody]CreateBankRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            try
            {
                var hash = new ValidateUser();

                var userinfo = TypeMapper.Mapper.Map<CreateBankRequest, BankDTO>(request);

                userinfo.Password = hash.Hash(userinfo.Password); //hash Password

                var spObj = Converters.CreateBankConverter(userinfo);
                var reader = _context.StoredProcedureSql("AddBank", spObj);

                _context.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public string GetCiBitId()
        {
            string cibitId;
            var hash = new ValidateUser();
            do
            {
                cibitId = hash.CreateCibitId();
            } while (Tokens.IsUserExist(cibitId)); // Verify CiBitId is unique.

            return cibitId;
        }

        [HttpGet]
        public GetBankNamesResponse GetBankName()
        {
            try
            {
                var reader = _context.StoredProcedureSql("getBanksNames", null);

                GetBankNamesResponse response = new GetBankNamesResponse();

                response.Universities = new List<string>();

                while (reader.Read())
                {
                    response.Universities.Add(reader["b_name"].ToString());
                }

                _context.Connection.Close();
                return response;
            }
            catch
            {
                return null;
            }
        }

        // DELETE: Users/RemoveUser/RemoveUserRequest
        [HttpPost]
        public bool RemoveUser([FromBody]RemoveUserRequest request)
        {
            var userinfo = TypeMapper.Mapper.Map<RemoveUserRequest, UserDTO>(request);

            var spObj = Converters.RemoveUserConverter(userinfo);
            var reader = _context.StoredProcedureSql("RemoveUser", spObj);

            _context.Connection.Close();
            return true;
        }

        [HttpPost]
        public GetLoginResponse Login([FromBody]LoginRequest request)
        {

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(request);

            var spObj = Converters.RemoveUserConverter(userinfo);
            var reader = _context.StoredProcedureSql("LoginInfo", spObj);

            var response = new GetLoginResponse();
            string pass = null;

            while (reader.Read())
            {
                pass = reader["pass"].ToString();
            }

            if(pass == null)
            {
                response.IsBank = true;

                _context.Connection.Close();
                reader = _context.StoredProcedureSql("BankLoginInfo", spObj);

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

            _context.Connection.Close();
            return response;
        }

        [HttpPost]

        public UserSettingsResponse ChangeSettings([FromBody]UserSettingsRequest request)
        {
            UserSettingsResponse response = new UserSettingsResponse();
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");
            try
            {
                var hash = new ValidateUser();
                var userinfo = TypeMapper.Mapper.Map<UserSettingsRequest, UserDTO>(request);
                userinfo.CibitId = ciBitId;
                userinfo.Password = hash.Hash(userinfo.Password); //hash Password
                
                var spObj = Converters.UserSettingsConverter(userinfo);
                var reader = _context.StoredProcedureSql("ChangeSettings", spObj);
                
                _context.Connection.Close();
                response.IsSuccessful = true;
                response.Token = Tokens.CreateToken(ciBitId);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.IsSuccessful = false;
                return response;
            }
        }

        [HttpPost]
        public ConfirmUserResponse ConfirmUser([FromBody] ConfirmUserRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userinfo = TypeMapper.Mapper.Map<ConfirmUserRequest, UserDTO>(request);

            var spObj = Converters.ConfirmUserConverter(userinfo);
            var reader = _context.StoredProcedureSql("ChangeUserStatus", spObj);

            _context.Connection.Close();
            var response = new ConfirmUserResponse();
            
            response.Token = Tokens.CreateToken(ciBitId);
            if(request.Status == 1)
            {
                var bot = new RunPythonBot();
                Task.Run(() => bot.RunPyCmd(pyFullPath, request.CibitId));
            }

            response.IsSuccessful = true;
            return response;
        }

        [HttpPost]
        public GetUserSettingsResponse GetUserSettings([FromBody] BaseWebRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            GetUserRequest userRequest = new GetUserRequest
            {
                Token = request.Token,
                CibitId = ciBitId
            };

            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(userRequest);

            var spObj = Converters.GetUserConverter(userinfo);

            var reader = _context.StoredProcedureSql("GetUserSettings", spObj);

            GetUserSettingsResponse response = new GetUserSettingsResponse();

            while (reader.Read())
            {
                response.University = reader["university"].ToString();
                response.Email = reader["email"].ToString();
            }

            _context.Connection.Close();
            response.Token = Tokens.CreateToken(ciBitId);
            return response;
        }

        [HttpGet]
        public string CibitGenrator()
        {
            var hash = new ValidateUser();
            return hash.CreateCibitId();
        } 
    }
}