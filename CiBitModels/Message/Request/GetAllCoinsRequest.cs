using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CiBitUtil.Attributes;

namespace CiBitUtil.Message.Request
{
    public class GetAllCoinsRequest
    {
        [Required]
        [CiBitId]
        public string senderId { get; set; }

        [Required]
        public int TransactionId { get; set; }
        
        [Required]
        public List<string> coins { get; set; }

       
    }
}
