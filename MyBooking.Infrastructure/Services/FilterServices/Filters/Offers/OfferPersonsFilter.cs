using System.Collections.Generic;
using System.Linq;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferPersonsFilter : IFilter<Offer>
    {
        public IEnumerable<Offer> Filter(IEnumerable<Offer> collection, ISpecification<Offer> specification)
            => specification.Precondition() ? collection.Where(o => specification.Predicate(o)) : collection;
    }
}