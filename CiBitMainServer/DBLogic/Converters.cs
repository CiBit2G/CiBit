using System.Collections.Generic;
using CiBitMainServer.Models;
using MySql.Data.MySqlClient;

namespace CiBitMainServer.DBLogic
{
    public static class Converters
    {
        #region Fields

        #region User
        
        private const string cibitId = "c_id";
        private const string fName = "fname";
        private const string lName = "lname";
        private const string email = "Email";
        private const string dob = "dob";
        private const string password = "password1";
        private const string university = "uni";
        private const string articleName = "a_name";
        private const string citationCount = "amount";
        #endregion

        #region Transaction

        private const string senderId = "sender_id";
        private const string receiverId = "receiver_id";
        private const string researchId = "research_id";
        private const string date = "date_time";
        private const string amount = "amount";
        private const string blockchainNumber = "bcNumber";
        private const string coinId = "coin_id";

        #endregion

        #region Research

        private const string researchName = "r_name";

        #endregion

        #endregion

        #region Methods

        public static List<SpObject> AddTransactionConverter(TransactionDTO request)
        {
            return new List<SpObject> {
            new SpObject
            {
                Name = senderId,
                value = request.SenderId,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = senderId,
                value = request.ReceiverId,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = senderId,
                value = request.Date.ToString(),
                ParamType = MySqlDbType.DateTime
            },
            new SpObject
            {
                Name = amount,
                value = request.Amount.ToString(),
                ParamType = MySqlDbType.Int32
            },
            new SpObject
            {
                Name = senderId,
                value = request.BlockchainNumber.ToString(),
                ParamType = MySqlDbType.Int32
            }
            };
        }

        public static List<SpObject> CreateUserConverter(UserDTO request)
        {
            return new List<SpObject> {
            new SpObject
            {
                Name = cibitId,
                value = request.CibitId,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = fName,
                value = request.FName,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = lName,
                value = request.LName,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = email,
                value = request.Email,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = dob,
                value = request.DOB.ToString("yyyy-MM-dd"),
                ParamType = MySqlDbType.Date
            },
            new SpObject
            {
                Name = password,
                value = request.Password,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = university,
                value = request.University,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = articleName,
                value = request.ArticleName,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = amount,
                value = request.CitationCount.ToString(),
                ParamType = MySqlDbType.Int32
            }
            };
        }

        public static List<SpObject> CreateResearchConverter(ResearchDTO request)
        {
            return new List<SpObject> {
             new SpObject
            {
                Name = researchName,
                value = request.ResearchName,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = cibitId,
                value = request.CiBitId,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> GetUserConverter(UserDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
            {
                Name = cibitId,
                value = request.CibitId,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> RemoveCoinConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
            {
                Name = coinId,
                value = request.CoinId,
                ParamType = MySqlDbType.VarChar
                }
            };
        }

        public static List<SpObject> RemoveUserConverter(UserDTO request)
        {
            return GetUserConverter(request);
        }
    }

    #endregion
}