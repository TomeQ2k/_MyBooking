using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.SmartEnum;
using MyBooking.Core.Enums;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.SmartEnums
{
    public abstract class BookingDateStatusSmartEnum : SmartEnum<BookingDateStatusSmartEnum>
    {
        protected BookingDateStatusSmartEnum(string name, int value) : base(name, value) { }

        public static readonly BookingDateStatusSmartEnum All = new AllType();
        public static readonly BookingDateStatusSmartEnum Incoming = new IncomingType();
        public static readonly BookingDateStatusSmartEnum Expired = new ExpiredType();

        public abstract IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates);

        private sealed class AllType : BookingDateStatusSmartEnum
        {
            public AllType() : base(nameof(All), (int)BookingDateStatus.All) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates) => bookedDates;
        }

        private sealed class IncomingType : BookingDateStatusSmartEnum
        {
            public IncomingType() : base(nameof(Incoming), (int)BookingDateStatus.Incoming) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates)
                => bookedDates.Where(bd => bd.EndDate > DateTime.Now);
        }

        private sealed class ExpiredType : BookingDateStatusSmartEnum
        {
            public ExpiredType() : base(nameof(Expired), (int)BookingDateStatus.Expired) { }

            public override IEnumerable<BookedDate> Filter(IEnumerable<BookedDate> bookedDates)
                => bookedDates.Where(bd => bd.EndDate < DateTime.Now);
        }
    }
}