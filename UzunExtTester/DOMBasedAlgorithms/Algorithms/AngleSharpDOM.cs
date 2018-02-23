using System.Collections.Generic;
using System.Linq;

using AngleSharp.Parser.Html;
using System.Globalization;
using System.Diagnostics;

namespace DOMBasedAlgorithms
{
    public class AngleSharpDOM
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int numberofElement;
        public static List<string> Extract_Tag_with_AngleSharp(string tagName, string source)
        {
            numberofElement = 0;
            //prepare nodename and its attributes
            List<string[]> res = TagProcessing.NodenameAndAttributes(tagName);
            List<string> list_sonuc = new List<string>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var parser = new HtmlParser();
            var document = parser.Parse(source);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            //Do something with LINQ
            if (document != null)
            {
                numberofElement = document.All.Length; 
                string[] nodename = res[0];
                List<AngleSharp.Dom.IElement> temp = document.All.Where(m => m.LocalName == nodename[0]).ToList();

                for (int i = 1; i < res.Count; i++)
                {
                    string[] att = res[i];
                    temp = temp.Where(m => m.Attributes[att[0]] != null && m.Attributes[att[0]].Value == att[1]).ToList();
                }

                if (temp != null)
                {
                    foreach (AngleSharp.Dom.IElement node in temp)
                    {
                        list_sonuc.Add(node.InnerHtml);
                    }
                }
                else
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return null;
                }
                                           
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
