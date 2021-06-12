using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class RolesService : IRolesService
    {
        private readonly IDatabase database;

        public RolesService(IDatabase database)
        {
            this.database = database;
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
    }
}