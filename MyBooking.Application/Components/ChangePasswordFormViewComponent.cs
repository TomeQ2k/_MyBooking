using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Models.Dtos;

namespace MyBooking.Application.Components
{
    public class ChangePasswordFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ChangePasswordDto input) => View(input);
    }
}