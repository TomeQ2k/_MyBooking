using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Models.Dtos
{
    public class ChangeEmailDto
    {
        [RequiredValidator]
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}