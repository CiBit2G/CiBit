using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Request
{
    public class GetTransactionRequest
    {
        public int TransactionId { get; set; }

        public int BlockchainNumber { get; set; }
    }
}
