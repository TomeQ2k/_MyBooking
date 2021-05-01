using System;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class UserManager : IUserManager
    {
        private readonly IDatabase database;

        public UserManager(IDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> ClearNotConfirmedUsers()
        {
            var usersToDelete = await database.UserRepository.Filter(u => !u.EmailConfirmed && u.DateRegistered.AddDays(1) < DateTime.Now);

            database.UserRepository.DeleteRange(usersToDelete);

            return await database.Complete();
        }
    }
}