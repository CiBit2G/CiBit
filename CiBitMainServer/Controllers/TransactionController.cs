﻿using AutoMapper;
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
using static CiBitMainServer.Models.EnumClass;
using System.Threading.Tasks;

namespace CiBitMainServer.Controllers
{
    public class TransactionController : Controller
    {
        private readonly CibitDb _context;

        private static readonly string pyFullPath = $"C:\\Users\\{Environment.UserName}\\OneDrive\\Documents\\GitHub\\CiBit\\PythonFiles\\TransactionGenrator.py";

        public TransactionController(CibitDb context)
        {
            _context = context;
        }

        //INSERT: Transaction/AddTransaction/CreateUserRequest
        public bool AddTransaction([FromBody] AddTransactionRequest request)
        {
            //var verify = new ValidateUser();
            var userinfo = TypeMapper.Mapper.Map<AddTransactionRequest, TransactionDTO>(request);

            //TODO: verify CoinID with pythone API

            var spObj = Converters.AddTransactionConverter(userinfo);
            var reader = _context.StoredProcedureSql("AddTransaction", spObj);
            reader.Close();
            _context.Connection.Close();
            return true;
        }

        // DELETE: Transaction/RemoveCoin/RemoveCoinRequest
        public bool RemoveCoin([FromBody] RemoveCoinRequest request)
        {
            //ValidateUser valid = new ValidateUser();

            var userinfo = TypeMapper.Mapper.Map<RemoveCoinRequest, TransactionDTO>(request);

            //verify CoinID with pythone API

            var spObj = Converters.RemoveCoinConverter(userinfo);
            var reader = _context.StoredProcedureSql("RemoveCoin", spObj);
            reader.Close();
            _context.Connection.Close();
            return true;
        }

        //Used in Blockchain
        public GetTransactionReponse GetTransaction([FromBody] GetTransactionRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<GetTransactionRequest, TransactionDTO>(request);

            var spObj = Converters.GetTransactionConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("getTransaction", spObj);

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
                    Fragment = int.Parse(reader["fragment"].ToString()),
                    BlockchainNumber = request.BlockchainNumber
                };
            }
            _context.Connection.Close();

            if (response.transaction == null)
                return null;

            response.transaction.Coins = new List<string>();
            Transactioninfo = TypeMapper.Mapper.Map<Transaction, TransactionDTO>(response.transaction);
            spObj = Converters.GetCoinsConverter(Transactioninfo);
            reader = _context.StoredProcedureSql("getTransactionCoins", spObj);
            while (reader.Read())
            {
                response.transaction.Coins.Add(reader["newCoinId"].ToString());
            }
            _context.Connection.Close();
            return response;
        }

        // POST: Transaction/GetWithdrawlTransactions/GetWithdrawlRequest
        public GetWithdrawlTransactionsReponse GetWithdrawlTransactions([FromBody] GetWithdrawlRequest request)
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

            var Transactioninfo = TypeMapper.Mapper.Map<GetUserRequest, BankDTO>(userRequest);

            var spObj = Converters.GetBankConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("getWithdrawlPerBank", spObj);

            GetWithdrawlTransactionsReponse response = new GetWithdrawlTransactionsReponse();

            while (reader.Read())
            {
                response.Withdrawls.Add(new Withdrawl()
                {
                    WithdrawalId = int.Parse(reader["id"].ToString()),
                    Date = DateTime.Parse(reader["createdDateTime"].ToString()),
                    SenderId = reader["senderId"].ToString(),
                    Amount = int.Parse(reader["amount"].ToString()),
                    Status = int.Parse(reader["w_status"].ToString()),
                    FullName = reader["fName"].ToString() + " " + reader["lName"].ToString(),
                });
            }

            if (response.Withdrawls == null)
                return null;

            _context.Connection.Close();
            return response;
        }

        //GET: Transaction/AddTransaction/BlockReady
        //Used in Blockchain
        public BlockReadyResponse BlockReady()
        {
            var reader = _context.StoredProcedureSql("GetBlockReady", null);

            BlockReadyResponse response = null;
            while (reader.Read())
            {
                response = new BlockReadyResponse()
                {
                    BlockchainNumber = int.Parse(reader["blockId"].ToString()),
                };
            }
            _context.Connection.Close();

            return response;
        }

        //Used in Blockchain
        public BlockInfoResponse BlockInfo([FromBody] GetBlockRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<GetBlockRequest, TransactionDTO>(request);
            var spObj = Converters.GetBlockConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("getBlockInfo", spObj);
            BlockInfoResponse response = null;
            if (reader.Depth == 0 && request.BlockchainNumber == 0)
                return response;
            while (reader.Read())
            {
                response = new BlockInfoResponse()
                {
                    TransactionId = int.Parse(reader["transactionId"].ToString()),
                    BlockchainNumber = int.Parse(reader["blockNumber"].ToString()),
                    Amount = int.Parse(reader["amount"].ToString()),
                };
            }
            _context.Connection.Close();

            return response;
        }

        //Used in Blockchain
        public ChechkHashType CheckHash([FromBody] CheckHashRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<CheckHashRequest, TransactionDTO>(request);

            var spObj = Converters.GetBlockConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("GetHash", spObj);

            GetHashResponse response = null;
            while (reader.Read())
            {
                response = new GetHashResponse()
                {
                    Hash = reader["proof"].ToString()
                };
            }
            _context.Connection.Close();

            if (response.Hash == "0")
                return ChechkHashType.NoConsensus;
            else if (response.Hash.CompareTo(request.Hash) == 0)
            {
                if (request.BlockchainNumber == 0)
                    return ChechkHashType.CorrectHash;

                Transactioninfo = new TransactionDTO { BlockchainNumber = Transactioninfo.BlockchainNumber };
                spObj = Converters.GetBlockConverter(Transactioninfo);
                reader = _context.StoredProcedureSql("TransactionStatus", spObj);
                int status = 0;
                while (reader.Read())
                {
                    status = int.Parse(reader["t_status"].ToString());
                }
                if (status == 0)
                    return ChechkHashType.UpdateTransaction;
                return ChechkHashType.CorrectHash;

            }
            return ChechkHashType.Conflict;
        }

        //Used in Blockchain
        public bool SetHash([FromBody] SetHashRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<SetHashRequest, TransactionDTO>(request);

            var spObj = Converters.HashfromBankResponseConverter(Transactioninfo);
            try
            {
                var reader = _context.StoredProcedureSql("InsertHashFromBank", spObj);
                _context.Connection.Close();

                Transactioninfo = new TransactionDTO()
                {
                    BlockchainNumber = Transactioninfo.BlockchainNumber
                };
                spObj = Converters.GetBlockConverter(Transactioninfo);
                reader = _context.StoredProcedureSql("CheckConsensus", spObj);

                List<CheckConsensusResponse> response = new List<CheckConsensusResponse>();
                while (reader.Read())
                {
                    response.Add(new CheckConsensusResponse()
                    {
                        Hash = reader["proof"].ToString(),
                        BankCount = int.Parse(reader["count"].ToString())
                    });
                }
                _context.Connection.Close();
                var consensus = response.OrderByDescending(o => o.BankCount).FirstOrDefault();
                var totalHashForBlock = response.Sum(c => c.BankCount);
                if ((totalHashForBlock >= 11) && (double)consensus.BankCount / (double)totalHashForBlock > 0.8)
                {
                    Transactioninfo = new TransactionDTO() { BlockchainNumber = request.BlockchainNumber, Hash = consensus.Hash, PreviousHash = request.PreviousHash };
                    spObj = Converters.setHashConverter(Transactioninfo);
                    reader = _context.StoredProcedureSql("SetHash", spObj);
                }
                _context.Connection.Close();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Used in Blockchain
        public bool CoinExist([FromBody] GetCoinRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<GetCoinRequest, TransactionDTO>(request);

            var spObj = Converters.GetCoinResponseConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("getCoin", spObj);

            string answer = null;
            while (reader.Read())
            {
                answer = reader["coinId"].ToString();
            }
            _context.Connection.Close();
            if (answer != null)
                return true;
            return false;
        }


        public GetTransactionListReponse CheckConsensus([FromBody] GetBlockRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<GetBlockRequest, TransactionDTO>(request);

            var spObj = Converters.GetBlockConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("GetTransactionIdByBlockNumber", spObj);

            GetTransactionListReponse response = new GetTransactionListReponse
            {
                TransactionList = new List<int>()

            };

            while (reader.Read())
            {
                response.TransactionList.Add(int.Parse(reader["transactionId"].ToString()));
                response.Hash = reader["proof"].ToString();
            }
            _context.Connection.Close();

            return response;
        }

        //Used in Blockchain
        public bool SetTransaction([FromBody] SetTransationsStatusRequest request)
        {
            var Transactioninfo = new TransactionDTO { BlockchainNumber = request.BlockchainNumber };

            var spObj = Converters.GetBlockConverter(Transactioninfo);

            try
            {
                var reader = _context.StoredProcedureSql("GetTransactionIdByBlockNumber", spObj);

                GetTransactionListReponse transactionList = new GetTransactionListReponse
                {
                    TransactionList = new List<int>()
                };

                while (reader.Read())
                {
                    transactionList.TransactionList.Add(int.Parse(reader["transactionId"].ToString()));
                }

                _context.Connection.Close();

                foreach (var transactionId in transactionList.TransactionList)
                {
                    if (request.TransactionList.Contains(transactionId))
                        Transactioninfo = new TransactionDTO { TransactionId = transactionId, Status = 1 };
                    else
                        Transactioninfo = new TransactionDTO { TransactionId = transactionId, Status = 2 };

                    spObj = Converters.SetTransactionStatus(Transactioninfo);

                    reader = _context.StoredProcedureSql("UpdateTransactionStatus", spObj);

                    _context.Connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public NewTransactionResponse NewTransaction([FromBody] NewTransactionRequest request)
        {
            //bool amountValid;

            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userinfo = TypeMapper.Mapper.Map<NewTransactionRequest, TransactionDTO>(request);
            userinfo.SenderId = ciBitId;
            var spObj = Converters.NewTransactionConverter(userinfo);
            var reader = _context.StoredProcedureSql("canUserPay", spObj);
            var response = new NewTransactionResponse();
            var userCoins = 0;

            while (reader.Read())
            {
                userCoins = int.Parse(reader["amount"].ToString());
            }
            _context.Connection.Close();

            if (userCoins < request.Amount)
            { 
                response.IsSuccessful = false;
                response.Token = Tokens.CreateToken(userinfo.SenderId);
                return response;
            }

            var bot = new RunPythonBot();
            response.Token = Tokens.CreateToken(userinfo.SenderId);
            Task.Run(() => bot.RunPyCmd(pyFullPath, ciBitId, request));
            response.IsSuccessful = true;
            return response;
        }

        public NewTransactionResponse NewWithdrawal([FromBody]NewTransactionRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userinfo = TypeMapper.Mapper.Map<NewTransactionRequest, TransactionDTO>(request);
            userinfo.SenderId = ciBitId;
            var spObj = Converters.NewTransactionConverter(userinfo);
            var reader = _context.StoredProcedureSql("canUserPay", spObj);
            var response = new NewTransactionResponse();
            var userCoins = 0;

            while (reader.Read())
            {
                userCoins = int.Parse(reader["amount"].ToString());
            }
            _context.Connection.Close();

            if (userCoins < request.Amount)
            {
                response.IsSuccessful = false;
                response.Token = Tokens.CreateToken(userinfo.SenderId);
                return response;
            }
            spObj = Converters.NewWithdrawalConverter(userinfo);
            reader = _context.StoredProcedureSql("AddWithdrawal", spObj);
            _context.Connection.Close();

            response.IsSuccessful = true;
            response.Token = Tokens.CreateToken(userinfo.SenderId);
            return response;

        }

        public ConfirmWithdrawalResponse ConfirmWithdrawal([FromBody] ConfirmWithdrawalRequest request)
        {
            if (!ModelState.IsValid)
                throw new Exception(ModelState.ErrorCount.ToString());

            if (!Tokens.VerifyToken(request.Token, out string ciBitId))
                throw new Exception("Invalid Token, Or Token had expiered.");

            var userinfo = TypeMapper.Mapper.Map<ConfirmWithdrawalRequest, TransactionDTO>(request);
            userinfo.ReceiverId = ciBitId;

            var spObj = Converters.ConfirmWithdrawalConverter(userinfo);
            var reader = _context.StoredProcedureSql("ChangeWithdrawalStatus", spObj);

            _context.Connection.Close();
            if(request.Status == 1)
            {
                NewTransactionRequest newRequest = new NewTransactionRequest();
                newRequest.ReceiverId = ciBitId;
                newRequest.Amount = request.Amount;
                newRequest.ResearchId = "0";
                var bot = new RunPythonBot();
                Task.Run(() => bot.RunPyCmd(pyFullPath, request.SenderId, newRequest));
            }
            var response = new ConfirmWithdrawalResponse();

            response.Token = Tokens.CreateToken(ciBitId);

            response.IsSuccessful = true;
            return response;
        }
    }
}