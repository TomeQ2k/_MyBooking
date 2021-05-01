using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface IAuthValidationService
    {
        Task<bool> EmailExists(string email);
        Task<bool> UsernameExists(string username);
    }
}