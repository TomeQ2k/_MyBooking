using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyFavoritesService
    {
        Task<IEnumerable<Offer>> GetFavoriteOffers(string userId);
    }
}