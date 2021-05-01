using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Models.Dtos;

namespace MyBooking.Application.Components
{
    public class BookingFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookingDateDto input) => View(input);
    }
}