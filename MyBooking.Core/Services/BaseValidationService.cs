using MyBooking.Core.Data;

namespace MyBooking.Core.Services
{
    public abstract class BaseValidationService
    {
        protected readonly IDatabase database;

        public BaseValidationService(IDatabase database)
        {
            this.database = database;
        }
    }
}