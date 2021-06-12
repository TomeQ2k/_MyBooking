using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class UserRegisterDto
    {
        [RequiredValidator]
        [EmailAddress]
        public string Email { get; set; }

        [RequiredValidator]
        [StringLengthValidator(maxLength: Constants.MaxUserNameLength, minLength: Constants.MinUsernameLength)]
        [WhitespacesNotAllowedValidator]
        public string Username { get; set; }

        [RequiredValidator]
        [StringLengthValidator(maxLength: Constants.MaxPasswordLength, minLength: Constants.MinPasswordLength)]
        [WhitespacesNotAllowedValidator]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RequiredValidator]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}