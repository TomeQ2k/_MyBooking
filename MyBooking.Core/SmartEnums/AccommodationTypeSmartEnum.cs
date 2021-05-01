using System.Collections.Generic;
using System.Linq;
using Ardalis.SmartEnum;
using MyBooking.Core.Enums;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.SmartEnums
{
    public abstract class AccommodationTypeSmartEnum : SmartEnum<AccommodationTypeSmartEnum>
    {
        protected AccommodationTypeSmartEnum(string name, int value) : base(name, value) { }

        public static readonly AccommodationTypeSmartEnum All = new AllType();
        public static readonly AccommodationTypeSmartEnum WithoutFood = new WithoutFoodType();
        public static readonly AccommodationTypeSmartEnum OnlyBreakfast = new OnlyBreakfastType();
        public static readonly AccommodationTypeSmartEnum BreakfastAndDinner = new BreakfastAndDinnerType();
        public static readonly AccommodationTypeSmartEnum AllInclusive = new AllInclusiveType();

        public abstract IEnumerable<Offer> Filter(IEnumerable<Offer> offers);

        private sealed class AllType : AccommodationTypeSmartEnum
        {
            public AllType() : base(nameof(All), (int)AccommodationType.All) { }

            public override IEnumerable<Offer> Filter(IEnumerable<Offer> offers) => offers;
        }

        private sealed class WithoutFoodType : AccommodationTypeSmartEnum
        {
            public WithoutFoodType() : base(nameof(WithoutFood), (int)AccommodationType.WithoutFood) { }

            public override IEnumerable<Offer> Filter(IEnumerable<Offer> offers)
                => offers.Where(o => o.OfferDetails.AccommodationType == AccommodationType.WithoutFood);
        }

        private sealed class OnlyBreakfastType : AccommodationTypeSmartEnum
        {
            public OnlyBreakfastType() : base(nameof(OnlyBreakfast), (int)AccommodationType.OnlyBreakfast) { }

            public override IEnumerable<Offer> Filter(IEnumerable<Offer> offers)
                => offers.Where(o => o.OfferDetails.AccommodationType == AccommodationType.OnlyBreakfast);
        }

        private sealed class BreakfastAndDinnerType : AccommodationTypeSmartEnum
        {
            public BreakfastAndDinnerType() : base(nameof(BreakfastAndDinner), (int)AccommodationType.BreakfastAndDinner) { }

            public override IEnumerable<Offer> Filter(IEnumerable<Offer> offers)
                => offers.Where(o => o.OfferDetails.AccommodationType == AccommodationType.BreakfastAndDinner);
        }

        private sealed class AllInclusiveType : AccommodationTypeSmartEnum
        {
            public AllInclusiveType() : base(nameof(AllInclusive), (int)AccommodationType.AllInclusive) { }

            public override IEnumerable<Offer> Filter(IEnumerable<Offer> offers)
                => offers.Where(o => o.OfferDetails.AccommodationType == AccommodationType.AllInclusive);
        }
    }
}