using System;

namespace MyBooking.Core.Models.Dtos
{
    public class BookingOrderDto
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingId { get; set; }
        public string OfferId { get; set; }
    }
}