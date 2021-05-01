using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBooking.Application.Utilities.Extensions
{
    public static class ViewExtensions
    {
        public static IActionResult ErrorPage(this PageModel pageModel) => pageModel.RedirectToPage("/Error");
        public static IActionResult ErrorPage(this Controller controller) => controller.RedirectToPage("/Error");
    }
}