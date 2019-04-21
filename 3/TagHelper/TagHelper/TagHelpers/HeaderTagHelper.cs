using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelper.TagHelpers
{

    [HtmlTargetElement(Attributes = "header")]
    public class HeaderTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h2";
            output.Attributes.RemoveAll("header");
        }
    }
}
