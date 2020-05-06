using CiBitUtil.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CiBitUtil.Message.Request
{
    public class AddUserRequest : IValidatableObject
    {
        [Required]
        [StringLength(maximumLength: 45, MinimumLength =2)]
        public string FName { get; set; }

        [Required]
        [StringLength(maximumLength: 45, MinimumLength = 2)]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        [Password]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string VerifyPassword { get; set; }

        [Required]
        public string University { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var passRegex = new Regex(@"^[0-9a-zA-Z][^ \S\t\n\r]{5,44}$");

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
