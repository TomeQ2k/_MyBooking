using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services
{
    public interface IOpinionValidationService
    {
        bool UserOpinionExists(User user, string offerId);
    }
}