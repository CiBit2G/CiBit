using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Response
{
    public class CheckConsensusResponse
    {
        public string Hash { get; set; }
        public int BankCount { get; set; }
    }
}
