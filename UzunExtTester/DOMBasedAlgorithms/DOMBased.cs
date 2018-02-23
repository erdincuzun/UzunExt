using System.Collections.Generic;

namespace DOMBasedAlgorithms
{
    public class DOMBased
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int numberofElement;
        public enum DOMAlgorithm
        {
            MSDOM, HAP, AngleSharpDOM
        };

        public static List<string> Extract(string tagName, string source, DOMAlgorithm da)
        {
            numberofElement = 0;
            int id = (int)da;
            List<string> res = null;
            preProcessTime = 0;
            searchTime = 0;
            if (id == 0)
            {
                res = MSDOM.Extract_Tag_with_IHTMLDocument(tagName, source);
                preProcessTime = MSDOM.preProcessTime;
                searchTime = MSDOM.searchTime;
            } 
            else if (id == 1)
            {
                res = HAP.Extract_Tag_with_HAP(tagName, source);
                preProcessTime = HAP.preProcessTime;
                searchTime = HAP.searchTime;
            }
            else if (id == 2)
            {
                res = AngleSharpDOM.Extract_Tag_with_AngleSharp(tagName, source);
                preProcessTime = AngleSharpDOM.preProcessTime;
                searchTime = AngleSharpDOM.searchTime;
                numberofElement = AngleSharpDOM.numberofElement;
            }            

            return res;
        }
    }
}
