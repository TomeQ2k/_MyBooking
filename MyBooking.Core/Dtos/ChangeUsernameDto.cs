using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class ChangeUsernameDto
    {
        [RequiredValidator]
        [StringLengthValidator(maxLength: Constants.MaxUserNameLength, minLength: Constants.MinUsernameLength)]
        [WhitespacesNotAllowedValidator]
        public string NewUsername { get; set; }
    }
}