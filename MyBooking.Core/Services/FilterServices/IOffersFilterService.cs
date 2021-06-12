using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;
using MyBooking.Core.Models;
using MyBooking.Core.Params;

namespace MyBooking.Core.Services.FilterServices
{
    public interface IOffersFilterService
    {
        Task<IEnumerable<Offer>> FilterOffers(OffersFilterParams filterParams, FiltersDictionary<Offer> filtersDictionary);
    }
}