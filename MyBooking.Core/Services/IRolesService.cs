using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Enums;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IRolesService : IReadOnlyRolesService
    {
        bool AdmitRole(string roleId, User user);
        bool RevokeRole(string roleId, User user);

        Task<bool> CreateRole(RoleType roleType);
    }
}