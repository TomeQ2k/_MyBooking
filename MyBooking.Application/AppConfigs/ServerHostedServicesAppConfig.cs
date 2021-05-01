using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.BackgroundServices;

namespace MyBooking.Application.AppConfigs
{
    public static class ServerHostedServicesAppConfig
    {
        public static IServiceCollection ConfigureServerHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<DailyHostedService>();
            services.AddHostedService<BookingHostedService>();

            return services;
        }
    }
}