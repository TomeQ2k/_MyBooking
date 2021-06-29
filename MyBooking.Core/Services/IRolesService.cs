using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Enums;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IRolesService : IReadOnlyRolesService
    {
        Task<bool> AdmitRole(RoleType roleType, User user);
        bool AdmitRole(string roleId, User user);

        Task<bool> RevokeRole(RoleType roleType, User user);
        bool RevokeRole(string roleId, User user);

        Task<bool> CreateRole(RoleType roleType);
    }
}