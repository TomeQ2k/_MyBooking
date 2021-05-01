using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyBooking.Core.Models.Domain;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IOfferService : IReadOnlyOfferService
    {
        Task<bool> CreateOffer(Offer offer, IEnumerable<IFormFile> offerPhotos);
        Task<bool> UpdateOffer(Offer offer, IEnumerable<IFormFile> offerPhotos);
        Task<bool> DeleteOffer(string offerId);

        Task<bool> RemovePhoto(string photoId);
    }
}