using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Diagnostics;

namespace DOMBasedAlgorithms
{
    //Html Agility Pack(HAP)
    public class HAP
    {
        public static double preProcessTime;
        public static double searchTime;
        public static List<string> Extract_Tag_with_HAP(string tagname, string source)
        {
            //prepare xpath
            string tagname_xpath = TagProcessing.ToXPath(tagname);

            List<string> list_sonuc = new List<string>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HtmlDocument htmlDoc = new HtmlDocument();
            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;
            // filePath is a path to a file containing the html
            htmlDoc.LoadHtml(source);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            HtmlNodeCollection _htc = htmlDoc.DocumentNode.SelectNodes(tagname_xpath);
            if (_htc != null)
            {
                foreach (HtmlNode node in _htc)
                    list_sonuc.Add(node.InnerHtml);
            }
            else
            {
                stopwatch.Stop();
                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                return null;
            }           

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return list_sonuc;
        }       
    }
}
