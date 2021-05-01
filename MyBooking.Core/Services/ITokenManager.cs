using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface ITokenManager
    {
        Task<bool> ClearExpiredTokens();
    }
}