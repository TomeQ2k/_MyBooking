using MyBooking.Core.Entities;

namespace MyBooking.Core.Services
{
    public interface IOpinionValidationService
    {
        bool UserOpinionExists(User user, string offerId);
    }
}