using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class OfferDetailsDto
    {
        [RequiredValidator]
        [StringLengthValidator(Constants.MaxDescriptionLength)]
        public string Description { get; set; }

        [Range(0, Constants.MaxRoomsCount)]
        public int RoomsCount { get; set; }

        [Range(1, Constants.MaxPersonsCount)]
        public int PersonsCount { get; set; }

        public bool HasBathroom { get; set; }

        public bool HasKitchen { get; set; }

        public bool HasWifi { get; set; }

        public bool HasBalcony { get; set; }

        public bool HasTV { get; set; }

        public bool HasMinibar { get; set; }

        public AccommodationType AccommodationType { get; set; }

        [RequiredValidator]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}