using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DOMBasedAlgorithms
{
    public class TagProcessing
    {
        public static string ToXPath(string tagName)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.LoadHtml(tagName);
            HtmlNode node = htmlDoc.DocumentNode.SelectNodes("//*")[0];
            var attributes = node.Attributes.Any() ? "[" + string.Join(" and ", node.Attributes.Select(o => "@" + o.Name + "='" + o.Value + "'")) + "]" : "";
            var xpath = "//" + node.Name + attributes;
            return xpath;
        }

        public static List<string[]> NodenameAndAttributes(string tagName)
        {
            //tagname + attributes
            List<string[]> res = new List<string[]>();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.LoadHtml(tagName);
            HtmlNode node = htmlDoc.DocumentNode.SelectNodes("//*")[0];
            res.Add(new string[] { node.Name });            
            foreach (HtmlAttribute item in node.Attributes)
            {
                res.Add(new string[] { item.Name, item.Value });
            }
            return res;
        }
    }
}
