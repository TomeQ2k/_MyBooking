using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Models.Dtos;
using MyBooking.Core.Services.ReadOnly;
using MyBooking.Core.Models.Helpers;
using MyBooking.Core.Params;
using MyBooking.Core.Models.Domain;
using MyBooking.Infrastructure.Services.FilterServices.Filters.Offers;
using System.Threading.Tasks;
using MyBooking.Core.Services.FilterServices;
using MyBooking.Core.Extensions;

namespace MyBooking.Application.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly IReadOnlyOfferService offerService;
        private readonly IOffersFilterService offersFilterService;
        private readonly IMapper mapper;

        public PagedList<OfferListDto> Offers { get; private set; }

        [BindProperty]
        public OffersFilterParams Params { get; set; } = new OffersFilterParams();

        public IndexModel(IReadOnlyOfferService offerService, IOffersFilterService offersFilterService, IMapper mapper)
        {
            this.offerService = offerService;
            this.offersFilterService = offersFilterService;
            this.mapper = mapper;

            Title = "Home";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] OffersFilterParams filterParams, bool clearFilters = false)
        {
            if (clearFilters)
                FilterParamsContainer<OffersFilterParams>.Clear();

            var offers = !filterParams.FilterEnabled
                ? await offerService.GetOffers()
                : await offersFilterService.FilterOffers(filterParams, new FiltersDictionary<Offer>
                {
                    {new OfferPriceSpecification(filterParams.MinPrice, filterParams.MaxPrice), new OfferPriceFilter()},
                    {new OfferLocationSpecification(filterParams.Location), new OfferLocationFilter()},
                    {new OfferRoomsSpecification(filterParams.RoomsCount), new OfferRoomsFilter()},
                    {new OfferPersonsSpecification(filterParams.PersonsCount), new OfferPersonsFilter()},
                    {new OfferDatesSpecification(filterParams.StartDate, filterParams.EndDate), new OfferDatesFilter()}
                });

            Params = FilterParamsContainer<OffersFilterParams>.Store(filterParams, updateParams: true);

            Offers = mapper.Map<List<OfferListDto>>(offers).ToPagedList<OfferListDto>(filterParams.PageNumber, filterParams.PageSize);

            return Page();
        }

        public async Task<IActionResult> OnPostFilterOffersAsync([Bind] OffersFilterParams filterParams, bool updateParams = true)
            => await this.OnGetAsync(FilterParamsContainer<OffersFilterParams>.Store(filterParams, updateParams: updateParams).EnableFiltering<OffersFilterParams>());
    }
}