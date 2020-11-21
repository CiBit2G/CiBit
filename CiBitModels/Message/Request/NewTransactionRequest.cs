using CiBitUtil.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CiBitUtil.Message.Request
{
    public class NewTransactionRequest : BaseWebRequest, IValidatableObject
    {
        [Required]
        [CiBitId]
        public string ReceiverId { get; set; }

        public string ResearchId { get; set; }

        [Required]
        public int Amount { get; set; }

        public float PartOfFull { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Amount <= 0)
                yield return new ValidationResult(
                    $"Amount must be a possitive interger.",
                    new[] { nameof(Amount) });
        }
    }
}
