using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Dtos;

namespace MyBooking.Application.Components
{
    public class ChangeEmailFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ChangeEmailDto input) => View(input);
    }
}