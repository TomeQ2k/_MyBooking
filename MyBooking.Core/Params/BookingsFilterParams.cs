using System;
using MyBooking.Core.Enums;

namespace MyBooking.Core.Params
{
    public class BookingsFilterParams : FilterParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BookingDateStatus DateStatus { get; set; } = BookingDateStatus.All;
        public BookingConfirmStatus ConfirmStatus { get; set; } = BookingConfirmStatus.All;
        public BookingType Type { get; set; } = BookingType.All;
    }
}