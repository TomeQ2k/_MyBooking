using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Services;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.Areas.Profile.Pages
{
    public class ChangeEmailModel : BasePageModel
    {
        private readonly IProfileService profileService;
        private readonly IAuthValidationService authValidationService;

        public ChangeEmailModel(IProfileService profileService, IAuthValidationService authValidationService)
        {
            this.profileService = profileService;
            this.authValidationService = authValidationService;

            Title = "Change email";
        }

        public async Task<IActionResult> OnGetAsync([FromQuery] string userId, string code, string newEmail)
        {
            if (await authValidationService.EmailExists(newEmail))
            {
                Alertify.Push("Email address already exists", AlertType.Error);
                return Page();
            }

            var emailChanged = await profileService.ChangeEmail(userId, newEmail, code);

            if (emailChanged)
                Alertify.Push("Email changed", AlertType.Primary);
            else
                Alertify.Push("Email changing failed", AlertType.Error);

            return RedirectToPage("/Profile", new { area = "Profile", emailChanged = emailChanged });
        }
    }
}