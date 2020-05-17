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
                    Fragment = int.Parse(reader["fragment"].ToString())
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
        public int CheckHash([FromBody]CheckHashRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<CheckHashRequest, TransactionDTO>(request);

            var spObj = Converters.CheckHashResponseConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("GetHash", spObj);

            CheckHashResponse response = null;
            while (reader.Read())
            {
                response = new CheckHashResponse()
                {
                    Hash = reader["proof"].ToString()
                };
            }
            _context.Connection.Close();

            if (response.Hash == "0")
                return 0;
            else if (response.Hash.CompareTo(request.Hash) == 0)
            {
                ///check if transaction are panding  - return 4
                return 1;
            }
            return -1;
        }

        public bool SetHash(SetHashRequest request)
        {
            var Transactioninfo = TypeMapper.Mapper.Map<SetHashRequest, TransactionDTO>(request);

            var spObj = Converters.CheckHashResponseConverter(Transactioninfo);

            var reader = _context.StoredProcedureSql("InsertHashFromBank", spObj);

            //check consensus

            var compare = CheckHash(new CheckHashRequest() { Hash = request.Hash });

            _context.Connection.Close();

            return compare == 0;
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
    }
}