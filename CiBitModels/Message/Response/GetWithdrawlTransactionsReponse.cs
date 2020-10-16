using CiBitUtil.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Message.Response
{
    public class GetWithdrawlTransactionsReponse
    {
        public List<Withdrawl> Withdrawls { get; set; }

        public GetWithdrawlTransactionsReponse()
        {
            Withdrawls = new List<Withdrawl>();
        }
    }
}
