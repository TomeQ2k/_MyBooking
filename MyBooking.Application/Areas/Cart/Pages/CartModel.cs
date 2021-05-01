using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Enums;
using MyBooking.Core.Extensions;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models.Dtos;
using MyBooking.Core.Services;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.Areas.Cart.Pages
{
    public class CartModel : BasePageModel
    {
        private readonly IUserBookingCart userBookingCart;
        private readonly ISessionBookingCart sessionBookingCart;
        private readonly IBookingOrderService orderService;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public List<BookingCartItemDto> BookingCartItems { get; private set; }

        [BindProperty]
        public CheckoutOrderDto CheckoutOrderModel { get; set; }

        public CartModel(IUserBookingCart userBookingCart, ISessionBookingCart sessionBookingCart, IBookingOrderService orderService, IMapper mapper,
            IEmailSender emailSender)
        {
            this.userBookingCart = userBookingCart;
            this.sessionBookingCart = sessionBookingCart;
            this.orderService = orderService;
            this.mapper = mapper;
            this.emailSender = emailSender;

            Title = "Cart";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var bookingCartItems = HttpContext.IsAuthenticated()
                ? await userBookingCart.GetUserBookingCartItems()
                : await sessionBookingCart.GetSessionBookingCartItems();

            BookingCartItems = mapper.Map<List<BookingCartItemDto>>(bookingCartItems);

            return Page();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var order = await orderService.PurchaseOrder(HttpContext.Session.GetString(Constants.CartId));

            if (order != null)
            {
                if (await emailSender.Send(Constants.OrderCompletedEmail
                (
                    HttpContext.IsAuthenticated() ? order.OrderDetails.CustomerEmail : CheckoutOrderModel.AnonymousEmail,
                    order.Id, order.OrderDetails.BookingId, order.OrderDetails.OfferTitle,
                    order.TotalPrice, order.OrderDetails.StartDate, order.OrderDetails.EndDate, order.OrderDetails.Phone,
                    order.OrderDetails.ContactEmail, order.OrderDetails.Location
                )))
                    return (IActionResult)RedirectToPage("/MyBookings", new { area = "Bookings" });

                Alertify.Push("Order has been completed but email cannot be sent. Please contact MyBooking team", AlertType.Warning);
                return await this.OnGetAsync();
            }

            return this.ErrorPage();
        }
    }
}