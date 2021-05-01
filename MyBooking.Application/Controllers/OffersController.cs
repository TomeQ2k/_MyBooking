using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Services;

namespace MyBooking.Application.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private readonly IFavoritesService favoritesService;

        public OffersController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        [HttpPost]
        public async Task<IActionResult> Follow(string id, [FromQuery] bool isDetails = false, bool isFavorites = false)
        {
            if (!await favoritesService.FollowOffer(id))
                return this.ErrorPage();

            if (isDetails)
                return RedirectToPage("/OfferDetails", new { area = "Offers", id = id });
            if (isFavorites)
                return RedirectToPage("/Favorites", new { area = "Offers" });

            return RedirectToPage("/Index");
        }
    }
}