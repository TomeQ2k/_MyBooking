using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class SessionBookingCart : BookingCart, ISessionBookingCart
    {
        public SessionBookingCart(IDatabase database) : base(database) { }

        public async Task<List<BookingCartItem>> GetSessionBookingCartItems()
            => BookingCartItems ?? (BookingCartItems = (await database.BookingCartItemRepository.Filter(b => b.BookingCartId == CartId)).ToList());
    }
}