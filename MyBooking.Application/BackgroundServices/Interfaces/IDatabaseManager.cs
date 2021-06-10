using System.Threading.Tasks;

namespace MyBooking.Application.BackgroundServices.Interfaces
{
    public interface IDatabaseManager
    {
        Task Seed();
    }
}