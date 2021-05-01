using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferPersonsSpecification : ISpecification<Offer>
    {
        private readonly int? personsCount;

        public OfferPersonsSpecification(int? personsCount)
        {
            this.personsCount = personsCount;
        }

        public bool Predicate(Offer item)
            => item.OfferDetails.PersonsCount == personsCount.Value;

        public bool Precondition() => personsCount != null;
    }
}