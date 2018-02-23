using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class NotSoNaive
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int j, k, ell, m = x.Length, n = y.Length;
            List<int> result = new List<int>();
            preProcessTime = 0;
            searchTime = 0;
            if (m < 2)
                return -1;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            if (x[0] == x[1])
            {
                k = 2;
                ell = 1;
            }
            else
            {
                k = 1;
                ell = 2;
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
                if (x[1] != y[j + 1])
                    j += k;
                else
                {
                    if (ArrayCmp(x, 2, y, j + 2, m - 2) == 0 && x[0] == y[j])
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return j + startIndex;
                    }
                    j += ell;
                }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int j, k, ell, m = x.Length, n = y.Length;
            List<int> result = new List<int>();
            preProcessTime = 0;
            searchTime = 0;
            if (m < 2)
                return null;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            if (x[0] == x[1])
            {
                k = 2;
                ell = 1;
            }
            else
            {
                k = 1;
                ell = 2;
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
                if (x[1] != y[j + 1])
                    j += k;
                else
                {
                    if (ArrayCmp(x, 2, y, j + 2, m - 2) == 0 && x[0] == y[j])
                        result.Add(j);
                    j += ell;
                }

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
