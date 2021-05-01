using System;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class TokenManager : ITokenManager
    {
        private readonly IDatabase database;

        public TokenManager(IDatabase database)
        {
            this.database = database;
        }

        public async Task<bool> ClearExpiredTokens()
        {
            var tokensToDelete = await database.TokenRepository.Filter(t => t.DateCreated.AddDays(Constants.TokenExpirationTimeInDays) < DateTime.Now);

            database.TokenRepository.DeleteRange(tokensToDelete);

            return await database.Complete();
        }
    }
}