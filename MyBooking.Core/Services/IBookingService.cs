using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IBookingService : IReadOnlyBookingService
    {
        Task<BookedDate> BookDate(DateTime startDate, DateTime endDate, string offerId);
        Task<bool> CancelBooking(string bookedDateId);

        IEnumerable<BookedDate> ConfirmBookings(IEnumerable<BookedDate> bookedDates);
    }
}