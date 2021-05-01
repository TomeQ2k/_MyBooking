using System.Threading.Tasks;
using MyBooking.Core.Enums;

namespace MyBooking.Core.Services
{
    public interface IRolesService
    {
        Task<bool> CreateRole(RoleType roleType);

        Task<bool> IsPermitted(string userId, RoleType roleType);

        Task<bool> RoleExists(RoleType roleType);
    }
}