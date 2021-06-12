using System.Collections.Generic;
using System.Linq;
using Ardalis.SmartEnum;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;

namespace MyBooking.Core.SmartEnums
{
    public abstract class BookingTypeSmartEnum : SmartEnum<BookingTypeSmartEnum>
    {
        protected BookingTypeSmartEnum(string name, int value) : base(name, value) { }

        public static readonly BookingTypeSmartEnum All = new AllType();
        public static readonly BookingTypeSmartEnum AsCustomer = new AsCustomerType();
        public static readonly BookingTypeSmartEnum AsDealer = new AsDealerType();

        public abstract IEnumerable<BookedDate> FilterBookings(IEnumerable<BookedDate> bookedDates, string currentUserId);
        public abstract IEnumerable<BookingOrder> FilterOrders(IEnumerable<BookingOrder> orders, string currentUserId);

        private sealed class AllType : BookingTypeSmartEnum
        {
            public AllType() : base(nameof(All), (int)BookingType.All) { }

            public override IEnumerable<BookedDate> FilterBookings(IEnumerable<BookedDate> bookedDates, string currentUserId)
                => bookedDates.Where(bd => (bd.UserId == currentUserId && bd.Offer.CreatorId != currentUserId) || bd.Offer.CreatorId == currentUserId);

            public override IEnumerable<BookingOrder> FilterOrders(IEnumerable<BookingOrder> orders, string currentUserId)
                => orders.Where(o => (o.OrderDetails.Booking.UserId == currentUserId && o.OrderDetails.Booking.Offer.CreatorId != currentUserId) || o.OrderDetails.Booking.Offer.CreatorId == currentUserId);
        }

        private sealed class AsCustomerType : BookingTypeSmartEnum
        {
            public AsCustomerType() : base(nameof(AsCustomer), (int)BookingType.AsCustomer) { }

            public override IEnumerable<BookedDate> FilterBookings(IEnumerable<BookedDate> bookedDates, string currentUserId)
                => bookedDates.Where(bd => bd.UserId == currentUserId && bd.Offer.CreatorId != currentUserId);

            public override IEnumerable<BookingOrder> FilterOrders(IEnumerable<BookingOrder> orders, string currentUserId)
               => orders.Where(o => o.OrderDetails.Booking.UserId == currentUserId && o.OrderDetails.Booking.Offer.CreatorId != currentUserId);
        }

        private sealed class AsDealerType : BookingTypeSmartEnum
        {
            public AsDealerType() : base(nameof(AsDealer), (int)BookingType.AsDealer) { }

            public override IEnumerable<BookedDate> FilterBookings(IEnumerable<BookedDate> bookedDates, string currentUserId)
                => bookedDates.Where(bd => bd.Offer.CreatorId == currentUserId);

            public override IEnumerable<BookingOrder> FilterOrders(IEnumerable<BookingOrder> orders, string currentUserId)
               => orders.Where(o => o.OrderDetails.Booking.Offer.CreatorId == currentUserId);
        }
    }
}