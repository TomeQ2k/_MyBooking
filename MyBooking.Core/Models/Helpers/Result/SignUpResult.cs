using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Models.Helpers.Result
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