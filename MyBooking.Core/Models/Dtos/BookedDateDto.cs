using System;

namespace MyBooking.Core.Models.Dtos
{
    public class BookedDateDto
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserId { get; set; }
        public string OfferTitle { get; set; }
        public string OfferId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Location { get; set; }
    }
}