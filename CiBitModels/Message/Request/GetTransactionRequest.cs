using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class GetTransactionRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int BlockchainNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TransactionId { get; set; }
    }
}
