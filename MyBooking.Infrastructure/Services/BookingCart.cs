using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public abstract class BookingCart : IBookingCart
    {
        protected readonly IDatabase database;

        public string CartId { get; private set; }
        public string CurrentUserId { get; private set; }

        public List<BookingCartItem> BookingCartItems { get; protected set; }

        public BookingCart(IDatabase database)
        {
            this.database = database;
        }

        public async Task<BookingCartItem> AddToCart(BookedDate bookedDate)
        {
            if (bookedDate == null)
                return null;

            var bookingCartItem = BookingCartItem.Create(CartId, bookedDate.Id, userId: CurrentUserId);

            database.BookingCartItemRepository.Add(bookingCartItem);

            return await database.Complete() ? bookingCartItem : null;
        }

        public void SetCartId(string cartId)
        {
            CartId = cartId;
        }

        public void SetCurrentUserId(string currentUserId)
        {
            CurrentUserId = currentUserId;
        }
    }
}