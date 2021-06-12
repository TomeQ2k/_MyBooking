using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Extensions;
using MyBooking.Core.Entities;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Params;
using MyBooking.Infrastructure.Services.FilterServices.Filters.Offers;
using MyBooking.Core.Services.ReadOnly;
using MyBooking.Core.Services.FilterServices;

namespace MyBooking.Application.Areas.Offers.Pages
{
    [Authorize]
    public class FavoritesModel : BasePageModel
    {
        private readonly IReadOnlyFavoritesService favoritesService;
        private readonly IOffersFilterService offersFilterService;
        private readonly IMapper mapper;

        public PagedList<OfferListDto> FavoriteOffers { get; private set; }

        [BindProperty]
        public OffersFilterParams Params { get; set; } = new OffersFilterParams();

        public FavoritesModel(IReadOnlyFavoritesService favoritesService, IOffersFilterService offersFilterService, IMapper mapper)
        {
            this.favoritesService = favoritesService;
            this.offersFilterService = offersFilterService;
            this.mapper = mapper;

            Title = "Favorites";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] OffersFilterParams filterParams, bool clearFilters = false)
        {
            if (clearFilters)
                FilterParamsContainer<OffersFilterParams>.Clear();

            string currentUserId = HttpContext.GetCurrentUserId();

            var favoriteOffers = await (!filterParams.FilterEnabled
                ? favoritesService.GetFavoriteOffers(currentUserId)
                : offersFilterService.FilterOffers(filterParams, new FiltersDictionary<Offer>
                {
                    {new OfferPriceSpecification(filterParams.MinPrice, filterParams.MaxPrice), new OfferPriceFilter()},
                    {new OfferLocationSpecification(filterParams.Location), new OfferLocationFilter()},
                    {new OfferRoomsSpecification(filterParams.RoomsCount), new OfferRoomsFilter()},
                    {new OfferPersonsSpecification(filterParams.PersonsCount), new OfferPersonsFilter()},
                    {new OfferDatesSpecification(filterParams.StartDate, filterParams.EndDate), new OfferDatesFilter()},
                    {new OfferFavoriteSpecification(currentUserId), new OfferFavoriteFilter()}
                }));

            Params = FilterParamsContainer<OffersFilterParams>.Store(filterParams, updateParams: true);

            FavoriteOffers = mapper.Map<List<OfferListDto>>(favoriteOffers).ToPagedList<OfferListDto>(filterParams.PageNumber, filterParams.PageSize);

            return Page();
        }

        public async Task<IActionResult> OnPostFilterOffersAsync([Bind] OffersFilterParams filterParams, bool updateParams = true)
            => await this.OnGetAsync(FilterParamsContainer<OffersFilterParams>.Store(filterParams, updateParams: updateParams).EnableFiltering<OffersFilterParams>());
    }
}