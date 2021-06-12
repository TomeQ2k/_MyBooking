using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MyBooking.Core.Models;
using MyBooking.Core.Services;
using MyBooking.Core.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MyBooking.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly SendGridClient emailClient;
        private readonly EmailSettings emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;

            this.emailClient = new SendGridClient(this.emailSettings.ApiKey);
        }

        public async Task<bool> Send(EmailMessage emailMessage)
        {
            var emailContentParams = new EmailContent(!string.IsNullOrEmpty(emailMessage.SenderEmail) ? emailMessage.SenderEmail : emailSettings.Sender, emailMessage.Email);

            var email = MailHelper.CreateSingleEmail(emailContentParams.FromAddress, emailContentParams.ToAddress, emailMessage.Subject, emailMessage.Message, emailMessage.Message);

            var response = await emailClient.SendEmailAsync(email);

            return response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}