using System.Threading.Tasks;
using MyBooking.Core.Models;

namespace MyBooking.Core.Services
{
    public interface IEmailSender
    {
        Task<bool> Send(EmailMessage emailMessage);
    }
}