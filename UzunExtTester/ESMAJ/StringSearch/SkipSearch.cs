using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class SkipSearch
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, m = x.Length, n = y.Length;
            Cell ptr;
            Cell[] z = new Cell[65536];
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            for (i = 0; i < m; ++i)
            {
                ptr = new Cell();
                ptr.element = i;
                ptr.next = z[x[i]];
                z[x[i]] = ptr;
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (j = m - 1; j < n; j += m)
                for (ptr = z[y[j]]; ptr != null; ptr = ptr.next)
                    if (ArrayCmp(x, 0, y, j - ptr.element, m) == 0)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return j - ptr.element + startIndex;
                    }                        

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, m = x.Length, n = y.Length;
            Cell ptr;
            Cell[] z = new Cell[65536];
            List<int> result = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            for (i = 0; i < m; ++i)
            {
                ptr = new Cell();
                ptr.element = i;
                ptr.next = z[x[i]];
                z[x[i]] = ptr;
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (j = m - 1; j < n; j += m)
                for (ptr = z[y[j]]; ptr != null; ptr = ptr.next)
                    if (ArrayCmp(x, 0, y, j - ptr.element, m) == 0)
                        result.Add(j - ptr.element);

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static int ArrayCmp(char[] a, int aIdx, char[] b, int bIdx, int Length)
        {
            int i = 0;

            for (i = 0; i < Length && aIdx + i < a.Length && bIdx + i < b.Length; i++)
            {
                if (a[aIdx + i] == b[bIdx + i])
                    continue;
                else if (a[aIdx + i] > b[bIdx + i])
                    return 1;
                else
                    return 2;
            }

            if (i < Length)
                if (a.Length - aIdx == b.Length - bIdx)
                    return 0;
                else if (a.Length - aIdx > b.Length - bIdx)
                    return 1;
                else
                    return 2;
            else
                return 0;
        }

       
    }
}
