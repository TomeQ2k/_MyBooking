using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBooking.Application.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToPage("/Login", new { area = "Auth" });
        }
    }
}