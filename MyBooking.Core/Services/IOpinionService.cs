using System.Threading.Tasks;
using MyBooking.Core.Models.Domain;

namespace MyBooking.Core.Services
{
    public interface IOpinionService
    {
        Task<Opinion> CreateOpinion(string text, string offerId);
        Task<bool> DeleteOpinion(string opinionId, string userId);
    }
}