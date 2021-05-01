using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;

namespace MyBooking.Application.AppConfigs
{
    public static class AuthorizationAppConfig
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
            => services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.AdminPolicy, policy => policy.RequireClaim(ClaimTypes.Role, Constants.AdminRole));
            });
    }
}