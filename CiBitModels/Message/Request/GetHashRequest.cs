using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class GetHashRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }

    }
}
