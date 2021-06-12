using System.Linq;
using MyBooking.Core.Entities;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferFavoriteSpecification : ISpecification<Offer>
    {
        private readonly string userId;

        public OfferFavoriteSpecification(string userId)
        {
            this.userId = userId;
        }

        public bool Predicate(Offer item) => item.OfferFollows.Any(of => of.UserId == userId);

        public bool Precondition() => true;
    }
}