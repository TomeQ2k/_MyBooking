using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Extensions;
using MyBooking.Core.Models.Dtos;
using MyBooking.Core.Params;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Application.Areas.Orders.Pages
{
    [Authorize]
    public class OrdersModel : BasePageModel
    {
        private readonly IReadOnlyBookingOrderService bookingOrderService;
        private readonly IMapper mapper;

        public List<BookingOrderDto> Orders { get; set; }

        public OrdersModel(IReadOnlyBookingOrderService bookingOrderService, IMapper mapper)
        {
            this.bookingOrderService = bookingOrderService;
            this.mapper = mapper;

            Title = "Orders";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] BookingOrdersFilterParams filterParams)
        {
            var orders = await bookingOrderService.FetchOrders(HttpContext.GetCurrentUserId(), filterParams);

            Orders = mapper.Map<List<BookingOrderDto>>(orders);

            return Page();
        }

        public async Task<IActionResult> OnPostFilterOrdersAsync([Bind] BookingOrdersFilterParams filterParams)
           => await this.OnGetAsync(filterParams.EnableFiltering<BookingOrdersFilterParams>());
    }
}