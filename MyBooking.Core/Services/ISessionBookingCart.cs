using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services
{
    public interface ISessionBookingCart : IBookingCart
    {
        Task<List<BookingCartItem>> GetSessionBookingCartItems();
    }
}