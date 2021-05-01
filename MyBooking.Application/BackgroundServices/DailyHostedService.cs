using System;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;
using MyBooking.Core.Services;

namespace MyBooking.Application.BackgroundServices
{
    internal class DailyHostedService : ServerHostedService
    {
        public DailyHostedService(IServiceProvider services) : base(services)
        {
            TimeInterval = Constants.DailyHostedServiceTimeInDays * 24 * 60;
        }

        public override async void Callback(object state)
        {
            using (var scope = services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<IUserManager>();
                var tokenManager = scope.ServiceProvider.GetRequiredService<ITokenManager>();

                await userManager.ClearNotConfirmedUsers();
                await tokenManager.ClearExpiredTokens();

                base.Callback(state);
            }
        }
    }
}