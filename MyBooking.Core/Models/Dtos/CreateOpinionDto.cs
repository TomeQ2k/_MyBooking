using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Helpers;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Models.Dtos
{
    public class CreateOpinionDto
    {
        [RequiredValidator]
        [StringLengthValidator(Constants.MaxOpinionLength)]
        public string Text { get; set; }

        [RequiredValidator]
        [Range(1, 5, ErrorMessage = "Rating must be a value between 1 and 5")]
        public double Rating { get; set; }

        [RequiredValidator]
        public string OfferId { get; set; }
    }
}