using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class ForgotPasswordDto
    {
        [RequiredValidator]
        [EmailAddress]
        public string Email { get; set; }
    }
}