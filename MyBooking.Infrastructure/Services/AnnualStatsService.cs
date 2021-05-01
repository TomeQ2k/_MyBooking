using System;
using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class AnnualStatsService : IAnnualStatsService
    {
        private readonly IDatabase database;

        public AnnualStatsService(IDatabase database)
        {
            this.database = database;
        }

        public async Task<int> GetBookingsCount()
            => (await database.BookedDateRepository.Filter(bd => bd.EndDate >= DateTime.Now.AddYears(Constants.Minus) && bd.IsConfirmed)).Count();

        public async Task<int> GetBookingOrdersCount()
            => (await database.BookingOrderRepository.Filter(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus))).Count();

        public async Task<int> GetOffersCount()
            => (await database.OfferRepository.Filter(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus))).Count();

        public async Task<int> GetCreatedAccountsCount()
            => (await database.UserRepository.Filter(u => u.DateRegistered >= DateTime.Now.AddYears(Constants.Minus) && u.EmailConfirmed)).Count();

        public async Task<decimal> GetTotalMoneyEarned()
            => (await database.BookingOrderRepository.Filter(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus)))
                .Select(o => o.TotalPrice)
                .Sum();

        public async Task<int> GetTotalCountInOffers()
            => (await database.OfferRepository.Filter(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus)))
                .Select(o => o.TotalCount)
                .Sum();

        public async Task<double> GetAverageOffersCountPerUser()
        {
            var users = await database.UserRepository.Filter(u => u.DateRegistered >= DateTime.Now.AddYears(Constants.Minus) && u.EmailConfirmed);

            return (double)users.Select(u => u.Offers.Count).Sum() / users.Count();
        }
    }
}