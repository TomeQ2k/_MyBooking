using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Filters;
using MyBooking.Core.Dtos;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Auth.Pages
{
    [ServiceFilter(typeof(OnlyAnonymousFilter))]
    public class LoginModel : BasePageModel
    {
        private readonly IAuthService authService;
        private readonly ICookieClaimsPrincipalGenerator cookieClaimsPrincipalManager;

        [BindProperty]
        public UserLoginDto UserLogin { get; set; }

        public LoginModel(IAuthService authService, ICookieClaimsPrincipalGenerator cookieClaimsPrincipalManager)
        {
            this.authService = authService;
            this.cookieClaimsPrincipalManager = cookieClaimsPrincipalManager;

            Title = "Login";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var loggedInUser = await authService.SignIn(UserLogin.Email, UserLogin.Password);

            if (loggedInUser == null)
                return Page();

            var principal = cookieClaimsPrincipalManager.GenerateCookieClaimsPrincipal(loggedInUser);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToPage("/Index");
        }
    }
}