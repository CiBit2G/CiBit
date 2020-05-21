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
using static CiBitMainServer.Models.EnumClass;

namespace CiBitMainServer.Controllers
{
    public class TransactionController : Controller
    {
        private readonly CibitDb _context;

        public TransactionController(CibitDb context)
        {
            _context = context;
        }

        //INSERT: Transaction/AddTransaction/CreateUserRequest
        public bool AddTransaction([FromBody]AddTransactionRequest request)
        {
            var verify = new ValidateUser();
            var userinfo = TypeMapper.Mapper.Map<AddTransactionRequest, TransactionDTO>(request);

            //TODO: verify CoinID with pythone API

            var spObj = Converters.AddTransactionConverter(userinfo);
            var reader = _context.StoredProcedureSql("AddTransaction", spObj);

            _context.Connection.Close();
            return true;
        }

        // DELETE: Transaction/RemoveCoin/RemoveCoinRequest
        public bool RemoveCoin([FromBody]RemoveCoinRequest request)
        {
            ValidateUser valid = new ValidateUser();

            var userinfo = TypeMapper.Mapper.Map<RemoveCoinRequest, TransactionDTO>(request);

            //verify CoinID with pythone API

            var spObj = Converters.RemoveCoinConverter(userinfo);
            var reader = _context.StoredProcedureSql("RemoveCoin", spObj);

            _context.Connection.Close();
            return true;
        }

        public GetTransactionReponse GetTransaction([FromBody]GetTransactionRequest request)
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
                    BlockchainNumber=request.BlockchainNumber
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

        //GET: Transaction/AddTransaction/BlockReady
        public BlockReadyResponse BlockReady()
        {
            var reader = _context.StoredProcedureSql("GetBlockReady", null);

            BlockReadyResponse response = null;
            while (reader.Read())
            {
                response = new BlockReadyResponse()
                {
                    BlockchainNumber = int.Parse(reader["lastBlock"].ToString()),
                    Hash = reader["blockHash"].ToString(),
                };
            }
            _context.Connection.Close();

            return response;
        }


        public BlockInfoResponse BlockInfo([FromBody] getBlockRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<getBlockRequest, TransactionDTO>(request);
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

        public ChechkHashType CheckHash([FromBody]CheckHashRequest request)
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
                Transactioninfo = new TransactionDTO { BlockchainNumber = Transactioninfo.BlockchainNumber };
                spObj = Converters.GetBlockConverter(Transactioninfo);
                reader = _context.StoredProcedureSql("TransactionStatus", spObj);
                int status = 0;
                while (reader.Read())
                {
                    status = int.Parse(reader["proof"].ToString());
                }
                if (status == 0)
                    return ChechkHashType.UpdateTransaction;
                return ChechkHashType.CorrectHash;

            }
            return ChechkHashType.Conflict;
        }

        public bool SetHash([FromBody]SetHashRequest request)
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
                        BankCount = int.Parse(reader["banks"].ToString())
                    });
                }
                _context.Connection.Close();
                var consensus = response.OrderByDescending(o => o.BankCount).FirstOrDefault();
                var totalBanks = response.Count;
                if ((response.Count >= 11) && (double)consensus.BankCount / (double)totalBanks > 0.8)
                {
                    Transactioninfo = new TransactionDTO() { Hash = consensus.Hash, BlockchainNumber = request.BlockchainNumber};
                    spObj = Converters.setHashConverter(Transactioninfo);
                    reader = _context.StoredProcedureSql("SetHash", spObj);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CoinExist([FromBody]GetCoinRequest request)
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

        public bool ConfirmCoins([FromBody]GetAllCoinsRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<GetAllCoinsRequest, TransactionDTO>(request);

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

        public GetTransactionListReponse CheckConsensus([FromBody]getBlockRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<getBlockRequest, TransactionDTO>(request);

            var spObj = Converters.GetCoinResponseConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("GetTransactionIdByBlockNumber", spObj);

            GetTransactionListReponse response = new GetTransactionListReponse
            {
                TransactionList = new List<int>()
            };

            while (reader.Read())
            {
                response.TransactionList.Add(int.Parse(reader["transactionId"].ToString()));
            }
            _context.Connection.Close();

            return response;
        }

        public bool SetTransaction([FromBody] SetTransationsStatusRequest request)
        {
            var Transactioninfo = new TransactionDTO { BlockchainNumber = request.BlockNumber };

            var spObj = Converters.GetCoinResponseConverter(Transactioninfo);

            try
            {
                var reader = _context.StoredProcedureSql("GetTransactionIdByBlockNumber", spObj);

                _context.Connection.Close();

                GetTransactionListReponse transactionList = new GetTransactionListReponse
                {
                    TransactionList = new List<int>()
                };

                while (reader.Read())
                {
                    transactionList.TransactionList.Add(int.Parse(reader["transactionId"].ToString()));
                }

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
    }
}