using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class CheckHashRequest
    {
        [Required]
        public int BlockchainNumber { get; set; }

        public string Hash { get; set; }

    }
}
