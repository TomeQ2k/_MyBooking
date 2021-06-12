namespace MyBooking.Core.Models.Result
{
    public class SendResetPasswordResult
    {
        public string Code { get; }
        public string UserId { get; }
        public string Username { get; }
        public string Email { get; }

        public SendResetPasswordResult(string code, string userId, string username, string email)
        {
            Code = code;
            UserId = userId;
            Username = username;
            Email = email;
        }
    }
}