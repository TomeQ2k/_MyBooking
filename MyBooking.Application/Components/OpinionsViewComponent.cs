using Microsoft.AspNetCore.Mvc;
using MyBooking.Application.ViewModels;

namespace MyBooking.Application.Components
{
    public class OpinionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OpinionsViewModel model)
        {
            model.SortOpinions();
            return View(model);
        }
    }
}