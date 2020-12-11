using Microsoft.AspNetCore.Razor.TagHelpers;

namespace YVN.Web.TagHelpers
{
    [HtmlTargetElement("h1")]
    [HtmlTargetElement("h2")]
    public class GreetingHeaderTagHelper : TagHelper
    {
        public string GreetingString { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("name", "Marin");
            output.Content.SetContent(GreetingString);
            base.Process(context, output);
        }

    }
}
