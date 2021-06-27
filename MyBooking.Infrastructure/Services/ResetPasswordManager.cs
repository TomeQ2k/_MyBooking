using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Models.Result;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class ResetPasswordManager : IResetPasswordManager
    {
        private readonly IDatabase database;
        private readonly IHashGenerator hashGenerator;

        public ResetPasswordManager(IDatabase database, IHashGenerator hashGenerator)
        {
            this.database = database;
            this.hashGenerator = hashGenerator;
        }

        public async Task<bool> ResetPassword(string userId, string code, string newPassword)
        {
            var user = await database.UserRepository.FindById(userId);

            if (user == null)
                return false;

            var resetPasswordToken = user.Tokens.FirstOrDefault(t => t.Code == code && t.TokenType == TokenType.ResetPassword);

            if (resetPasswordToken == null)
                return false;

            string saltedPasswordHash = string.Empty;
            var passwordSalt = hashGenerator.CreateSalt();

            hashGenerator.GenerateHash(newPassword, passwordSalt, out saltedPasswordHash);

            user.SetPassword(saltedPasswordHash, passwordSalt);

            if (await database.Complete())
            {
                database.TokenRepository.Delete(resetPasswordToken);

                return await database.Complete();
            }

            return false;
        }

        public async Task<SendResetPasswordResult> GenerateResetPasswordToken(string email)
        {
            var user = await database.UserRepository.Find(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
                return null;

            var resetPasswordToken = Token.Create(TokenType.ResetPassword);

            user.Tokens.Add(resetPasswordToken);

            return await database.Complete()
                ? new SendResetPasswordResult(resetPasswordToken.Code, user.Id, user.Username, email)
                : null;
        }

        public async Task<bool> VerifyResetPasswordToken(string userId, string code)
        {
            var user = await database.UserRepository.FindById(userId);

            if (user == null)
                return false;

            var resetPasswordToken = user.Tokens.FirstOrDefault(t => t.Code == code && t.TokenType == TokenType.ResetPassword);

            return resetPasswordToken != null;
        }
    }
}