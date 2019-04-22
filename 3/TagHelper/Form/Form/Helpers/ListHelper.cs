using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Form.Helpers
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            string result = "<ul>";

            foreach (string item in items)
            {
                result += $"<li>{item}</li>";
            }

            result += "</ul>";
            return new HtmlString(result);
        }

        
    }
}