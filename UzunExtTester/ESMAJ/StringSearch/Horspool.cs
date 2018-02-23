using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMAJ.StringSearch
{
    public class Horspool
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int j, m = x.Length, n = y.Length;

            char c;

            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmBc(x, ref bmBc);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                c = y[j + m - 1];
                if (x[m - 1] == c && ArrayCmp(x, 0, y, j, (m - 1)) == 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                    
                j += bmBc[c];
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int j, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            char c;

            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmBc(x, ref bmBc);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                c = y[j + m - 1];
                if (x[m - 1] == c && ArrayCmp(x, 0, y, j, (m - 1)) == 0)
                    result.Add(j);
                j += bmBc[c];
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return result;
        }

        private static void PreBmBc(char[] x, ref int[] bmBc)
        {
            int i, m = x.Length;

            for (i = 0; i < bmBc.Length; ++i)
                bmBc[i] = m;
            for (i = 0; i < m - 1; ++i)
                bmBc[x[i]] = m - i - 1;
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
