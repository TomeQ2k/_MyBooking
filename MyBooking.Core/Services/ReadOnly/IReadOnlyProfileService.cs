using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyProfileService
    {
        Task<User> GetCurrentUser();
    }
}