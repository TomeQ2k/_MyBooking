using MyBooking.Core.Models.Dtos;

namespace MyBooking.Application.ViewModels
{
    public class OfferCardViewModel
    {
        public OfferListDto Offer { get; }

        public bool IsDetails { get; }
        public bool IsFavorites { get; }

        public OfferCardViewModel(OfferListDto offer, bool isDetails = false, bool isFavorites = false)
        {
            Offer = offer;
            IsDetails = isDetails;
            IsFavorites = isFavorites;
        }
    }
}