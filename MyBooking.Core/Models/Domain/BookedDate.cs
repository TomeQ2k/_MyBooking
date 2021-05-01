using System;
using System.Collections.Generic;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public class BookedDate
    {
        public string Id { get; protected set; } = Utils.Id();
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public bool IsConfirmed { get; protected set; }
        public string OfferId { get; protected set; }
        public string UserId { get; protected set; }

        public virtual Offer Offer { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual BookingCartItem BookingCartItem { get; protected set; }

        public virtual ICollection<BookingOrderDetails> BookingOrderDetails { get; protected set; } = new HashSet<BookingOrderDetails>();

        public static BookedDate Create(DateTime startDate, DateTime endDate) => new BookedDate
        {
            StartDate = startDate,
            EndDate = endDate
        };

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public decimal GetTotalPrice()
            => (decimal)(EndDate - StartDate).TotalDays * Offer.Price;
    }
}