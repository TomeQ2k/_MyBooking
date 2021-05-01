using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBooking.Core.Filters
{
    public class OnlyAnonymousFilter : IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToPageResult("Index");
                return;
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
    }
}