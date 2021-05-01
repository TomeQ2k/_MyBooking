using System;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Application.BackgroundServices
{
    internal class BookingHostedService : ServerHostedService
    {
        public BookingHostedService(IServiceProvider services) : base(services)
        {
            TimeInterval = Constants.BookingHostedServiceTimeInMinutes;
        }

        public override async void Callback(object state)
        {
            using (var scope = services.CreateScope())
            {
                var bookingManager = scope.ServiceProvider.GetRequiredService<IBookingManager>();

                await bookingManager.ClearNotConfirmedBookings();

                base.Callback(state);
            }
        }
    }
}