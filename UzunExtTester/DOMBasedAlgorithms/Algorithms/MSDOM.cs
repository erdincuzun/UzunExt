using System.Collections.Generic;
using mshtml;
using System.Diagnostics;
using System.Globalization;

namespace DOMBasedAlgorithms
{
    public class MSDOM
    {
        public static double preProcessTime;
        public static double searchTime;
        public static List<string> Extract_Tag_with_IHTMLDocument(string tagName, string source)
        {
            //prepare nodename and its attributes
            List<string[]> res = TagProcessing.NodenameAndAttributes(tagName);

            List<string> list_sonuc = new List<string>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.clear();
            doc2.designMode = "On";
            doc2.write(source);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            if (null != doc)
            {
                string[] nodename = res[0];
                nodename[0] = nodename[0].ToUpper(new CultureInfo("en-US", false));
                
                for (int i = 1; i < res.Count; i++)
                {
                    string[] att = res[i];
                    if (att[0]=="id")
                    {
                        //id means only one record
                        list_sonuc.Add(doc.getElementById(att[1]).innerHTML);
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return list_sonuc;
                    }
                }

                foreach (IHTMLElement element in doc.getElementsByTagName(nodename[0]))
                {
                    bool sonuc = true;
                    for (int i = 1; i < res.Count; i++)
                    {
                        string[] att = res[i];
                        if (att[0] == "class")
                        {
                            if(element.className != att[1])
                            {
                                sonuc = false;
                                break;
                            }
                        }
                        else
                        {
                            if(element.innerHTML != null)
                            {
                                string tag_temp = element.outerHTML.Substring(0, element.outerHTML.IndexOf(">"));
                                if (!(tag_temp.Contains(att[0]) && tag_temp.Contains(att[1])))
                                {
                                    sonuc = false;
                                    break;
                                }
                            }
                            else
                            {
                                sonuc = false;
                                break;
                            }                            
                        }
                    }

                    if (sonuc)
                        list_sonuc.Add(element.innerHTML);                       

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
