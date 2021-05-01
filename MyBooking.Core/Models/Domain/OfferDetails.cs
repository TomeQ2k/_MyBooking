using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public class OfferDetails
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Description { get; protected set; }
        public int RoomsCount { get; protected set; }
        public int PersonsCount { get; protected set; }
        public bool HasBathroom { get; protected set; }
        public bool HasKitchen { get; protected set; }
        public bool HasWifi { get; protected set; }
        public bool HasBalcony { get; protected set; }
        public bool HasTV { get; protected set; }
        public bool HasMinibar { get; protected set; }
        public AccommodationType AccommodationType { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string EmailAddress { get; protected set; }
        public string OfferId { get; protected set; }

        public virtual Offer Offer { get; protected set; }

        public void SetOfferId(string offerId)
        {
            OfferId = offerId;
        }
    }
}