using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;
using MyBooking.Core.Services;
using MyBooking.Core.Services.FilterServices.Filters;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Infrastructure.Services
{
    public class OfferService : IOfferService
    {
        private readonly IDatabase database;
        private readonly IReadOnlyProfileService profileService;
        private readonly IFilesManager filesManager;
        private readonly IOfferValidationService offerValidationService;
        private readonly IEnumerable<IFilter<Offer>> offerFilters;

        public OfferService(IDatabase database, IReadOnlyProfileService profileService, IFilesManager filesManager,
            IOfferValidationService offerValidationService, IEnumerable<IFilter<Offer>> offerFilters)
        {
            this.database = database;
            this.profileService = profileService;
            this.filesManager = filesManager;
            this.offerValidationService = offerValidationService;
            this.offerFilters = offerFilters;
        }

        public async Task<Offer> GetOffer(string id) => await database.OfferRepository.FindById(id);

        public async Task<IEnumerable<Offer>> GetOffers()
            => (await database.OfferRepository.GetAll())
                .OrderByDescending(o => o.DateCreated);

        public async Task<IEnumerable<Offer>> GetUserOffers(string creatorId)
            => (await database.OfferRepository.GetWhere(o => o.CreatorId == creatorId))
                .OrderBy(o => o.DateCreated);

        public async Task<bool> CreateOffer(Offer offer, IEnumerable<IFormFile> offerPhotos)
        {
            if (offer == null)
                return false;

            var currentUser = await profileService.GetCurrentUser();

            if (currentUser == null)
                return false;

            currentUser.Offers.Add(offer);

            offer.SetDetailsId(offer.OfferDetails.Id);
            offer.OfferDetails.SetOfferId(offer.Id);

            if (!await database.Complete())
                return false;

            if (offerPhotos != null)
            {
                var uploadedPhotos = await filesManager.Upload(offerPhotos, $"offers/{offer.Id}");
                uploadedPhotos.ToList().ForEach(photo =>
                    offer.OfferPhotos.Add(OfferPhoto.Create<OfferPhoto>(photo.Path).SetOfferId(offer.Id)));
            }

            return await database.Complete();
        }

        public async Task<bool> UpdateOffer(Offer offer, IEnumerable<IFormFile> offerPhotos)
        {
            if (offer == null)
                return false;

            var currentUser = await profileService.GetCurrentUser();

            if (currentUser == null)
                return false;

            if (!offerValidationService.ValidateOfferCreator(currentUser))
                return false;

            var previousOffer = currentUser.Offers.FirstOrDefault(o => o.Id == offer.Id);

            if (previousOffer == null)
                return false;

            if (offerPhotos != null && offerValidationService.ValidateOfferPhotosCount(offerPhotos.Count(), offer))
            {
                var uploadedPhotos = await filesManager.Upload(offerPhotos, $"offers/{offer.Id}");
                uploadedPhotos.ToList().ForEach(photo =>
                    offer.OfferPhotos.Add(OfferPhoto.Create<OfferPhoto>(photo.Path).SetOfferId(offer.Id)));
            }

            database.OfferRepository.Update(offer);

            return await database.Complete();
        }

        public async Task<bool> DeleteOffer(string offerId)
        {
            var offer = await database.OfferRepository.FindById(offerId);

            if (offer == null)
                return false;

            var currentUser = await profileService.GetCurrentUser();

            if (currentUser == null)
                return false;

            if (offer.CreatorId != currentUser.Id)
                return false;

            database.OfferRepository.Delete(offer);

            if (!await database.Complete())
                return false;

            filesManager.DeleteDirectory($"files/offers/{offer.Id}");

            return true;
        }

        public async Task<bool> RemovePhoto(string photoId)
        {
            var photo = await database.OfferPhotoRepository.FindById(photoId);

            if (photo == null)
                return false;

            if (!offerValidationService.ValidateOfferPhotosCount(-1, photo.Offer))
            {
                Alertify.Push("At least one photo is required", AlertType.Warning);
                return false;
            }

            database.OfferPhotoRepository.Delete(photo);

            if (!await database.Complete())
            {
                Alertify.Push("Removing photo failed", AlertType.Error);
                return false;
            }

            filesManager.Delete(photo.Path);

            return true;
        }
    }
}