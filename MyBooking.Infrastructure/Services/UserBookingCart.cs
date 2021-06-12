using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class UserBookingCart : BookingCart, IUserBookingCart
    {
        public UserBookingCart(IDatabase database) : base(database) { }

        public async Task<List<BookingCartItem>> GetUserBookingCartItems()
        {
            if (BookingCartItems != null)
                return BookingCartItems;

            if (CurrentUserId == null)
                return null;

            var userBookingCartItems = (await database.BookingCartItemRepository.Filter(b => b.UserId == CurrentUserId)).ToList();
            userBookingCartItems.ForEach(b => b.SetBookingCartId(CartId));

            await database.Complete();

            return (BookingCartItems = userBookingCartItems);
        }
    }
}