using System;
using System.Linq;
using MyBooking.Core.Data;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class BookingValidationService : BaseValidationService, IBookingValidationService
    {
        public BookingValidationService(IDatabase database) : base(database) { }

        public bool IsBookingDateAvailable(DateTime startDate, DateTime endDate, Offer offer)
            => offer != null ? offer.GetAvailableCount(startDate, endDate) > 0 : throw new ArgumentNullException();

        public bool HasUserAnotherBookedDate(User user, string offerId)
            => user != null ? user.BookedDates.Any(bd => bd.OfferId == offerId && bd.EndDate > DateTime.Now) : throw new ArgumentNullException();

        public bool ValidateDates(DateTime startDate, DateTime endDate)
            => startDate < endDate && endDate > startDate;

        public bool IsPermittedToCancelBooking(BookedDate bookedDate, string currentUserId)
            => !(bookedDate.UserId != null && bookedDate.UserId != currentUserId && currentUserId != bookedDate.Offer.CreatorId);
    }
}