using MyBooking.Core.Data;

namespace MyBooking.Core.Services.FilterServices
{
    public abstract class BaseFilterService
    {
        protected readonly IDatabase database;

        public BaseFilterService(IDatabase database)
        {
            this.database = database;
        }
    }
}