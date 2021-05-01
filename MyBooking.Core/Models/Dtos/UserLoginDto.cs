using System.ComponentModel.DataAnnotations;

namespace MyBooking.Core.Models.Dtos
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}