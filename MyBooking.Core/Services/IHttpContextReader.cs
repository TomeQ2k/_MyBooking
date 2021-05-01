namespace MyBooking.Core.Services
{
    public interface IHttpContextReader
    {
        string CurrentUserId { get; }
    }
}