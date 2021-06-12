using System.ComponentModel.DataAnnotations;

namespace MyBooking.Core.Dtos
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}