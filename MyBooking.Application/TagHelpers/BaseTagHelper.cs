using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyBooking.Application.TagHelpers
{
    public abstract class BaseTagHelper : TagHelper
    {
        public string LinkText { get; set; }
    }
}