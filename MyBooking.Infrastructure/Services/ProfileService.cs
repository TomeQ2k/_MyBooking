using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Models.Helpers.Result;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IDatabase database;
        private readonly IHashGenerator hashGenerator;
        private readonly IHttpContextReader httpContextReader;

        public ProfileService(IDatabase database, IHashGenerator hashGenerator, IHttpContextReader httpContextReader)
        {
            this.database = database;
            this.hashGenerator = hashGenerator;
            this.httpContextReader = httpContextReader;
        }

        public async Task<User> GetCurrentUser() => await database.UserRepository.Get(httpContextReader.CurrentUserId);

        public async Task<User> ChangeUsername(string newUsername)
        {
            var user = await GetCurrentUser();

            if (user == null)
                return null;

            user.SetUsername(newUsername);

            database.UserRepository.Update(user);

            return await database.Complete() ? user : null;
        }

        public async Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            var user = await GetCurrentUser();

            if (!hashGenerator.VerifyHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                Alertify.Push("Old password is invalid", AlertType.Error);
                return false;
            }

            string saltedPasswordHash = string.Empty;
            var passwordSalt = hashGenerator.CreateSalt();

            hashGenerator.GenerateHash(newPassword, passwordSalt, out saltedPasswordHash);

            user.SetPassword(saltedPasswordHash, passwordSalt);

            return await database.Complete();
        }

        public async Task<bool> ChangeEmail(string userId, string newEmail, string code)
        {
            var user = await GetCurrentUser();

            if (user == null || user?.Id != userId)
                return false;

            var changeEmailToken = user.Tokens.FirstOrDefault(t => t.Code == code);

            if (changeEmailToken == null)
                return false;

            user.SetEmail(newEmail);

            database.UserRepository.Update(user);
            database.TokenRepository.Delete(changeEmailToken);

            return await database.Complete();
        }

        public async Task<GenerateChangeEmailTokenResult> GenerateChangeEmailToken(string newEmail)
        {
            var user = await GetCurrentUser();

            if (user == null)
                return null;

            var changeEmailToken = Token.Create(TokenType.ChangeEmail);

            user.Tokens.Add(changeEmailToken);

            return await database.Complete() ? new GenerateChangeEmailTokenResult(user.Id, changeEmailToken.Code, newEmail) : null;
        }
    }
}