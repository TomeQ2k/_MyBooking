using System;
using MyBooking.Core.Builders.Interfaces;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Builders
{
    public class BookingOrderDetailsBuilder : IBookingOrderDetailsBuilder
    {
        private readonly BookingOrderDetails orderDetails = new BookingOrderDetails();

        public IBookingOrderDetailsBuilder SetOrder(string orderId)
        {
            this.orderDetails.SetOrderId(orderId);

            return this;
        }

        public IBookingOrderDetailsBuilder SetOffer(string offerId, string offerTitle)
        {
            this.orderDetails.SetOfferId(offerId);
            this.orderDetails.SetOfferTitle(offerTitle);

            return this;
        }

        public IBookingOrderDetailsBuilder SetBooking(string bookingId)
        {
            this.orderDetails.SetBookingId(bookingId);

            return this;
        }

        public IBookingOrderDetailsBuilder OrderedByEmail(string customerEmail)
        {
            this.orderDetails.SetCustomerEmail(customerEmail);

            return this;
        }

        public IBookingOrderDetailsBuilder From(DateTime startDate)
        {
            this.orderDetails.SetStartDate(startDate);

            return this;
        }

        public IBookingOrderDetailsBuilder To(DateTime endDate)
        {
            this.orderDetails.SetEndDate(endDate);

            return this;
        }

        public IBookingOrderDetailsBuilder SetLocation(string location)
        {
            this.orderDetails.SetLocation(location);

            return this;
        }

        public IBookingOrderDetailsBuilder SetContactData(string phone, string contactEmail)
        {
            this.orderDetails.SetContactData(phone, contactEmail);

            return this;
        }

        public BookingOrderDetails Build() => this.orderDetails;
    }
}