using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Enums;
using MyBooking.Core.Extensions;
using MyBooking.Core.Models.Dtos;
using MyBooking.Core.Services;
using MyBooking.Core.Services.ReadOnly;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.Areas.Offers.Pages
{
    public class OfferDetailsModel : BasePageModel
    {
        private readonly IReadOnlyOfferService offerService;
        private readonly IBookingService bookingService;
        private readonly IOpinionService opinionService;
        private readonly IBookingValidationService bookingValidationService;
        private readonly IRatingManager ratingManager;
        private readonly IMapper mapper;

        public OfferDto Offer { get; private set; }
        public OfferListDto OfferCardModel { get; private set; }
        public OfferDetailsDto OfferDetails { get; private set; }

        public BookingDateDto BookingDateModel { get; set; }
        public CreateOpinionDto CreateOpinionModel { get; set; }

        public OfferDetailsModel(IReadOnlyOfferService offerService, IBookingService bookingService, IOpinionService opinionService,
            IBookingValidationService bookingValidationService, IRatingManager ratingManager, IMapper mapper)
        {
            this.offerService = offerService;
            this.bookingService = bookingService;
            this.opinionService = opinionService;
            this.bookingValidationService = bookingValidationService;
            this.ratingManager = ratingManager;
            this.mapper = mapper;

            Title = "Offer";
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var offer = await offerService.GetOffer(id);

            if (offer == null)
                return RedirectToPage("/Index");

            Offer = mapper.Map<OfferDto>(offer);
            OfferCardModel = mapper.Map<OfferListDto>(offer);
            OfferDetails = mapper.Map<OfferDetailsDto>(offer.OfferDetails);

            return Page();
        }

        public async Task<IActionResult> OnPostBookDateAsync([Bind] BookingDateDto bookingDateModel)
        {
            string offerId = bookingDateModel.OfferId;

            if (!ModelState.IsValid)
                return await this.OnGetAsync(offerId);

            if (!bookingValidationService.ValidateDates(bookingDateModel.StartDate, bookingDateModel.EndDate))
            {
                Alertify.Push("End date must be greater than start date", AlertType.Error);
                return await this.OnGetAsync(offerId);
            }

            var bookedDate = await bookingService.BookDate(bookingDateModel.StartDate, bookingDateModel.EndDate, offerId);

            return bookedDate != null
                ? (IActionResult)RedirectToPage("/BookingSummary", new { area = "Bookings", id = bookedDate.Id })
                : await this.OnGetAsync(offerId);
        }

        public async Task<IActionResult> OnPostCreateOpinionAsync([Bind] CreateOpinionDto createOpinionModel)
        {
            string offerId = createOpinionModel.OfferId;

            if (!ModelState.IsValid)
                return await this.OnGetAsync(offerId);

            var opinionCreated = await opinionService.CreateOpinion(createOpinionModel.Text, offerId);

            if (opinionCreated == null)
                return await this.OnGetAsync(offerId);

            var offerRateAdded = await ratingManager.AddOfferRate(createOpinionModel.Rating, opinionCreated.Id, opinionCreated.UserId);

            if (!offerRateAdded)
            {
                await opinionService.DeleteOpinion(opinionCreated.Id, opinionCreated.UserId);

                Alertify.Push("Creating opinion failed", AlertType.Error);
                return await this.OnGetAsync(offerId);
            }

            return RedirectToPage("/OfferDetails", new { area = "Offers", id = offerId });
        }

        public async Task<IActionResult> OnPostDeleteOpinionAsync([FromQuery] string opinionId, string offerId)
            => await opinionService.DeleteOpinion(opinionId, HttpContext.GetCurrentUserId())
                ? (IActionResult)RedirectToPage("/OfferDetails", new { area = "Offers", id = offerId })
                : this.ErrorPage();

        #region methods

        public string GetAccommodationType()
        {
            if (OfferDetails == null)
                return string.Empty;

            switch (OfferDetails.AccommodationType)
            {
                case AccommodationType.WithoutFood:
                    return "Without food";
                case AccommodationType.OnlyBreakfast:
                    return "Only breakfast";
                case AccommodationType.BreakfastAndDinner:
                    return "Breakfast & dinner";
                case AccommodationType.AllInclusive:
                    return "All inclusive";
                default: return string.Empty;
            }
        }

        #endregion
    }
}