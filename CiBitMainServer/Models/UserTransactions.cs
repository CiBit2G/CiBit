using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.Models
{
    public class UserTransactions
    {
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string TransactionDate { get; set; }
        public int Amount { get; set; }
        public int Fragment { get; set; }
        public string Status { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ResearchName { get; set; }
    }
}
