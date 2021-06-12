using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class ResetPasswordDto
    {
        [RequiredValidator]
        [StringLengthValidator(maxLength: Constants.MaxPasswordLength, minLength: Constants.MinPasswordLength)]
        [WhitespacesNotAllowedValidator]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [RequiredValidator]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}