using System;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services
{
    public interface IBookingValidationService
    {
        bool IsBookingDateAvailable(DateTime startDate, DateTime endDate, Offer offer);
        bool HasUserAnotherBookedDate(User user, string offerId);
        bool ValidateDates(DateTime startDate, DateTime endDate);
        bool IsPermittedToCancelBooking(BookedDate bookedDate, string currentUserId);
    }
}