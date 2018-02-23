using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class ShiftOr
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            long lim, state;
            long[] s = new long[65536];
            int j, m = x.Length, n = y.Length;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            lim = PreSo(x, s);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            for (state = ~0, j = 0; j < n; ++j)
            {
                state = (state << 1) | s[y[j]];
                if (state < lim)
                {
                    return j - m + 1 + startIndex;
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            long lim, state;
            long[] s = new long[65536];
            int j, m = x.Length, n = y.Length;

            List<int> result = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            lim = PreSo(x, s);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            for (state = ~0, j = 0; j < n; ++j)
            {
                state = (state << 1) | s[y[j]];
                if (state < lim)
                    result.Add(j - m + 1);
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static long PreSo(char[] x, long[] s)
        {
            long j, lim, m = x.Length;
            int i;
            for (i = 0; i < s.Length; ++i)
                s[i] = ~0;
            for (lim = i = 0, j = 1; i < m; ++i, j <<= 1)
            {
                s[x[i]] &= ~j;
                lim |= j;
            }
            lim = ~(lim >> 1);
            return (lim);
        }        
    }
}
