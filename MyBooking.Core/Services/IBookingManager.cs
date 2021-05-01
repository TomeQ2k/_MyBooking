using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface IBookingManager
    {
        Task<bool> ClearNotConfirmedBookings();
    }
}