using CiBitUtil.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CiBitUtil.Message.Request
{
    public class CreateBankRequest : IValidatableObject
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string UniName { get; set; }

        [Required]
        [CiBitId]
        public string CiBitId { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [Password]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string VerifyPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var passRegex = new Regex(@"^[0-9a-zA-Z!@#$%^&*(){}?/*-+_=]{6,45}$");

            if (!passRegex.Match(Password).Success)
            {
                yield return new ValidationResult(
                    $"Password must start with and contain at least one (1) upper-case, one (1) lower-case and a number.",
                    new[] { nameof(Password) });
            }
            else if (Password != VerifyPassword)
            {
                yield return new ValidationResult(
                    $"Verify Password do not match password.",
                    new[] { nameof(VerifyPassword) });
            }
        }
    }
}
