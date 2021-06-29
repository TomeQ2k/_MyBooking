using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.BackgroundServices;
using MyBooking.Application.BackgroundServices.Interfaces;
using MyBooking.Core.Builders;
using MyBooking.Core.Data;
using MyBooking.Core.Services;
using MyBooking.Core.Services.FilterServices;
using MyBooking.Core.Services.ReadOnly;
using MyBooking.Infrastructure.Database;
using MyBooking.Infrastructure.Services;
using MyBooking.Infrastructure.Services.FilterServices;

namespace MyBooking.Application.AppConfigs
{
    public static class ScopedServicesAppConfig
    {
        public static IServiceCollection ConfigureScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabase, Database>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IResetPasswordManager, ResetPasswordManager>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IOpinionService, OpinionService>();
            services.AddScoped<IFavoritesService, FavoritesService>();
            services.AddScoped<IRatingManager, RatingManager>();
            services.AddScoped<IBookingOrderService, BookingOrderService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IDatabaseManager, DatabaseManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IBookingManager, BookingManager>();
            services.AddScoped<IAnnualStatsService, AnnualStatsService>();
            services.AddScoped<IMonthlyStatsService, MonthlyStatsService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
            services.AddScoped<IBookingValidationService, BookingValidationService>();
            services.AddScoped<IOpinionValidationService, OpinionValidationService>();
            services.AddScoped<IOfferValidationService, OfferValidationService>();

            services.AddScoped<IReadOnlyResetPasswordManager, ResetPasswordManager>();
            services.AddScoped<IReadOnlyProfileService, ProfileService>();
            services.AddScoped<IReadOnlyOfferService, OfferService>();
            services.AddScoped<IReadOnlyBookingService, BookingService>();
            services.AddScoped<IReadOnlyFavoritesService, FavoritesService>();
            services.AddScoped<IReadOnlyBookingOrderService, BookingOrderService>();
            services.AddScoped<IReadOnlyRolesService, RolesService>();

            services.AddScoped<IOffersFilterService, OffersFilterService>();
            services.AddScoped<IBookingsFilterService, BookingsFilterService>();

            services.AddScoped<IUserBookingCart, UserBookingCart>(services => BookingCartBuilder<UserBookingCart>.BuildCart(services));
            services.AddScoped<ISessionBookingCart, SessionBookingCart>(services => BookingCartBuilder<SessionBookingCart>.BuildCart(services));

            return services;
        }
    }
}