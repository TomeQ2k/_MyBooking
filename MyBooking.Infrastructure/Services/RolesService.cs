using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;
using System.Linq;
using MyBooking.Core.Helpers;

namespace MyBooking.Infrastructure.Services
{
    public class RolesService : IRolesService
    {
        private readonly IDatabase database;

        public RolesService(IDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> AdmitRole(RoleType roleType, User user)
            => AdmitRole(await GetRoleId(roleType), user);

        public bool AdmitRole(string roleId, User user)
        {
            if (user.UserRoles.Any(ur => ur.RoleId == roleId))
                return false;

            user.UserRoles.Add(UserRole.Create(user.Id, roleId));

            return true;
        }

        public async Task<bool> RevokeRole(RoleType roleType, User user)
            => RevokeRole(await GetRoleId(roleType), user);

        public bool RevokeRole(string roleId, User user)
        {
            var userRole = user.UserRoles.FirstOrDefault(ur => ur.RoleId == roleId);

            if (userRole == null)
                return false;

            if (userRole.Role.RoleName == Utils.EnumToString<RoleType>(RoleType.User))
                return false;

            user.UserRoles.Remove(userRole);

            return true;
        }

        public async Task<bool> CreateRole(RoleType roleType)
        {
            if (await RoleExists(roleType))
                return false;

            var role = Role.Create(roleType);

            database.RoleRepository.Add(role);

            return await database.Complete();
        }

        public async Task<bool> IsPermitted(string userId, RoleType roleType)
            => await database.UserRoleRepository.Find(ur => ur.UserId == userId && ur.Role.RoleType == roleType) != null;

        public async Task<bool> RoleExists(RoleType roleType)
            => await database.RoleRepository.Find(r => r.RoleType == roleType) != null;

        public async Task<string> GetRoleId(RoleType roleType)
            => (await database.RoleRepository.Find(r => r.RoleName.ToLower() == Utils.EnumToString<RoleType>(roleType).ToLower()))?.Id;
    }
}