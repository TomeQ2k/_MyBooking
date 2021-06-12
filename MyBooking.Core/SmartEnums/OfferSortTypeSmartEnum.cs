using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.SmartEnum;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;

namespace MyBooking.Core.SmartEnums
{
    public abstract class OfferSortTypeSmartEnum : SmartEnum<OfferSortTypeSmartEnum>
    {
        protected OfferSortTypeSmartEnum(string name, int value) : base(name, value) { }

        public static readonly OfferSortTypeSmartEnum DateDescending = new DateDescendingType();
        public static readonly OfferSortTypeSmartEnum DateAscending = new DateAscendingType();
        public static readonly OfferSortTypeSmartEnum PriceDescending = new PriceDescendingType();
        public static readonly OfferSortTypeSmartEnum PriceAscending = new PriceAscendingType();
        public static readonly OfferSortTypeSmartEnum RatingDescending = new RatingDescendingType();
        public static readonly OfferSortTypeSmartEnum AvailableCountDescending = new AvailableCountDescendingType();
        public static readonly OfferSortTypeSmartEnum FollowsCountDescending = new FollowsCountDescendingType();

        public abstract IEnumerable<Offer> Sort(IEnumerable<Offer> offers);

        private sealed class DateDescendingType : OfferSortTypeSmartEnum
        {
            public DateDescendingType() : base(nameof(DateDescending), (int)OfferSortType.DateDescending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderByDescending(o => o.DateCreated);
        }

        private sealed class DateAscendingType : OfferSortTypeSmartEnum
        {
            public DateAscendingType() : base(nameof(DateAscending), (int)OfferSortType.DateAscending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderBy(o => o.DateCreated);
        }

        private sealed class PriceDescendingType : OfferSortTypeSmartEnum
        {
            public PriceDescendingType() : base(nameof(PriceDescending), (int)OfferSortType.PriceDescending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderByDescending(o => o.Price);
        }

        private sealed class PriceAscendingType : OfferSortTypeSmartEnum
        {
            public PriceAscendingType() : base(nameof(PriceAscending), (int)OfferSortType.PriceAscending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderBy(o => o.Price);
        }

        private sealed class RatingDescendingType : OfferSortTypeSmartEnum
        {
            public RatingDescendingType() : base(nameof(RatingDescending), (int)OfferSortType.RatingDescending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderByDescending(o => o.GetRating());
        }

        private sealed class AvailableCountDescendingType : OfferSortTypeSmartEnum
        {
            public AvailableCountDescendingType() : base(nameof(AvailableCountDescending), (int)OfferSortType.AvailableCountDescending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderByDescending(o => o.GetAvailableCount(DateTime.Now, DateTime.Now));
        }

        private sealed class FollowsCountDescendingType : OfferSortTypeSmartEnum
        {
            public FollowsCountDescendingType() : base(nameof(FollowsCountDescending), (int)OfferSortType.FollowsCountDescending) { }

            public override IEnumerable<Offer> Sort(IEnumerable<Offer> offers)
                => offers.OrderByDescending(o => o.OfferFollows.Count);
        }
    }
}