using System;
using Microsoft.AspNetCore.Http;
using MyBooking.Core.Data;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Extensions;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Core.Builders
{
    public class BookingCartBuilder<TBookingCart> where TBookingCart : class, IBookingCart
    {
        public static TBookingCart BuildCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var database = services.GetRequiredService<IDatabase>();

            var constructor = typeof(TBookingCart).GetConstructor(new[] { typeof(IDatabase) });
            TBookingCart bookingCart = constructor.Invoke(new object[] { database }) as TBookingCart;

            ISession session = httpContext.Session;

            string cartId = session.GetString(Constants.CartId) ?? Utils.NewGuid(length: 32);
            session.SetString(Constants.CartId, cartId);

            bookingCart.SetCartId(cartId);
            bookingCart.SetCurrentUserId(httpContext.GetCurrentUserId());

            return bookingCart;
        }
    }
}