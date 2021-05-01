using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Params;

namespace MyBooking.Application.Components
{
    public class BookingsFilterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookingsFilterParams filterParams) => View(filterParams);
    }
}