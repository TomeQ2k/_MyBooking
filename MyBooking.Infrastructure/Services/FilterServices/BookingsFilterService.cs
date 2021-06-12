using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;
using MyBooking.Core.Params;
using MyBooking.Core.Services.FilterServices;
using MyBooking.Core.SmartEnums;

namespace MyBooking.Infrastructure.Services.FilterServices
{
    public class BookingsFilterService : BaseFilterService, IBookingsFilterService
    {
        public BookingsFilterService(IDatabase database) : base(database) { }

        public async Task<IEnumerable<BookedDate>> FilterBookings(BookingsFilterParams filterParams, FiltersDictionary<BookedDate> filtersDictionary, string currentUserId)
        {
            if (!filterParams.FilterEnabled)
                return null;

            var bookings = await database.BookedDateRepository.Filter(bd => bd.UserId == currentUserId || bd.Offer.CreatorId == currentUserId);

            bookings = filtersDictionary.RunFilters(bookings);

            bookings = BookingConfirmStatusSmartEnum.FromValue((int)filterParams.ConfirmStatus).Filter(bookings);
            bookings = BookingDateStatusSmartEnum.FromValue((int)filterParams.DateStatus).Filter(bookings);
            bookings = BookingTypeSmartEnum.FromValue((int)filterParams.Type).FilterBookings(bookings, currentUserId);

            return bookings;
        }
    }
}