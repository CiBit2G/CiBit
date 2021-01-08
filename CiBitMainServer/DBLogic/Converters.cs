using System.Collections.Generic;
using System.Linq;
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
        private const string picture = "pic";
        private const string status = "stat";
        #endregion

        #region Transaction

        private const string senderId = "sender_id";
        private const string receiverId = "receiver_id";
        private const string researchId = "research_id";
        private const string amount = "amount";
        private const string blockchainNumber = "bcNumber";
        private const string coinId = "coin_id";
        private const string TransactionId = "t_id";
        private const string Fragment = "Fragment";
        private const string lastBlock = "lastBlock";
        private const string proof = "proof";
        private const string newStatus = "newStatus";
        private const string firstTransactionOnBlock = "firstTransactionOnBlock";
        private const string Hash = "blockHash";
        private const string Bank = "bank_Id";
        private const string PreviousHash = "lastHash";
        private const string WithdrawalId = "w_id";


        #endregion

        #region Research

        private const string researchName = "r_name";
        private const string info = "info";

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
                Name = receiverId,
                value = request.ReceiverId,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = amount,
                value = request.Amount.ToString(),
                ParamType = MySqlDbType.Int32
            },
            new SpObject
            {
                Name = Fragment,
                value = request.Fragment.ToString(),
                ParamType = MySqlDbType.Int32
            }
            };
        }
        
        public static List<SpObject> NewTransactionConverter(TransactionDTO request)
        {
            return new List<SpObject> {
                new SpObject
                {
                    Name = cibitId,
                    value = request.SenderId,
                    ParamType = MySqlDbType.VarChar
                }
            };
        }
        
        internal static List<SpObject> RemoveCoinConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = coinId,
                    value = request.Coins.First(),
                    ParamType = MySqlDbType.VarChar
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
            },
            new SpObject
            {
                Name = info,
                value = request.Abstract,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> ConfirmResearchConverter(ResearchDTO request)
        {
            return new List<SpObject> {
            
            new SpObject
            {
                Name = cibitId,
                value = request.CiBitId,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = status,
                value = request.Status.ToString(),
                ParamType = MySqlDbType.Int32
            },
             new SpObject
            {
                Name = researchName,
                value = request.ResearchName,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> CreateBankConverter(BankDTO request)
        {
            return new List<SpObject> {
             new SpObject
            {
                Name = cibitId,
                value = request.CiBitId,
                ParamType = MySqlDbType.VarChar
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
                value = request.UniName,
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

        public static List<SpObject> GetBankConverter(BankDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
            {
                Name = cibitId,
                value = request.CiBitId,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> RemoveUserConverter(UserDTO request)
        {
            return GetUserConverter(request);
        }

        public static List<SpObject> GetTransactionConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = TransactionId,
                    value = request.TransactionId.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                new SpObject
                {
                    Name = blockchainNumber,
                    value = request.BlockchainNumber.ToString(),
                    ParamType = MySqlDbType.Int32
                }
            };
        }

        public static List<SpObject> GetCoinsConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = TransactionId,
                    value = request.TransactionId.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                new SpObject
                {
                    Name = senderId,
                    value = request.SenderId,
                    ParamType = MySqlDbType.VarChar
                },
                new SpObject
                {
                    Name = receiverId,
                    value = request.ReceiverId,
                    ParamType = MySqlDbType.VarChar
                }
            };
        }

        public static List<SpObject> GetCoinResponseConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = coinId,
                    value = request.Coins.FirstOrDefault(),
                    ParamType = MySqlDbType.VarChar
                }
            };
        }

        public static List<SpObject> SetTransactionStatus(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = TransactionId,
                    value = request.TransactionId.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                new SpObject
                {
                    Name = newStatus,
                    value = request.Status.ToString(),
                    ParamType = MySqlDbType.Int32
                }
            };
        }

        public static List<SpObject> GetAllCoinResponseConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = coinId,
                    value = request.Coins.FirstOrDefault(),
                    ParamType = MySqlDbType.VarChar
                }
            };
        }

        public static List<SpObject> GetBlockConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = blockchainNumber,
                    value = request.BlockchainNumber.ToString(),
                    ParamType = MySqlDbType.Int32
                }
            };
        }

        public static List<SpObject>  setHashConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = blockchainNumber,
                    value = request.BlockchainNumber.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                new SpObject
                {
                    Name = Hash,
                    value = request.Hash,
                    ParamType = MySqlDbType.VarChar
                },
                 new SpObject
                {
                    Name = PreviousHash,
                    value = request.PreviousHash,
                    ParamType = MySqlDbType.VarChar
                }
            };
        }

        public static List<SpObject> HashfromBankResponseConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = Bank,
                    value = request.BankId,
                    ParamType = MySqlDbType.VarChar
                },

                new SpObject
                {
                    Name = blockchainNumber,
                    value = request.BlockchainNumber.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                
                new SpObject
                {
                    Name = Hash,
                    value = request.Hash,
                    ParamType = MySqlDbType.VarChar
                }  
            };
        }

        public static List<SpObject> NewWithdrawalConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = cibitId,
                    value = request.SenderId,
                    ParamType = MySqlDbType.VarChar
                },
                new SpObject
                {
                    Name = Bank,
                    value = request.ReceiverId,
                    ParamType = MySqlDbType.VarChar
                },
                new SpObject
                {
                    Name = amount,
                    value = request.Amount.ToString(),
                    ParamType = MySqlDbType.Int32
                }
            };
        }
        public static List<SpObject> ConfirmWithdrawalConverter(TransactionDTO request)
        {
            return new List<SpObject>
            {
                new SpObject
                {
                    Name = WithdrawalId,
                    value = request.WithdrawalId.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                 new SpObject
                {
                    Name = cibitId,
                    value = request.SenderId,
                    ParamType = MySqlDbType.VarChar
                },
                  new SpObject
                {
                    Name = status,
                    value = request.Status.ToString(),
                    ParamType = MySqlDbType.Int32
                },
                new SpObject
                {
                    Name = Bank,
                    value = request.ReceiverId,
                    ParamType = MySqlDbType.VarChar
                }
               
            };
        }
        public static List<SpObject> UserSettingsConverter(UserDTO request)
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
                Name = email,
                value = request.Email,
                ParamType = MySqlDbType.VarChar
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
                Name = picture,
                value = request.Picture,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        public static List<SpObject> ConfirmUserConverter(UserDTO request)
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
                Name = status,
                value = request.Status.ToString(),
                ParamType = MySqlDbType.Int32
            },
            };
        }

        public static List<SpObject> VerifyUserConverter(UserDTO request)
        {
            return new List<SpObject> {
            new SpObject
            {
                Name = email,
                value = request.Email,
                ParamType = MySqlDbType.VarChar
            },
            new SpObject
            {
                Name = university,
                value = request.University,
                ParamType = MySqlDbType.VarChar
            }
            };
        }

        #endregion
    }
}