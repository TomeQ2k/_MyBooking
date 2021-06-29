using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Helpers;
using MyBooking.Core.Dtos;
using MyBooking.Core.Models;
using MyBooking.Core.Services;

namespace MyBooking.Application.Areas.Auth.Pages
{
    public class ForgotPasswordModel : BasePageModel
    {
        private readonly IResetPasswordManager resetPasswordManager;
        private readonly IEmailSender emailSender;

        public IConfiguration Configuration { get; }

        [BindProperty]
        public ForgotPasswordDto Input { get; set; }

        public ForgotPasswordModel(IResetPasswordManager resetPasswordManager, IEmailSender emailSender, IConfiguration configuration)
        {
            this.resetPasswordManager = resetPasswordManager;
            this.emailSender = emailSender;
            Configuration = configuration;

            Title = "Forgot password";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var sendResetPasswordResult = await resetPasswordManager.GenerateResetPasswordToken(Input.Email);

            if (sendResetPasswordResult == null)
            {
                Alertify.Push("Account does not exist", AlertType.Error);
                return Page();
            }

            var emailSent = await emailSender.Send(Constants.ResetPasswordEmail(sendResetPasswordResult.Email, sendResetPasswordResult.Username,
                    $"{Configuration.GetValue<string>(AppSettingsKeys.ServerAddress)}/Auth/ResetPassword?userId={sendResetPasswordResult.UserId}&code={sendResetPasswordResult.Code}"));

            if (emailSent)
            {
                Alertify.Push($"Reset password token was sent to: {sendResetPasswordResult.Email}");
                return Page();
            }

            Alertify.Push("There was a problem during sending reset password token");
            return Page();
        }
    }
}