using System;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Entities
{
    public class Opinion
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Text { get; protected set; }
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public string OfferId { get; protected set; }
        public string UserId { get; protected set; }

        public virtual Offer Offer { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual OfferRate OfferRate { get; protected set; }

        public static Opinion Create(string text) => new Opinion { Text = text };
    }
}