using System;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;

namespace MyBooking.Core.Params
{
    public class OffersFilterParams : FilterParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public decimal MinPrice => 0;
        public decimal MaxPrice { get; set; } = Constants.MaxPrice;
        public OfferSortType SortType { get; set; }
        public AccommodationType AccommodationType { get; set; } = AccommodationType.All;
        public int? RoomsCount { get; set; }
        public int? PersonsCount { get; set; }
    }
}