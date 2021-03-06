using System.Collections.Generic;

namespace MyBooking.Core.Dtos
{
    public class OfferDto : BaseOfferDto
    {
        public OfferDetailsDto OfferDetails { get; set; }

        public List<OpinionDto> Opinions { get; set; }
        public List<OfferPhotoDto> OfferPhotos { get; set; }
    }
}
