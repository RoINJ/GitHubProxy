using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Core.ContentReplacement;

public class ContentModifier : IContentModifier
{
    private readonly string[] excludedNodes = new string[] { "style", "script" };

    public string ModifyContent(string originalContent)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(originalContent);

        var body = htmlDoc.DocumentNode.SelectSingleNode("//body");

        if (body is not null)
        {
            ModifyTextContent(body);
        }

        return htmlDoc.DocumentNode.OuterHtml;
    }

    private void ModifyTextContent(HtmlNode node)
    {
        if (!excludedNodes.Contains(node.Name))
        {
            if (node.NodeType == HtmlNodeType.Text)
            {
                var modifiedText = Regex.Replace(node.InnerHtml, @"\b(\w{6})\b", "$1&trade;", RegexOptions.CultureInvariant);
                node.InnerHtml = modifiedText;
            }
            else
            {
                foreach (HtmlNode childNode in node.ChildNodes)
                {
                    ModifyTextContent(childNode);
                }
            }
        }
    }
}
