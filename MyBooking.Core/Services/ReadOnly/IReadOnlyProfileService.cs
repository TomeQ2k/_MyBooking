using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyProfileService
    {
        Task<User> GetCurrentUser();
    }
}