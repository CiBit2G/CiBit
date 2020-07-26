using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class GetBlockRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }
    }
}
