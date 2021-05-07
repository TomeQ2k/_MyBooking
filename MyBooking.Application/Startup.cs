using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBooking.Application.AppConfigs;
using MyBooking.Core.Helpers;
using MyBooking.Core.Mapper;
using Serilog;

namespace MyBooking.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.ConfigureRazorPages();

            services.ConfigureAuthentication();
            services.ConfigureAuthorization();

            services.ConfigureMvc();

            services.AddHttpContextAccessor();

            services.ConfigureDbContext(Configuration);

            services.AddOptions();

            #region services

            services.ConfigureScopedServices();
            services.ConfigureSingletonServices();

            #endregion

            services.ConfigureSettings(Configuration);

            services.ConfigureFilters();

            services.ConfigureServerHostedServices();

            services.AddSession();

            services.AddAutoMapper(typeof(MapperProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler(Routes.ErrorRoute);

            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            StorageLocation.Init(Configuration.GetValue<string>(AppSettingsKeys.ServerAddress));
        }
    }
}
