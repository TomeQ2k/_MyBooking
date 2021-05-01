using System.Linq;
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

        public void Seed()
        {
            InsertRoles();
        }

        #region private

        private void InsertRoles()
        {
            Constants.RoleTypes.ToList().ForEach((roleType) =>
            {
                rolesService.CreateRole(roleType).Wait();
            });
        }

        #endregion
    }
}