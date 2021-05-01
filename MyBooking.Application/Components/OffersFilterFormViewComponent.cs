using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Params;

namespace MyBooking.Application.Components
{
    public class OffersFilterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OffersFilterParams filterParams) => View(filterParams);
    }
}