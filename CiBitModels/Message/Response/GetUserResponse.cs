using CiBitUtil.Models;
using System.Collections.Generic;

namespace CiBitUtil.Message.Response
{
    public class GetUserResponse
    {
        public User user { get; set; }

        public List<GetUserTransactionResponse> TransactionList { get; set; }
    }
}
