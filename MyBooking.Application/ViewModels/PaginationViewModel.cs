using MyBooking.Core.Models;

namespace MyBooking.Application.ViewModels
{
    public class PaginationViewModel
    {
        public dynamic PagedList { get; private set; }

        public string ActionName { get; private set; }

        public static PaginationViewModel Build<T>(PagedList<T> pagedList, string actionName) where T : class, new()
            => new PaginationViewModel
            {
                PagedList = pagedList,
                ActionName = actionName
            };
    }
}