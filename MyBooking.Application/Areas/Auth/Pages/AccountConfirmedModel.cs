using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBooking.Application.Pages;
using MyBooking.Application.Utilities.Extensions;
using MyBooking.Core.Filters;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Auth.Pages
{
    [ServiceFilter(typeof(OnlyAnonymousFilter))]
    public class AccountConfirmedModel : BasePageModel
    {
        private readonly IAuthService authService;

        public IConfiguration Configuration { get; }

        public AccountConfirmedModel(IAuthService authService, IConfiguration configuration)
        {
            this.authService = authService;
            Configuration = configuration;

            Title = "Account confirmed";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] string userId, string code)
            => await authService.ConfirmAccount(userId, code) ? (IActionResult)Page() : this.ErrorPage();
    }
}