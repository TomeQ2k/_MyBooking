using Microsoft.AspNetCore.Http;
using MyBooking.Core.Extensions;
using MyBooking.Core.Services;

namespace MyBooking.Infrastructure.Services
{
    public class HttpContextService : IHttpContextService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string CurrentUserId => httpContextAccessor.HttpContext.GetCurrentUserId();
    }
}