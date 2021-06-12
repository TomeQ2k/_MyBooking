using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;
using MyBooking.Core.Entities;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Profile.Pages
{
    public class ProfileModel : BasePageModel
    {
        private readonly IProfileService profileService;
        private readonly ICookieClaimsPrincipalGenerator cookieClaimsPrincipalGenerator;
        private readonly IAuthValidationService authValidationService;
        private readonly IEmailSender emailSender;

        public IConfiguration Configuration { get; }

        public ChangeUsernameDto ChangeUsernameInput { get; set; }
        public ChangePasswordDto ChangePasswordInput { get; set; }
        public ChangeEmailDto ChangeEmailInput { get; set; }

        public ProfileModel(IProfileService profileService, ICookieClaimsPrincipalGenerator cookieClaimsPrincipalGenerator, IAuthValidationService authValidationService,
            IEmailSender emailSender, IConfiguration configuration)
        {
            this.profileService = profileService;
            this.cookieClaimsPrincipalGenerator = cookieClaimsPrincipalGenerator;
            this.authValidationService = authValidationService;
            this.emailSender = emailSender;

            Configuration = configuration;

            Title = "Profile";
        }

        public IActionResult OnGet([FromQuery] bool usernameChanged = false, bool emailChanged = false)
        {
            if (usernameChanged)
                Alertify.Push("Username changed", AlertType.Primary);
            if (emailChanged)
                Alertify.Push("Email changed", AlertType.Primary);

            return Page();
        }

        public async Task<IActionResult> OnPostChangeUsernameAsync([Bind] ChangeUsernameDto changeUsernameInput)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await authValidationService.UsernameExists(changeUsernameInput.NewUsername))
            {
                Alertify.Push("Username already exists", AlertType.Error);
                return Page();
            }

            var userUpdated = await profileService.ChangeUsername(changeUsernameInput.NewUsername);

            if (userUpdated != null)
            {
                await RefreshAuthCookie(userUpdated);

                return RedirectToPage(new { usernameChanged = true });
            }

            Alertify.Push("Username changing failed", AlertType.Error);
            return Page();
        }

        public async Task<IActionResult> OnPostChangePasswordAsync([Bind] ChangePasswordDto changePasswordInput)
        {
            if (!ModelState.IsValid)
                return Page();

            var passwordChanged = await profileService.ChangePassword(changePasswordInput.OldPassword, changePasswordInput.NewPassword);

            if (passwordChanged)
                Alertify.Push("Password changed", AlertType.Primary);

            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync([Bind] ChangeEmailDto changeEmailInput)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await authValidationService.EmailExists(changeEmailInput.NewEmail))
            {
                Alertify.Push("Email address already exists", AlertType.Error);
                return Page();
            }

            var generateChangeEmailTokenResult = await profileService.GenerateChangeEmailToken(changeEmailInput.NewEmail);

            if (generateChangeEmailTokenResult != null)
            {
                var emailSent = await emailSender.Send(Constants.EmailChangeEmail(changeEmailInput.NewEmail,
                    $"{Configuration.GetValue<string>(AppSettingsKeys.ServerAddress)}" +
                    $"Profile/ChangeEmail?userId={generateChangeEmailTokenResult.UserId}&code={generateChangeEmailTokenResult.Code}&newEmail={generateChangeEmailTokenResult.NewEmail}"));

                if (emailSent)
                {
                    Alertify.Push($"Change email token was sent to: {generateChangeEmailTokenResult.NewEmail}", AlertType.Primary);
                    return Page();
                }

                Alertify.Push("Sending change email token failed", AlertType.Error);
                return Page();
            }

            Alertify.Push("Email changing failed", AlertType.Error);
            return Page();
        }

        #region private

        private async Task RefreshAuthCookie(User userUpdated)
        {
            var principal = cookieClaimsPrincipalGenerator.GenerateCookieClaimsPrincipal(userUpdated);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        #endregion
    }
}