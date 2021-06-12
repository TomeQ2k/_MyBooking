namespace MyBooking.Core.Models.Result
{
    public class GenerateChangeEmailTokenResult
    {
        public string UserId { get; }
        public string Code { get; }
        public string NewEmail { get; }

        public GenerateChangeEmailTokenResult(string userId, string code, string newEmail)
        {
            UserId = userId;
            Code = code;
            NewEmail = newEmail;
        }
    }
}