using System.Threading.Tasks;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IFavoritesService : IReadOnlyFavoritesService
    {
        Task<bool> FollowOffer(string offerId);
    }
}