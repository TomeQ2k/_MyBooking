using Microsoft.Extensions.DependencyInjection;

namespace MyBooking.Application.AppConfigs
{
    public static class MvcAppConfig
    {
        public static IMvcBuilder ConfigureMvc(this IServiceCollection services)
            => services.AddMvc(options => options.EnableEndpointRouting = false);
    }
}