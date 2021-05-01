using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IBookingOrderService : IReadOnlyBookingOrderService
    {
        Task<BookingOrder> PurchaseOrder(string cartId);
    }
}