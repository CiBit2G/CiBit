using System;
using System.Collections.Generic;
using System.Text;
using CiBitUtil.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class GetCoinRequest: IValidatableObject
    {
        [Required]
        public string CoinId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CoinId) || CoinId.Length != 256)
            {
                yield return new ValidationResult(
                    $"Coin Id is Required and must be at exactly 256 charchters. Coin Id is: {CoinId?.Length}.",
                    new[] { nameof(CoinId) });
            }
        }

    }
}
