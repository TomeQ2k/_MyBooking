using System;
using System.Collections.Generic;
using System.Linq;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Models.Domain
{
    public class Offer
    {
        public string Id { get; protected set; } = Utils.Id();
        public string Title { get; protected set; }
        public decimal Price { get; protected set; }
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public string Location { get; protected set; }
        public int TotalCount { get; protected set; }
        public string OfferDetailsId { get; protected set; }
        public string CreatorId { get; protected set; }

        public virtual OfferDetails OfferDetails { get; protected set; }
        public virtual User Creator { get; protected set; }

        public virtual ICollection<Opinion> Opinions { get; protected set; } = new HashSet<Opinion>();
        public virtual ICollection<BookedDate> BookedDates { get; protected set; } = new HashSet<BookedDate>();
        public virtual ICollection<OfferFollow> OfferFollows { get; protected set; } = new HashSet<OfferFollow>();
        public virtual ICollection<OfferPhoto> OfferPhotos { get; protected set; } = new HashSet<OfferPhoto>();
        public virtual ICollection<BookingOrderDetails> BookingOrderDetails { get; protected set; } = new HashSet<BookingOrderDetails>();

        public void SetDetailsId(string detailsId)
        {
            OfferDetailsId = detailsId;
        }

        public void FillOfferPhotos(ICollection<OfferPhoto> offerPhotos)
        {
            OfferPhotos = offerPhotos;
        }

        public double GetRating()
            => Opinions.Any() ? Opinions.Select(o => o.OfferRate.Rating).Sum() / Opinions.Count : 0;

        public string GetFirstPhotoUrl()
            => StorageLocation.BuildLocation(OfferPhotos.Any() ? OfferPhotos.FirstOrDefault().Path : null);

        public int GetAvailableCount(DateTime startDate, DateTime endDate)
        {
            int availableCount = TotalCount;

            BookedDates.Where(bd => bd.IsConfirmed).ToList().ForEach(bd =>
            {
                if ((bd.StartDate <= startDate && bd.EndDate > startDate) || (bd.StartDate <= endDate && bd.EndDate > endDate))
                    if (--availableCount == 0) return;
            });

            return availableCount;
        }
    }
}