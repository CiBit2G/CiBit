using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class TransactionDTO
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string SenderId { get; set; }

        public string ReciverId { get; set; }

        public int amount { get; set; }

        public List<CoinDTO> coins { get; set; }
    }
}
