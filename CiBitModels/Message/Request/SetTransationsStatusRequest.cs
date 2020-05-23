using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CiBitUtil.Message.Request
{
    public class SetTransationsStatusRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }
        public List<int> TransactionList;
        public int[] TransactionArr { set => TransactionList = value.ToList(); }
    }
}
