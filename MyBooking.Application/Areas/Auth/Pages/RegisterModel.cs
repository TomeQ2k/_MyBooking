using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBooking.Application.Pages;
using MyBooking.Core.Enums;
using MyBooking.Core.Filters;
using MyBooking.Core.Helpers;
using MyBooking.Core.Models.Dtos;
using MyBooking.Core.Services;
using MyBooking.Infrastructure.Services;

namespace MyBooking.Application.Areas.Auth.Pages
{
    [ServiceFilter(typeof(OnlyAnonymousFilter))]
    public class RegisterModel : BasePageModel
    {
        private readonly IAuthService authService;
        private readonly IAuthValidationService authValidationService;
        private readonly IEmailSender emailSender;

        public IConfiguration Configuration { get; }

        [BindProperty]
        public UserRegisterDto UserRegister { get; set; }

        public RegisterModel(IAuthService authService, IAuthValidationService authValidationService, IEmailSender emailSender, IConfiguration configuration)
        {
            this.authService = authService;
            this.authValidationService = authValidationService;
            this.emailSender = emailSender;
            Configuration = configuration;

            Title = "Register";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (await authValidationService.EmailExists(UserRegister.Email))
            {
                ModelState.TryAddModelError(ErrorCodes.EmailExists, "Email address already exists");
                return Page();
            }

            if (await authValidationService.UsernameExists(UserRegister.Username))
            {
                ModelState.TryAddModelError(ErrorCodes.UsernameExists, "Username already exists");
                return Page();
            }

            var authResult = await authService.SignUp(UserRegister.Email, UserRegister.Password, UserRegister.Username);

            if (authResult != null)
            {
                var emailSent = await emailSender.Send(Constants.ActivationAccountEmail(UserRegister.Email,
                     $"{Configuration.GetValue<string>(AppSettingsKeys.ServerAddress)}Auth/ConfirmAccount?userId={authResult.User.Id}&code={authResult.Token}"));

                if (emailSent)
                {
                    Alertify.Push($"Activation email was sent to: {UserRegister.Email}", AlertType.Info);
                    return Page();
                }

                Alertify.Push("There was a problem during sending activation email", AlertType.Error);
            }

            return Page();
        }
    }
}