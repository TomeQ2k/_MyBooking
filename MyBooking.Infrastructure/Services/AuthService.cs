using System.Threading.Tasks;
using MyBooking.Core.Builders;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;
using MyBooking.Core.Models.Result;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDatabase database;
        private readonly IHashGenerator hashGenerator;

        public AuthService(IDatabase database, IHashGenerator hashGenerator)
        {
            this.database = database;
            this.hashGenerator = hashGenerator;
        }

        public async Task<User> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Alertify.Push("Invalid email address or password", AlertType.Error);
                return null;
            }

            var user = await database.UserRepository.Find(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                Alertify.Push("Invalid email address or password", AlertType.Error);
                return null;
            }

            if (!user.EmailConfirmed)
            {
                Alertify.Push("Account is not confirmed", AlertType.Warning);
                return null;
            }

            if (hashGenerator.VerifyHash(password, user.PasswordHash, user.PasswordSalt))
                return user;

            Alertify.Push("Invalid email address or password", AlertType.Error);
            return null;
        }

        public async Task<SignUpResult> SignUp(string email, string password, string username)
        {
            string saltedPasswordHash = string.Empty;
            var passwordSalt = hashGenerator.CreateSalt();

            hashGenerator.GenerateHash(password, passwordSalt, out saltedPasswordHash);

            var user = new UserBuilder()
                .SetUsername(username)
                .SetEmail(email)
                .SetPassword(saltedPasswordHash, passwordSalt)
                .Build();

            database.UserRepository.Add(user);

            if (await database.Complete())
            {
                var registerToken = Token.Create(TokenType.Register);

                database.TokenRepository.Add(registerToken);

                //Logic adding user to USER role

                if (await database.Complete())
                    return new SignUpResult(registerToken.Code, user);

                Alertify.Push("Creating register token failed", AlertType.Error);
                return null;
            }

            Alertify.Push("Creating account failed", AlertType.Error);
            return null;
        }

        public async Task<bool> ConfirmAccount(string userId, string code)
        {
            var user = await database.UserRepository.Get(userId);
            var registerToken = await database.TokenRepository.Find(t => t.Code == code && t.TokenType == TokenType.Register);

            if (user == null || registerToken == null)
                return false;

            user.Confirm();

            if (await database.Complete())
            {
                database.TokenRepository.Delete(registerToken);

                return await database.Complete();
            }

            return false;
        }
    }
}