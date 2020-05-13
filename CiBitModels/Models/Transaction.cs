using System;
using System.Collections.Generic;
using System.Text;

namespace CiBitUtil.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ResearchId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int BlockchainNumber { get; set; }
        public int Fragment { get; set; }

        public List<string> Coins { get; set; }
    }
}
