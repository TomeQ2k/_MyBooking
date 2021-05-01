using System.ComponentModel.DataAnnotations;

namespace MyBooking.Core.Models.Dtos
{
    public class CheckoutOrderDto
    {
        [EmailAddress]
        public string AnonymousEmail { get; set; }
    }
}