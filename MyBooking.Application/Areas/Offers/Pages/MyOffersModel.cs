using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Extensions;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Params;
using MyBooking.Core.Services;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.Areas.Offers.Pages
{
    [Authorize]
    public class MyOffersModel : BasePageModel
    {
        private readonly IOfferService offerService;
        private readonly IMapper mapper;

        public PagedList<MyOfferDto> MyOffers { get; private set; }

        [BindProperty]
        public OffersFilterParams FilterParams { get; set; } = new OffersFilterParams();

        public MyOffersModel(IOfferService offerService, IMapper mapper)
        {
            this.offerService = offerService;
            this.mapper = mapper;

            Title = "My offers";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] OffersFilterParams filterParams)
        {
            var myOffers = await offerService.GetUserOffers(HttpContext.GetCurrentUserId());

            MyOffers = mapper.Map<List<MyOfferDto>>(myOffers).ToPagedList<MyOfferDto>(filterParams.PageNumber, filterParams.PageSize);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteOfferAsync(string id)
        {
            if (!await offerService.DeleteOffer(id))
                Alertify.Push("Deleting offer failed", AlertType.Error);

            return await this.OnGetAsync(FilterParams);
        }

        public async Task<IActionResult> OnPostFilterOffers([Bind] OffersFilterParams filterParams)
            => await this.OnGetAsync(filterParams);
    }
}