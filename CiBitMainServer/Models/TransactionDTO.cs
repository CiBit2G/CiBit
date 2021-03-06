﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.Models
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ResearchId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public int BlockchainNumber { get; set; }
        public int Fragment { get; set; }
        public List<string> Coins { get; set; }
        public int Status { get; set; }
        public string BankId { get; set; }
        public int WithdrawalId { get; set; }

        public TransactionDTO()
        {
            Coins = new List<string>();
        }
    }
}
