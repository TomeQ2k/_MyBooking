using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Entities;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Offers.Pages
{
    [Authorize]
    public class EditOfferModel : BasePageModel
    {
        private readonly IOfferService offerService;
        private readonly IMapper mapper;

        [BindProperty]
        public EditOfferDto EditOfferInput { get; set; }

        public EditOfferPhotosDto EditOfferPhotosInput { get; set; }

        public EditOfferModel(IOfferService offerService, IMapper mapper)
        {
            this.offerService = offerService;
            this.mapper = mapper;

            Title = "Edit offer";
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var offer = await offerService.GetOffer(id);

            if (offer == null)
                return RedirectToPage("/Index");

            EditOfferInput = mapper.Map<EditOfferDto>(offer);
            EditOfferPhotosInput = new EditOfferPhotosDto { OfferPhotos = mapper.Map<IEnumerable<OfferPhotoDto>>(offer.OfferPhotos) };

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateOfferAsync()
        {
            if (!ModelState.IsValid)
            {
                Alertify.Push("Offer updating failed", AlertType.Error);
                return await this.OnGetAsync(EditOfferInput.Id);
            }

            var offer = await offerService.GetOffer(EditOfferInput.Id);
            var offerToUpdate = mapper.Map<EditOfferDto, Offer>(EditOfferInput, offer);

            if (await offerService.UpdateOffer(offerToUpdate, EditOfferInput.OfferPhotos))
                return RedirectToPage("/MyOffers", new { area = "Offers" });

            Alertify.Push("Offer updating failed", AlertType.Error);
            return await this.OnGetAsync(EditOfferInput.Id);
        }

        public async Task<IActionResult> OnPostRemovePhotoAsync([FromQuery] string offerId, string photoId)
        {
            await offerService.RemovePhoto(photoId);

            return await this.OnGetAsync(offerId);
        }
    }
}