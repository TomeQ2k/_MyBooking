using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Filters;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Auth.Pages
{
    [ServiceFilter(typeof(OnlyAnonymousFilter))]
    public class ResetPasswordModel : BasePageModel
    {
        private readonly IResetPasswordManager resetPasswordManager;

        [BindProperty]
        public ResetPasswordDto Input { get; set; }

        [FromQuery(Name = "userId")]
        public string UserId { get; set; }

        [FromQuery(Name = "code")]
        public string Code { get; set; }

        public bool PasswordChanged { get; private set; }

        public ResetPasswordModel(IResetPasswordManager resetPasswordManager)
        {
            this.resetPasswordManager = resetPasswordManager;

            Title = "Reset password";
        }

        public async Task<IActionResult> OnGetAsync()
            => await resetPasswordManager.VerifyResetPasswordToken(UserId, Code)
                ? (IActionResult)Page() : RedirectToPage("/Index");

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (!await resetPasswordManager.ResetPassword(UserId, Code, Input.NewPassword))
            {
                Alertify.Push("Reset password failed", AlertType.Error);
                return Page();
            }

            PasswordChanged = true;

            return Page();
        }
    }
}