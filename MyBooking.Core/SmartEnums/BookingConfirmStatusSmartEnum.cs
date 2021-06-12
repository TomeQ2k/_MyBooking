using System.Collections.Generic;
using System.Linq;
using Ardalis.SmartEnum;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;

namespace MyBooking.Core.SmartEnums
{
    public abstract class BookingConfirmStatusSmartEnum : SmartEnum<BookingConfirmStatusSmartEnum>
    {
        protected BookingConfirmStatusSmartEnum(string name, int value) : base(name, value) { }

        public static readonly BookingConfirmStatusSmartEnum All = new AllType();
        public static readonly BookingConfirmStatusSmartEnum Confirmed = new ConfirmedType();
        public static readonly BookingConfirmStatusSmartEnum NotConfirmed = new NotConfirmedType();

        public abstract IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates);

        private sealed class AllType : BookingConfirmStatusSmartEnum
        {
            public AllType() : base(nameof(All), (int)BookingConfirmStatus.All) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates) => bookedDates;
        }

        private sealed class ConfirmedType : BookingConfirmStatusSmartEnum
        {
            public ConfirmedType() : base(nameof(Confirmed), (int)BookingConfirmStatus.Confirmed) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates)
                => bookedDates.Where(bd => bd.IsConfirmed);
        }

        private sealed class NotConfirmedType : BookingConfirmStatusSmartEnum
        {
            public NotConfirmedType() : base(nameof(NotConfirmed), (int)BookingConfirmStatus.NotConfirmed) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates)
                => bookedDates.Where(bd => !bd.IsConfirmed);
        }
    }
}