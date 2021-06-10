using System.Threading.Tasks;
using MyBooking.Application.BackgroundServices.Interfaces;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Application.BackgroundServices
{
    public class DatabaseManager : IDatabaseManager
    {
        private readonly IRolesService rolesService;

        public DatabaseManager(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public async Task Seed()
        {
            await InsertRoles();
        }

        #region private

        private async Task InsertRoles()
        {
            foreach (var roleName in Constants.RolesToSeed)
                await rolesService.CreateRole(roleName);
        }

        #endregion
    }
}