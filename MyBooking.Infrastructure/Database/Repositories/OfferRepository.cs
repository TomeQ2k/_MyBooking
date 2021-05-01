using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBooking.Core.Data.Repositories;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Infrastructure.Database.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Offer>> GetFavoriteOffers(string userId)
            => await context.OfferFollows.Where(of => of.UserId == userId)
                    .Select(of => of.Offer)
                    .OrderByDescending(o => o.DateCreated)
                    .ToListAsync();
    }
}