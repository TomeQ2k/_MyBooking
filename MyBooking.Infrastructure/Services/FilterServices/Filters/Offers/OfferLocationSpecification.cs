using MyBooking.Core.Entities;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferLocationSpecification : ISpecification<Offer>
    {
        private readonly string location;

        public OfferLocationSpecification(string location)
        {
            this.location = location;
        }

        public bool Predicate(Offer item) => item.Location.ToLower().Contains(location.ToLower());

        public bool Precondition() => !string.IsNullOrEmpty(location);
    }
}