using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Validators
{
    public class RequiredValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ValidatorMessages.RequiredValidatorMessage);

            return ValidationResult.Success;
        }
    }
}