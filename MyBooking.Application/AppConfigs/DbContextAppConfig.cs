using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Core.Helpers;
using MyBooking.Infrastructure.Database;

namespace MyBooking.Application.AppConfigs
{
    public static class DbContextAppConfig
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(AppSettingsKeys.ConnectionString), b => b.MigrationsAssembly("MyBooking.Application"));
                options.UseLazyLoadingProxies();
            });
    }
}