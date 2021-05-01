using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Enums;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Infrastructure.Services
{
    public class OpinionService : IOpinionService
    {
        private readonly IDatabase database;
        private readonly IOpinionValidationService opinionValidationService;
        private readonly IReadOnlyProfileService profileService;

        public OpinionService(IDatabase database, IOpinionValidationService opinionValidationService, IReadOnlyProfileService profileService)
        {
            this.database = database;
            this.opinionValidationService = opinionValidationService;
            this.profileService = profileService;
        }

        public async Task<Opinion> CreateOpinion(string text, string offerId)
        {
            var currentUser = await profileService.GetCurrentUser();

            if (currentUser == null)
                return null;

            if (opinionValidationService.UserOpinionExists(currentUser, offerId))
            {
                Alertify.Push("Your opinion on this offer already exists", AlertType.Warning);
                return null;
            }

            var offer = await database.OfferRepository.Get(offerId);

            if (offer == null)
                return null;

            if (offer.CreatorId == currentUser.Id)
            {
                Alertify.Push("You are not allowed to create opinion on your own offer", AlertType.Error);
                return null;
            }

            var opinion = Opinion.Create(text);

            offer.Opinions.Add(opinion);
            currentUser.Opinions.Add(opinion);

            return await database.Complete() ? opinion : null;
        }

        public async Task<bool> DeleteOpinion(string opinionId, string userId)
        {
            var opinion = await database.OpinionRepository.Find(o => o.Id == opinionId && o.UserId == userId);

            if (opinion == null)
                return false;

            database.OpinionRepository.Delete(opinion);

            return await database.Complete();
        }
    }
}