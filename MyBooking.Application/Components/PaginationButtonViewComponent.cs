using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Helpers;

namespace MyBooking.Application.Components
{
    public class PaginationButtonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string actionName, int pageNumber)
        {
            ViewData[Constants.ActionName] = actionName;
            ViewData[Constants.PageNumber] = pageNumber;

            return View();
        }
    }
}