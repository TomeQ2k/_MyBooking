namespace MyBooking.Core.Models.Dtos
{
    public abstract class BaseOfferDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int AvailableCount { get; set; }
        public double Rating { get; set; }
        public string CreatorId { get; set; }
        public int FollowsCount { get; set; }
    }
}