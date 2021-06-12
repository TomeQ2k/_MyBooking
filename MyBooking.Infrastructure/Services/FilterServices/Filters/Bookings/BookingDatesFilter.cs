using System.Collections.Generic;
using System.Linq;
using MyBooking.Core.Entities;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Bookings
{
    public class BookingDatesFilter : IFilter<BookedDate>
    {
        public IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> collection, ISpecification<BookedDate> specification)
            => specification.Precondition() ? collection.Where(bd => specification.Predicate(bd)) : collection;
    }
}