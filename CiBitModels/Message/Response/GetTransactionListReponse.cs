using System.Collections.Generic;

namespace CiBitUtil.Message.Response
{
    public class GetTransactionListReponse
    {
        public List<int> TransactionList { get; set; }

        public string Hash { get; set; }
    }
}
