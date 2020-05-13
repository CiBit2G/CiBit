using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CiBitUtil.Message.Request
{
    public class getBlockRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }
    }
}
