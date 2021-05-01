using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Extensions;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Validators
{
    public class WhitespacesNotAllowedValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = (string)value;

            if (val.HasWhitespaces())
                return new ValidationResult(ValidatorMessages.WhitespacesValidatorMessage);

            return ValidationResult.Success;
        }
    }
}