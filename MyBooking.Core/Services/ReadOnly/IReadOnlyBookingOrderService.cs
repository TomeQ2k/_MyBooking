using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Params;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyBookingOrderService
    {
        Task<IEnumerable<BookingOrder>> FetchOrders(string currentUserId, BookingOrdersFilterParams filterParams);
    }
}