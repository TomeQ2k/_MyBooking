using System;

namespace MyBooking.Core.Models.Dtos
{
    public class OpinionDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string OfferId { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public double Rating { get; set; }
    }
}