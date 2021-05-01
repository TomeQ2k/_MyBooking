using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferPriceSpecification : ISpecification<Offer>
    {
        private readonly decimal minPrice;
        private readonly decimal maxPrice;

        public OfferPriceSpecification(decimal minPrice, decimal maxPrice)
        {
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
        }

        public bool Predicate(Offer item) => item.Price >= minPrice && item.Price <= maxPrice;

        public bool Precondition() => true;
    }
}