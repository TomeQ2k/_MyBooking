using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Builders;
using MyBooking.Core.Data;
using MyBooking.Core.Helpers;
using MyBooking.Core.Entities;
using MyBooking.Core.Params;
using MyBooking.Core.Services;
using MyBooking.Core.SmartEnums;

namespace MyBooking.Infrastructure.Services
{
    public class BookingOrderService : IBookingOrderService
    {
        private readonly IDatabase database;
        private readonly IBookingService bookingService;

        public BookingOrderService(IDatabase database, IBookingService bookingService)
        {
            this.database = database;
            this.bookingService = bookingService;
        }

        public async Task<IEnumerable<BookingOrder>> FetchOrders(string currentUserId, BookingOrdersFilterParams filterParams)
        {
            var orders = await database.BookingOrderRepository.Filter(o => o.OrderDetails.Booking.UserId == currentUserId);

            orders = BookingTypeSmartEnum.FromValue((int)filterParams.Type).FilterOrders(orders, currentUserId);

            orders = orders.OrderByDescending(o => o.DateCreated);

            return orders;
        }

        public async Task<BookingOrder> PurchaseOrder(string cartId)
        {
            var cartItems = await database.BookingCartItemRepository.Filter(b => b.BookingCartId == cartId);

            var firstCartItem = cartItems.FirstOrDefault();

            if (firstCartItem == null)
                return null;

            var orderDetails = new BookingOrderDetailsBuilder()
                .SetOffer(firstCartItem.BookedDate.OfferId, firstCartItem.BookedDate.Offer.Title)
                .SetBooking(firstCartItem.BookedDateId)
                .OrderedByEmail(firstCartItem.User?.Email)
                .From(firstCartItem.BookedDate.StartDate)
                .To(firstCartItem.BookedDate.EndDate)
                .SetLocation(firstCartItem.BookedDate.Offer.Location)
                .SetContactData(firstCartItem.BookedDate.Offer.OfferDetails.PhoneNumber, firstCartItem.BookedDate.Offer.OfferDetails.EmailAddress)
                .Build();

            decimal totalPrice = cartItems.Sum(c => c.BookedDate.GetTotalPrice());
            var order = BookingOrder.Create(Constants.BookingOrderDescription(orderDetails, totalPrice),
                totalPrice);

            database.BookingOrderRepository.Add(order);

            if (!await database.Complete())
                return null;

            orderDetails.SetOrderId(order.Id);

            database.BookingOrderDetailsRepository.Add(orderDetails);
            database.BookingCartItemRepository.DeleteRange(cartItems);

            bookingService.ConfirmBookings(cartItems.Select(c => c.BookedDate));

            return await database.Complete() ? order : null;
        }
    }
}