using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Models;
using MyBooking.Core.Services;
using MyBooking.Core.Services.ReadOnly;
using MyBooking.Infrastructure.Email;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.AppConfigs
{
    public static class SingletonServicesAppConfig
    {
        public static IServiceCollection ConfigureSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IFilesManager, FilesManager>();
            services.AddSingleton<IHashGenerator, HashGenerator>();
            services.AddSingleton<ICookieClaimsPrincipalGenerator, CookieClaimsPrincipalGenerator>();
            services.AddSingleton<IHttpContextService, HttpContextService>();
            services.AddSingleton<IHttpContextWriter, HttpContextService>();
            services.AddSingleton<IHttpContextReader, HttpContextService>();

            services.AddSingleton<IReadOnlyFilesManager, FilesManager>();

            services.AddSingleton<Alertify>(a => Alertify.Build());

            return services;
        }
    }
}