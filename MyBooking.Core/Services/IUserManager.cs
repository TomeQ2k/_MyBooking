using System.Threading.Tasks;

namespace MyBooking.Core.Services
{
    public interface IUserManager
    {
        Task<bool> ClearNotConfirmedUsers();
    }
}