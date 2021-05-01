using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Models.Helpers;
using MyBooking.Core.Params;

namespace MyBooking.Core.Services.FilterServices
{
    public interface IBookingsFilterService
    {
        Task<IEnumerable<BookedDate>> FilterBookings(BookingsFilterParams filterParams, FiltersDictionary<BookedDate> filtersDictionary, string currentUserId);
    }
}