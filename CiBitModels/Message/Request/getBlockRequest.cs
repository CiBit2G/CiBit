using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class getBlockRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }
    }
}
