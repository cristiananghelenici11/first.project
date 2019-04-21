using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelper.TagHelpers
{
    public class ListTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public List<string> Elements { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            var listContent = "";

            foreach (string item in Elements)
            {
                listContent += "<li>" + item + "</li>";
            }

            output.Content.SetHtmlContent(listContent);
        }
    }
}