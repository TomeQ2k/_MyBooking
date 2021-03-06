using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBooking.Core.Models;

namespace MyBooking.Application.Pages
{
    [ValidateAntiForgeryToken]
    public abstract class BasePageModel : PageModel, IDisposable
    {
        public string Title { get; set; }

        public void Dispose()
        {
            Alertify.Clear();
        }
    }
}