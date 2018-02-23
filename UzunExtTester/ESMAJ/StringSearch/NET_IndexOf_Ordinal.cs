using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ESMAJ.StringSearch
{
    public class NET_IndexOf_Ordinal
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            preProcessTime = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = source.IndexOf(pattern, startIndex, StringComparison.Ordinal);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }

        public static List<int> Search(string pattern, string source)
        {
            preProcessTime = 0;
            List<int> result = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int minIndex = source.IndexOf(pattern, 0, StringComparison.Ordinal);
            if (minIndex != -1)
                result.Add(minIndex);
            while (minIndex != -1)
            {
                minIndex = source.IndexOf(pattern, minIndex + pattern.Length, StringComparison.Ordinal);
                if(minIndex != -1)
                    result.Add(minIndex);
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }


        #region CountSubString
        private static int CountofPattern(string text, string pattern)
        {
            return CountSubstring_INDEXOF(text, "<div");
            //return CountSubstring_REGEX(text, pattern);
        }
        private static int CountSubstring_INDEXOF(string text, string value)
        {
            int count = 0, minIndex = text.IndexOf(value, 0);
            while (minIndex != -1)
            {
                minIndex = text.IndexOf(value, minIndex + value.Length, StringComparison.Ordinal);
                count++;
            }
            return count;
        }

        private static int CountSubstring_REGEX(string text, string value)
        {
            return Regex.Matches(text, value).Count;
        }
        #endregion
    }
}
