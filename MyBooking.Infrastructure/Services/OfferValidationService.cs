using System;
using System.Linq;
using MyBooking.Core.Data;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class OfferValidationService : BaseValidationService, IOfferValidationService
    {
        public OfferValidationService(IDatabase database) : base(database) { }

        public bool ValidateOfferCreator(User user)
            => user != null ? user.Offers.Any(o => o.CreatorId == user.Id) : throw new ArgumentNullException();

        public bool ValidateOfferPhotosCount(int photosToUploadCount, Offer offer)
        {
            if (offer == null)
                throw new ArgumentNullException();

            int photosCount = offer.OfferPhotos.Count + photosToUploadCount;

            return photosCount > 0 && photosCount <= Constants.MaxPhotosCount;
        }
    }
}