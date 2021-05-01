using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyFavoritesService
    {
        Task<IEnumerable<Offer>> GetFavoriteOffers(string userId);
    }
}