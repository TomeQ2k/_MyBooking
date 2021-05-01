using System;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Builders.Interfaces
{
    public interface IBookingOrderDetailsBuilder : IBuilder<BookingOrderDetails>
    {
        IBookingOrderDetailsBuilder SetOrder(string orderId);
        IBookingOrderDetailsBuilder SetOffer(string offerId, string offerTitle);
        IBookingOrderDetailsBuilder SetBooking(string bookingId);
        IBookingOrderDetailsBuilder OrderedByEmail(string customerEmail);
        IBookingOrderDetailsBuilder From(DateTime startDate);
        IBookingOrderDetailsBuilder To(DateTime endDate);
        IBookingOrderDetailsBuilder SetLocation(string location);
        IBookingOrderDetailsBuilder SetContactData(string phone, string contactEmail);
    }
}