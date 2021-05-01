using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;

namespace MyBooking.Application.AppConfigs
{
    public static class AuthenticationAppConfig
    {
        public static AuthenticationBuilder ConfigureAuthentication(this IServiceCollection services)
            => services.AddAuthentication(Constants.AuthCookiesDefaultScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = Constants.AuthCookieName;

                    options.LoginPath = Routes.LoginRoute;
                    options.LogoutPath = Routes.LogoutRoute;
                    options.AccessDeniedPath = Routes.AccessDeniedRoute;
                });
    }
}