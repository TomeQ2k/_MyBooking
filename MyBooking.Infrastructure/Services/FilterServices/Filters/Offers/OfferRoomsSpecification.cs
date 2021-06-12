using MyBooking.Core.Entities;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferRoomsSpecification : ISpecification<Offer>
    {
        private readonly int? roomsCount;

        public OfferRoomsSpecification(int? roomsCount)
        {
            this.roomsCount = roomsCount;
        }

        public bool Predicate(Offer item)
            => item.OfferDetails.RoomsCount == roomsCount.Value;

        public bool Precondition() => roomsCount != null;
    }
}