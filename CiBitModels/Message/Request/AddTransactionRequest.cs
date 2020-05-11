using CiBitUtil.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class AddTransactionRequest: IValidatableObject
    {
        [Required]
        [CiBitId]
        public string SenderId { get; set; }

        [Required]
        [CiBitId]
        public string ReceiverId { get; set; }

        [Required]
        public string ResearchId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public float PartOfFull { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Amount <= 0)
                yield return new ValidationResult(
                    $"Amount must be a possitive interger.",
                    new[] { nameof(Amount) });
            if (SenderId == ReceiverId)
                yield return new ValidationResult(
                    $"Reciver must be different from sender.",
                    new[] { nameof(ReceiverId) });
        }
    }
}
