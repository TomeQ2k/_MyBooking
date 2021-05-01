using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Data;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Models.Helpers;
using MyBooking.Core.Params;
using MyBooking.Core.Services.FilterServices;
using MyBooking.Core.SmartEnums;

namespace MyBooking.Infrastructure.Services.FilterServices
{
    public class OffersFilterService : BaseFilterService, IOffersFilterService
    {
        public OffersFilterService(IDatabase database) : base(database) { }

        public async Task<IEnumerable<Offer>> FilterOffers(OffersFilterParams filterParams, FiltersDictionary<Offer> filtersDictionary)
        {
            if (!filterParams.FilterEnabled)
                return null;

            var offers = await database.OfferRepository.Fetch();

            offers = filtersDictionary.RunFilters(offers);

            offers = AccommodationTypeSmartEnum.FromValue((int)filterParams.AccommodationType).Filter(offers);

            offers = OfferSortTypeSmartEnum.FromValue((int)filterParams.SortType).Sort(offers);

            return offers;
        }
    }
}