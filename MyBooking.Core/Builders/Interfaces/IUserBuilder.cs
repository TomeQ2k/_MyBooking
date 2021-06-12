using MyBooking.Core.Entities;

namespace MyBooking.Core.Builders.Interfaces
{
    public interface IUserBuilder : IBuilder<User>
    {
        IUserBuilder SetUsername(string username);
        IUserBuilder SetEmail(string email);
        IUserBuilder SetPassword(string passwordHash, string passwordSalt);
    }
}