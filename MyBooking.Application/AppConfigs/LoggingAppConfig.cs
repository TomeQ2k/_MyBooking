using Microsoft.AspNetCore.Builder;
using Serilog;

namespace MyBooking.Application.AppConfigs
{
    public static class LoggingAppConfig
    {
        public static void ConfigureLogging(this IApplicationBuilder app)
           => app.UseSerilogRequestLogging();
    }
}