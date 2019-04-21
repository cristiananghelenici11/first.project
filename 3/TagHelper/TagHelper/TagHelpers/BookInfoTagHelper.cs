using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelper.Models;

namespace TagHelper.TagHelpers
{

    public class BookInfoTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public Book Book { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            string BookInfoContent = $@"<p>Denumire: <b>{Book.Title}</b></p>
                                    <p>Autor: <b>{Book.Author}</b></p>
                                    <p>Anul : <b>{Book.Year}</b></p>";

            output.Content.SetHtmlContent(BookInfoContent);
        }
    }
}
