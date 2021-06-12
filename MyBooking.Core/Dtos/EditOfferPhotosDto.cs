using System.Collections.Generic;

namespace MyBooking.Core.Dtos
{
    public class EditOfferPhotosDto
    {
        public IEnumerable<OfferPhotoDto> OfferPhotos { get; set; } = new List<OfferPhotoDto>();
    }
}