namespace MyBooking.Core.Models.Domain
{
    public class OfferRate
    {
        public string OpinionId { get; protected set; }
        public string UserId { get; protected set; }
        public double Rating { get; protected set; }

        public virtual Opinion Opinion { get; protected set; }
        public virtual User User { get; protected set; }

        public static OfferRate Create(double rating, string opinionId, string userId) => new OfferRate
        {
            Rating = rating,
            OpinionId = opinionId,
            UserId = userId
        };
    }
}