using System;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Bookings
{
    public class BookingDatesSpecification : ISpecification<BookedDate>
    {
        private readonly DateTime? startDate;
        private readonly DateTime? endDate;

        public BookingDatesSpecification(DateTime? startDate, DateTime? endDate)
        {
            this.startDate = startDate ?? DateTime.MinValue;
            this.endDate = endDate ?? DateTime.MaxValue;
        }

        public bool Predicate(BookedDate item)
            => item.StartDate < endDate && startDate < item.EndDate;

        public bool Precondition() => true;
    }
}