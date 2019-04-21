using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace TagHelper.TagHelpers

{

    public class SocialsTagHelper  : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var target = await output.GetChildContentAsync();
            var content = "<h3>Социальные сети</h3>" + target.GetContent();
            output.Content.SetHtmlContent(content);
        }
    }

    public class VKTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private const string address = "https://vk.com/metanit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", address);
            output.Content.SetContent("Grupa in VK");
            output.TagMode = TagMode.StartTagAndEndTag;

            output.PreElement.SetHtmlContent("<h3>Социальные сети</h3>");
            output.PostElement.SetHtmlContent("<p>Элемент после ссылки</p>");

        }
    }
}