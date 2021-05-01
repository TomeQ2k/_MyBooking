using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Models.Dtos;

namespace MyBooking.Application.Components
{
    public class ChangeEmailFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ChangeEmailDto input) => View(input);
    }
}