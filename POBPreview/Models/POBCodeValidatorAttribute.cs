using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using POBPreview.Utils;

namespace POBPreview.Models
{
	public class POBCodeValidatorAttribute : ValidationAttribute
	{
        private Regex pastebinRegex = new Regex(@"^https?://(www.)?pastebin.com/[^/]+$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Error: Code can't be empty!",
                    new[] { validationContext.MemberName });
            }
            if (pastebinRegex.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else if (POBDecoder.GetBuildXML(value.ToString()) != null)
            {
                return ValidationResult.Success;
            }
            
            
            return new ValidationResult("Error: only one is allowed in this property.",
                new[] { validationContext.MemberName });
        }
    }
}

