using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyBooking.Application.TagHelpers
{
    public class PhoneTagHelper : BaseTagHelper
    {
        public string PhoneNumber { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "tel:" + PhoneNumber);
            output.Content.SetContent(LinkText);
        }
    }
}