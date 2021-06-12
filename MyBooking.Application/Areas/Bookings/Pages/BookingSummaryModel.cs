using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Extensions;
using MyBooking.Core.Dtos;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Bookings.Pages
{
    [AllowAnonymous]
    public class BookingSummaryModel : BasePageModel
    {
        private readonly IBookingService bookingService;
        private readonly IUserBookingCart userBookingCart;
        private readonly ISessionBookingCart sessionBookingCart;
        private readonly IMapper mapper;

        public BookedDateDto BookedDateModel { get; private set; }

        public BookingSummaryModel(IBookingService bookingService, IUserBookingCart userBookingCart, ISessionBookingCart sessionBookingCart, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.userBookingCart = userBookingCart;
            this.sessionBookingCart = sessionBookingCart;
            this.mapper = mapper;

            Title = "Booking summary";
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var bookedDate = await bookingService.GetBookedDate(id);

            if (bookedDate == null)
                return RedirectToPage("/Index");

            BookedDateModel = mapper.Map<BookedDateDto>(bookedDate);

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync([FromQuery] string bookedDateId)
        {
            var bookedDate = await bookingService.GetBookedDate(bookedDateId);

            if (bookedDate == null)
                this.ErrorPage();

            var bookingCartItem = HttpContext.IsAuthenticated()
            ? await userBookingCart.AddToCart(bookedDate)
            : await sessionBookingCart.AddToCart(bookedDate);

            return bookingCartItem != null
                ? (IActionResult)RedirectToPage("/Cart", new { area = "Cart" })
                : this.ErrorPage();
        }

        public async Task<IActionResult> OnPostCancelBookingAsync(string id)
            => await bookingService.CancelBooking(id)
                ? (IActionResult)RedirectToPage("/Index")
                : this.ErrorPage();
    }
}