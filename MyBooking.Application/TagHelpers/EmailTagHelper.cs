using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyBooking.Application.TagHelpers
{
    public class EmailTagHelper : BaseTagHelper
    {
        public string Address { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(LinkText);
        }
    }
}