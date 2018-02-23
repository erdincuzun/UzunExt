using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class BruteForce
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, m = x.Length, n = y.Length;
            preProcessTime = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Searching */
            for (j = 0; j <= n - m; ++j)
            {
                for (i = 0; i < m && x[i] == y[i + j]; ++i)
                    ;
                if (i >= m)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                    
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();
            preProcessTime = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Searching */
            for (j = 0; j <= n - m; ++j)
            {
                for (i = 0; i < m && x[i] == y[i + j]; ++i)
                    ;
                if (i >= m)
                    result.Add(j);
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return result;
        }
    }
}
