using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Models.Dtos
{
    public class ChangePasswordDto
    {
        [RequiredValidator]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [RequiredValidator]
        [StringLengthValidator(maxLength: Constants.MaxPasswordLength, minLength: Constants.MinPasswordLength)]
        [WhitespacesNotAllowedValidator]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}