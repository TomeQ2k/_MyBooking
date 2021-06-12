using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Dtos
{
    public class CreateOfferDto
    {
        [RequiredValidator]
        [StringLengthValidator(Constants.MaxTitleLength)]
        public string Title { get; set; }

        [RequiredValidator]
        [Range(0, (float)Constants.MaxPrice)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RequiredValidator]
        [StringLengthValidator(Constants.MaxLocationLength)]
        public string Location { get; set; }

        [RequiredValidator]
        [Range(1, Constants.MaxOffersCount)]
        public int TotalCount { get; set; }

        [RequiredValidator]
        public OfferDetailsDto OfferDetails { get; set; }

        [RequiredValidator]
        [MinLength(1, ErrorMessage = "At least one photo is required")]
        [MaxLength(Constants.MaxPhotosCount, ErrorMessage = "Maximum photos count is: 10")]
        public IEnumerable<IFormFile> OfferPhotos { get; set; } = new List<IFormFile>();
    }
}