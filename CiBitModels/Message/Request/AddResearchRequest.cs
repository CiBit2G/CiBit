using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class AddResearchRequest : BaseWebRequest, IValidatableObject
    {
        [Required]
        public string ResearchName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ResearchName) || ResearchName.Length > 45)
            {
                yield return new ValidationResult(
                    $"Reasearch is Required and must be at most 45 Leeter. Research Nmae is: {ResearchName?.Length}.",
                    new[] { nameof(ResearchName) });
            }
        }
    }
}
