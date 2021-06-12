using System.Collections.Generic;

namespace MyBooking.Core.Dtos
{
    public class OfferListDto : BaseOfferDto
    {
        public int PersonsCount { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstPhotoUrl { get; set; }

        public List<OfferFollowDto> OfferFollows { get; set; }
    }
}