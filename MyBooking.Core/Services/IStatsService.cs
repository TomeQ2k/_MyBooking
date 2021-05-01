using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface IStatsService
    {
        Task<int> GetBookingsCount();
        Task<int> GetBookingOrdersCount();
        Task<int> GetOffersCount();
        Task<int> GetCreatedAccountsCount();
        Task<decimal> GetTotalMoneyEarned();
        Task<int> GetTotalCountInOffers();
        Task<double> GetAverageOffersCountPerUser();
    }
}