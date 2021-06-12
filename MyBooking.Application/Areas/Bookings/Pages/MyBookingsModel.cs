using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Extensions;
using MyBooking.Core.Entities;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Params;
using MyBooking.Infrastructure.Services.FilterServices.Filters.Bookings;
using MyBooking.Core.Services.FilterServices;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Bookings.Pages
{
    [Authorize]
    public class MyBookingsModel : BasePageModel
    {
        private readonly IBookingService bookingService;
        private readonly IBookingsFilterService bookingsFilterService;
        private readonly IMapper mapper;

        public PagedList<BookedDateDto> MyBookings { get; set; }

        [BindProperty]
        public BookingsFilterParams Params { get; set; } = new BookingsFilterParams();

        public MyBookingsModel(IBookingService bookingService, IBookingsFilterService bookingsFilterService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.bookingsFilterService = bookingsFilterService;
            this.mapper = mapper;

            Title = "Bookings";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] BookingsFilterParams filterParams, bool clearFilters = false)
        {
            if (clearFilters)
                FilterParamsContainer<BookingsFilterParams>.Clear();

            string currentUserId = HttpContext.GetCurrentUserId();

            var bookings = !filterParams.FilterEnabled
                ? await bookingService.GetBookedDates(currentUserId)
                : await bookingsFilterService.FilterBookings(filterParams, new FiltersDictionary<BookedDate>
                {
                    {new BookingDatesSpecification(filterParams.StartDate, filterParams.EndDate), new BookingDatesFilter()}
                }, currentUserId);

            Params = FilterParamsContainer<BookingsFilterParams>.Store(filterParams, updateParams: true);

            MyBookings = mapper.Map<List<BookedDateDto>>(bookings).ToPagedList<BookedDateDto>(filterParams.PageNumber, filterParams.PageSize);

            return Page();
        }

        public async Task<IActionResult> OnPostFilterBookingsAsync([Bind] BookingsFilterParams filterParams, bool updateParams = true)
            => await this.OnGetAsync(FilterParamsContainer<BookingsFilterParams>.Store(filterParams, updateParams: updateParams).EnableFiltering<BookingsFilterParams>());

        public async Task<IActionResult> OnPostCancelBookingAsync([FromQuery] string bookingId)
            => await bookingService.CancelBooking(bookingId)
                ? (IActionResult)RedirectToPage("/MyBookings", new { area = "Bookings" })
                : this.ErrorPage();
    }
}