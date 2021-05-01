using Microsoft.AspNetCore.Mvc;

namespace MyBooking.Application.Components
{
    public class LogoutFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}