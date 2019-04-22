using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Form.Helpers
{
    public class VKTagHelper : TagHelper
    {
        private const string address = "https://vk.com/metanit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", address);
            output.Content.SetContent("Group in vk");
        }
    }
}