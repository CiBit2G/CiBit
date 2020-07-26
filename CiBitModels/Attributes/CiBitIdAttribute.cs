using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CiBitUtil.Attributes
{
    class CiBitIdAttribute : ValidationAttribute
    {

        public string InvalidErrorMessage() =>
            $"CiBit IDs must be between 6 to 20 characters and must begin with an alphabetical character. Acceptable characters include letters, numbers, underscores (\" _ \") and dashes (\"-\").";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Id = value as string;
            if (Id == null)
                return new ValidationResult(InvalidErrorMessage());


            var Regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9_-]{5,19}$");

            if (Regex.Match(Id).Success )
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(InvalidErrorMessage());
        }
    }
}
