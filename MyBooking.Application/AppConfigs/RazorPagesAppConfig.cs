using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;

namespace MyBooking.Application.AppConfigs
{
    public static class RazorPagesAppConfig
    {
        public static IMvcBuilder ConfigureRazorPages(this IServiceCollection services)
            => services.AddRazorPages(options =>
            {
                options.Conventions.AllowAnonymousToAreaFolder(AreaRoutes.AuthArea, AreaRoutes.Route(AreaRoutes.AuthArea));
                options.Conventions.AllowAnonymousToAreaFolder(AreaRoutes.OffersArea, AreaRoutes.Route(AreaRoutes.OffersArea));
                options.Conventions.AllowAnonymousToAreaFolder(AreaRoutes.CartArea, AreaRoutes.Route(AreaRoutes.CartArea));

                options.Conventions.AuthorizeAreaFolder(AreaRoutes.BookingsArea, AreaRoutes.Route(AreaRoutes.BookingsArea));
                options.Conventions.AuthorizeAreaFolder(AreaRoutes.ProfileArea, AreaRoutes.Route(AreaRoutes.ProfileArea));
                options.Conventions.AuthorizeAreaFolder(AreaRoutes.OrdersArea, AreaRoutes.Route(AreaRoutes.OrdersArea));
                options.Conventions.AuthorizeAreaFolder(AreaRoutes.StatsArea, AreaRoutes.Route(AreaRoutes.StatsArea));
            });
    }
}