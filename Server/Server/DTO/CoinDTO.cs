using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class CoinDTO
    {
        [Key]
        public string SenderCibitID { get; set; }
        [Required]
        public string SenderCoinID { get; set; }

        public string ReceiverCibitID { get; set; }

        public string ReceiverCoinID { get; set; }

        public int Status { get; set; }
    }
}
