namespace MusicX.Web.Infrastructure.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("h1")]
public class HelloTagHelper : TagHelper
{
    private const string MessageFormat = "Hello from custom tag helper, {0}";
    public string TargetName { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!string.IsNullOrEmpty(this.TargetName))
        {
            string formattedMessage = string.Format(MessageFormat, this.TargetName);
            output.Content.SetContent(formattedMessage);
        }
    }
}

