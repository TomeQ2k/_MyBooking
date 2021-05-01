using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Data.Repositories
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<IEnumerable<Offer>> GetFavoriteOffers(string userId);
    }
}