using System.Threading.Tasks;
using MyBooking.Core.Models.Helpers;

namespace MyBooking.Core.Services
{
    public interface IEmailSender
    {
        Task<bool> Send(EmailMessage emailMessage);
    }
}