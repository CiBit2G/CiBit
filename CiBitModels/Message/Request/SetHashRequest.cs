using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class SetHashRequest
    {
        [Required]
        public string BankId { get; set; }
        public int BlockchainNumber { get; set; }
        public string Hash { get; set; }

        public string PreviousHash { get; set; }

        //public List<int> approvedTransactions {get; set;}

    }
}
