using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Request
{
    public class SetHashRequest
    {

        public string BankId { get; set; }
        public int BlockchainNumber { get; set; }
        public string Hash { get; set; }
                
        //public List<int> approvedTransactions {get; set;}

    }
}
