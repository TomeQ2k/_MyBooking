using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class RatingManager : IRatingManager
    {
        private readonly IDatabase database;

        public RatingManager(IDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> AddOfferRate(double rating, string opinionId, string userId)
        {
            var offerRate = OfferRate.Create(rating, opinionId, userId);

            database.OfferRateRepository.Add(offerRate);

            return await database.Complete();
        }
    }
}