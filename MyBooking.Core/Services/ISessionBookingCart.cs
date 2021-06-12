using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services
{
    public interface ISessionBookingCart : IBookingCart
    {
        Task<List<BookingCartItem>> GetSessionBookingCartItems();
    }
}