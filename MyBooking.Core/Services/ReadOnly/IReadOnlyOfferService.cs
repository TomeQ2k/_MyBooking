using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooking.Core.Entities;

namespace MyBooking.Core.Services.ReadOnly
{
    public interface IReadOnlyOfferService
    {
        Task<Offer> GetOffer(string id);

        Task<IEnumerable<Offer>> GetOffers();
        Task<IEnumerable<Offer>> GetUserOffers(string creatorId);
    }
}