using System.ComponentModel.DataAnnotations;

namespace MyBooking.Core.Dtos
{
    public class CheckoutOrderDto
    {
        [EmailAddress]
        public string AnonymousEmail { get; set; }
    }
}