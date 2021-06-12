using System;
using System.Linq;
using MyBooking.Core.Entities;
using MyBooking.Core.Services.FilterServices.Filters;

namespace MyBooking.Infrastructure.Services.FilterServices.Filters.Offers
{
    public class OfferDatesSpecification : ISpecification<Offer>
    {
        private DateTime? startDate;
        private readonly DateTime? endDate;

        public OfferDatesSpecification(DateTime? startDate, DateTime? endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public bool Predicate(Offer item)
        {
            startDate = startDate ?? DateTime.Now;

            return !item.BookedDates.Any(bd => (bd.StartDate <= startDate && bd.EndDate > startDate)
                    || (bd.StartDate <= endDate && bd.EndDate > endDate));
        }

        public bool Precondition() => endDate != null;
    }
}