using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public class BookingCartItem
    {
        public string Id { get; protected set; } = Utils.Id();
        public string BookingCartId { get; protected set; }
        public string BookedDateId { get; protected set; }
        public string UserId { get; protected set; }

        public virtual BookedDate BookedDate { get; protected set; }
        public virtual User User { get; protected set; }

        public static BookingCartItem Create(string bookingCartId, string bookedDateId, string userId = null) => new BookingCartItem
        {
            BookingCartId = bookingCartId,
            BookedDateId = bookedDateId,
            UserId = userId
        };

        public void SetBookingCartId(string bookingCartId)
        {
            BookingCartId = bookingCartId;
        }
    }
}