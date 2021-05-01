using MyBooking.Core.Enums;

namespace MyBooking.Core.Params
{
    public class BookingOrdersFilterParams : FilterParams
    {
        public BookingType Type { get; set; }
    }
}