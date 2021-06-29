using System.Threading.Tasks;
using MyBooking.Core.Enums;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyRolesService
    {
        Task<bool> IsPermitted(string userId, RoleType roleType);

        Task<bool> RoleExists(RoleType roleType);

        Task<string> GetRoleId(RoleType roleType);
    }
}