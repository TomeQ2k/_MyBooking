using Microsoft.AspNetCore.Mvc;
using MyBooking.Core.Dtos;

namespace MyBooking.Application.Components
{
    public class OpinionFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CreateOpinionDto input) => View(input);
    }
}