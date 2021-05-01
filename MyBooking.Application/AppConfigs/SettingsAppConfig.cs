using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Settings;

namespace MyBooking.Application.AppConfigs
{
    public static class SettingsAppConfig
    {
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

            return services;
        }
    }
}