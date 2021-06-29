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
            => (await database.BookedDateRepository.GetWhere(bd => bd.EndDate >= DateTime.Now.AddYears(Constants.Minus) && bd.IsConfirmed)).Count();

        public async Task<int> GetBookingOrdersCount()
            => (await database.BookingOrderRepository.GetWhere(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus))).Count();

        public async Task<int> GetOffersCount()
            => (await database.OfferRepository.GetWhere(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus))).Count();

        public async Task<int> GetCreatedAccountsCount()
            => (await database.UserRepository.GetWhere(u => u.DateRegistered >= DateTime.Now.AddYears(Constants.Minus) && u.EmailConfirmed)).Count();

        public async Task<decimal> GetTotalMoneyEarned()
            => (await database.BookingOrderRepository.GetWhere(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus)))
                .Select(o => o.TotalPrice)
                .Sum();

        public async Task<int> GetTotalCountInOffers()
            => (await database.OfferRepository.GetWhere(o => o.DateCreated >= DateTime.Now.AddYears(Constants.Minus)))
                .Select(o => o.TotalCount)
                .Sum();

        public async Task<double> GetAverageOffersCountPerUser()
        {
            var users = await database.UserRepository.GetWhere(u => u.DateRegistered >= DateTime.Now.AddYears(Constants.Minus) && u.EmailConfirmed);
            int usersCount = users.Count();

            return usersCount != 0 ? (double)users.Select(u => u.Offers.Count).Sum() / usersCount : 0;
        }
    }
}