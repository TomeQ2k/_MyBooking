using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Filters;

namespace MyBooking.Application.AppConfigs
{
    public static class FiltersAppConfig
    {
        public static IServiceCollection ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<OnlyAnonymousFilter>();

            return services;
        }
    }
}