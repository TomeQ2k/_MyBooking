using System;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public class BookingOrderDetails
    {
        public string Id { get; protected set; } = Utils.Id();
        public string OrderId { get; protected set; }
        public string OfferId { get; protected set; }
        public string BookingId { get; protected set; }
        public string CustomerEmail { get; protected set; }
        public string OfferTitle { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string Location { get; protected set; }
        public string Phone { get; protected set; }
        public string ContactEmail { get; protected set; }

        public virtual Offer Offer { get; protected set; }
        public virtual BookedDate Booking { get; protected set; }
        public virtual BookingOrder Order { get; protected set; }

        public void SetOrderId(string orderId)
        {
            OrderId = orderId;
        }

        public void SetOfferId(string offerId)
        {
            OfferId = offerId;
        }

        public void SetOfferTitle(string offerTitle)
        {
            OfferTitle = offerTitle;
        }

        public void SetBookingId(string bookingId)
        {
            BookingId = bookingId;
        }

        public void SetCustomerEmail(string customerEmail)
        {
            CustomerEmail = customerEmail;
        }

        public void SetStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }

        public void SetLocation(string location)
        {
            Location = location;
        }

        public void SetContactData(string phone, string contactEmail)
        {
            Phone = phone;
            ContactEmail = contactEmail;
        }
    }
}