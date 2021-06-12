using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Dtos;

namespace MyBooking.Application.Components
{
    public class ChangeUsernameFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ChangeUsernameDto input) => View(input);
    }
}