using System;

namespace MyBooking.Core.Models.Dtos
{
    public class MyOfferDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
        public int BookedDatesCount { get; set; }
        public string FirstPhotoUrl { get; set; }
    }
}