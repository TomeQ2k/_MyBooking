namespace MyBooking.Core.Models.Domain
{
    public class OfferPhoto : BaseFile
    {
        public string OfferId { get; protected set; }

        public virtual Offer Offer { get; protected set; }

        public OfferPhoto SetOfferId(string offerId)
        {
            OfferId = offerId;
            
            return this;
        }
    }
}