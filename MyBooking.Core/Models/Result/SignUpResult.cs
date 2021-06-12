using MyBooking.Core.Entities;

namespace MyBooking.Core.Models.Result
{
    public class SignUpResult
    {
        public string Token { get; }
        public User User { get; }

        public SignUpResult(string token, User user)
        {
            Token = token;
            User = user;
        }
    }
}