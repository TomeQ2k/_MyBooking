using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Entities;
using MyBooking.Core.Services;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Infrastructure.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IDatabase database;
        private readonly IReadOnlyProfileService profileService;

        public FavoritesService(IDatabase database, IReadOnlyProfileService profileService)
        {
            this.database = database;
            this.profileService = profileService;
        }

        public async Task<IEnumerable<Offer>> GetFavoriteOffers(string userId)
            => await database.OfferRepository.GetFavoriteOffers(userId);

        public async Task<bool> FollowOffer(string offerId)
        {
            var currentUser = await profileService.GetCurrentUser();

            if (currentUser == null)
                return false;

            var offer = await database.OfferRepository.FindById(offerId);

            if (offer == null)
                return false;

            var offerFollow = offer.OfferFollows.FirstOrDefault(of => of.UserId == currentUser.Id);

            if (offerFollow != null)
                database.OfferFollowRepository.Delete(offerFollow);
            else
            {
                offerFollow = OfferFollow.Create(offer.Id, currentUser.Id);
                database.OfferFollowRepository.Add(offerFollow);
            }

            return await database.Complete();
        }
    }
}