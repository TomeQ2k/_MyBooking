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
    public class CreateOfferModel : BasePageModel
    {
        private readonly IOfferService offerService;
        private readonly IMapper mapper;

        [BindProperty]
        public CreateOfferDto CreateOfferInput { get; set; } = new CreateOfferDto();

        public CreateOfferModel(IOfferService offerService, IMapper mapper)
        {
            this.offerService = offerService;
            this.mapper = mapper;

            Title = "Create offer";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var offerToCreate = mapper.Map<Offer>(CreateOfferInput);

            if (await offerService.CreateOffer(offerToCreate, CreateOfferInput.OfferPhotos))
                return RedirectToPage("/Index");

            Alertify.Push("Offer creating failed", AlertType.Error);
            return Page();
        }
    }
}