using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services
{
    public interface IOfferValidationService
    {
        bool ValidateOfferCreator(User user);
        bool ValidateOfferPhotosCount(int photosToUploadCount, Offer offer);
    }
}