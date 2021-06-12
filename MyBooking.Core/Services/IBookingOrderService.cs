using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IBookingOrderService : IReadOnlyBookingOrderService
    {
        Task<BookingOrder> PurchaseOrder(string cartId);
    }
}