using System.Threading.Tasks;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyResetPasswordManager
    {
        Task<bool> VerifyResetPasswordToken(string userId, string code);
    }
}