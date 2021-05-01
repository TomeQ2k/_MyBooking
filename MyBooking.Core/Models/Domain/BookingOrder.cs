namespace MyBooking.Core.Models.Domain
{
    public class BookingOrder : BaseOrder
    {
        public virtual BookingOrderDetails OrderDetails { get; protected set; }

        public static BookingOrder Create(string description, decimal totalPrice) => new BookingOrder
        {
            Description = description,
            TotalPrice = totalPrice
        };
    }
}