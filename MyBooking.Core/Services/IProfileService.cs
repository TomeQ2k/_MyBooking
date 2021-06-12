using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Models.Result;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IProfileService : IReadOnlyProfileService
    {
        Task<User> ChangeUsername(string newUsername);
        Task<bool> ChangePassword(string oldPassword, string newPassword);
        Task<bool> ChangeEmail(string userId, string newEmail, string code);

        Task<GenerateChangeEmailTokenResult> GenerateChangeEmailToken(string newEmail);
    }
}