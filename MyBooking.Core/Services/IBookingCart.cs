using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services
{
    public interface IBookingCart
    {
        Task<BookingCartItem> AddToCart(BookedDate bookedDate);

        void SetCartId(string cartId);
        void SetCurrentUserId(string currentUserId);
    }
}