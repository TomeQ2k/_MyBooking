namespace MyBooking.Core.Entities
{
    public class OfferFollow
    {
        public string OfferId { get; protected set; }
        public string UserId { get; protected set; }

        public virtual Offer Offer { get; protected set; }
        public virtual User User { get; protected set; }

        public static OfferFollow Create(string offerId, string userId) => new OfferFollow
        {
            OfferId = offerId,
            UserId = userId
        };
    }
}