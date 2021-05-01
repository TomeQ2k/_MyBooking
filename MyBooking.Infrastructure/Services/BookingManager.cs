using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class BookingManager : IBookingManager
    {
        private readonly IDatabase database;

        public BookingManager(IDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> ClearNotConfirmedBookings()
        {
            var bookingsToDelete = await database.BookedDateRepository.Filter(bd => !bd.IsConfirmed);

            database.BookedDateRepository.DeleteRange(bookingsToDelete);

            return await database.Complete();
        }
    }
}