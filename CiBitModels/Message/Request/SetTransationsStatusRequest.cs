using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Request
{
    public class SetTransationsStatusRequest
    {
        public int BlockNumber { get; set; }
        public List<int> TransactionList { get; set; }
    }
}
