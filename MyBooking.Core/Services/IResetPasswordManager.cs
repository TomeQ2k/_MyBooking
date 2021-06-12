using System.Threading.Tasks;
using MyBooking.Core.Models.Result;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IResetPasswordManager : IReadOnlyResetPasswordManager
    {
        Task<bool> ResetPassword(string userId, string code, string newPassword);
        Task<SendResetPasswordResult> GenerateResetPasswordToken(string email);
    }
}