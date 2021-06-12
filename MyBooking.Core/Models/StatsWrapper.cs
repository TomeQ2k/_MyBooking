using System.Threading.Tasks;
using MyBooking.Core.Services;

namespace MyBooking.Core.Models
{
    public class StatsWrapper
    {
        private readonly IStatsService statsService;

        public int BookingsCount { get; private set; }
        public int BookingOrdersCount { get; private set; }
        public int OffersCount { get; private set; }
        public int CreatedAccountsCount { get; private set; }
        public decimal TotalMoneyEarned { get; private set; }
        public long TotalCountInOffers { get; private set; }
        public double AverageOffersCountPerUser { get; private set; }

        public StatsWrapper(IStatsService statsService)
        {
            this.statsService = statsService;
        }

        public async Task SetBookingsCount()
        {
            BookingsCount = await statsService.GetBookingsCount();
        }

        public async Task SetBookingOrdersCount()
        {
            BookingOrdersCount = await statsService.GetBookingOrdersCount();
        }

        public async Task SetOffersCount()
        {
            OffersCount = await statsService.GetOffersCount();
        }

        public async Task SetCreatedAccountsCount()
        {
            CreatedAccountsCount = await statsService.GetCreatedAccountsCount();
        }

        public async Task SetTotalMoneyEarned()
        {
            TotalMoneyEarned = await statsService.GetTotalMoneyEarned();
        }

        public async Task SetTotalCountInOffers()
        {
            TotalCountInOffers = await statsService.GetTotalCountInOffers();
        }

        public async Task SetAverageOffersCountPerUser()
        {
            AverageOffersCountPerUser = await statsService.GetAverageOffersCountPerUser();
        }

        public async Task<StatsWrapper> Build()
        {
            await SetBookingsCount();
            await SetBookingOrdersCount();
            await SetOffersCount();
            await SetCreatedAccountsCount();
            await SetTotalMoneyEarned();
            await SetTotalCountInOffers();
            await SetAverageOffersCountPerUser();

            return this;
        }
    }
}