using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyBookingService
    {
        Task<BookedDate> GetBookedDate(string bookedDateId);
        Task<IEnumerable<BookedDate>> GetBookedDates(string currentUserId);
    }
}