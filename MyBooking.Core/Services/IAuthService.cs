using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Models.Result;

namespace MyBooking.Core.Services
{
    public interface IAuthService
    {
        Task<User> SignIn(string email, string password);
        Task<SignUpResult> SignUp(string email, string password, string username);

        Task<bool> ConfirmAccount(string userId, string code);
    }
}