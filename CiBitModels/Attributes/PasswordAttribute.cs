using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CiBitUtil.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {

        public string InvalidErrorMessage() =>
            $"Password must contain at least onr (1) upper-case letter, one (1) lower-case letter and a number.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
            if(password == null)
                return new ValidationResult(InvalidErrorMessage());


            var passRegex = new Regex(@"^[0-9a-zA-Z!@#$%^&*(){}?/*-+_+]{6,45}$");
            var hasnumberRegex = new Regex(@"[0-9]");
            var hasLowerRegex = new Regex(@"[a-z]");
            var hasUpperRegex = new Regex(@"[A-Z]");

            if (passRegex.Match(password).Success && hasnumberRegex.Match(password).Success
                && hasLowerRegex.Match(password).Success && hasUpperRegex.Match(password).Success)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(InvalidErrorMessage());
        }
    }
}
