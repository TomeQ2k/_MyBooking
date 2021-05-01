using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface IRatingManager
    {
        Task<bool> AddOfferRate(double rating, string opinionId, string userId);
    }
}