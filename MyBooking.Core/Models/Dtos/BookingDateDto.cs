using System;
using System.ComponentModel.DataAnnotations;
using MyBooking.Core.Validators;

namespace MyBooking.Core.Models.Dtos
{
    public class BookingDateDto
    {
        [RequiredValidator]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [RequiredValidator]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [RequiredValidator]
        public string OfferId { get; set; }
    }
}