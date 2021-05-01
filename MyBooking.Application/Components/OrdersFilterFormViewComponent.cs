using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Params;

namespace MyBooking.Application.Components
{
    public class OrdersFilterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookingOrdersFilterParams filterParams) => View(filterParams);
    }
}