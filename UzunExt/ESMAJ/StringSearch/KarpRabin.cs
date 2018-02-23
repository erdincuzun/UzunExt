using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class KarpRabin
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int d, hx, hy, i, j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();
            preProcessTime = 0;
            searchTime = 0;
            if (m > n)
            {
                return -1;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            /*
             * computes d = 2^(m-1) with the left-shift operator
             */
            for (d = i = 1; i < m; ++i)
                d = (d << 1);

            for (hy = hx = i = 0; i < m; ++i)
            {
                hx = ((hx << 1) + x[i]);
                hy = ((hy << 1) + y[i]);
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n - m)
            {
                if (hx == hy && ArrayCmp(x, 0, y, j, m) == 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                    result.Add(j);
                hy = Rehash(y[j], y[j + m], hy, d);
                ++j;
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
            {
                stopwatch.Stop();
                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                return j + startIndex;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int d, hx, hy, i, j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            preProcessTime = 0;
            searchTime = 0;
            if (m > n)
                return null;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            /*
             * computes d = 2^(m-1) with the left-shift operator
             */
            for (d = i = 1; i < m; ++i)
                d = (d << 1);

            for (hy = hx = i = 0; i < m; ++i)
            {
                hx = ((hx << 1) + x[i]);
                hy = ((hy << 1) + y[i]);
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n - m)
            {
                if (hx == hy && ArrayCmp(x, 0, y, j, m) == 0)
                    result.Add(j);
                hy = Rehash(y[j], y[j + m], hy, d);
                ++j;
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
                result.Add(j);

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }

        private static int Rehash(char a, char b, int h, int d)
        {
            return ((((h) - (a) * d) << 1) + (b));
        }

        private static int ArrayCmp(char[] a, int aIdx, char[] b, int bIdx,  int Length)
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
