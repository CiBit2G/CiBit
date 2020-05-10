using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class RemoveCoinRequest
    {
        [Required]
        public string CoinId { get; set; }

        [Required]
        public string SenderId { get; set; }
    }
}
