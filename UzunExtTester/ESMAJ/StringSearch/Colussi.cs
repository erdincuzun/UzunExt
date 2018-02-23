using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class Colussi
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, last, nd, m = ptrn.Length, n = y.Length;

            int[] h = new int[x.Length];
            int[] next = new int[x.Length];
            int[] shift = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Processing */
            nd = PreColussi(x, ref h, ref next, ref shift);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            i = j = 0;
            last = -1;
            while (j <= n - m)
            {
                while (i < m && last < j + h[i] && x[h[i]] == y[j + h[i]])
                    i++;
                if (i >= m || last >= j + h[i])
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                if (i > nd)
                    last = j + m - 1;
                j += shift[i];
                i = next[i];
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray();
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, last, nd, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] h = new int[x.Length];
            int[] next = new int[x.Length];
            int[] shift = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Processing */
            nd = PreColussi(x, ref h, ref next, ref shift);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            i = j = 0;
            last = -1;
            while (j <= n - m)
            {
                while (i < m && last < j + h[i] && x[h[i]] == y[j + h[i]])
                    i++;
                if (i >= m || last >= j + h[i])
                {
                    result.Add(j);
                    i = m;
                }
                if (i > nd)
                    last = j + m - 1;
                j += shift[i];
                i = next[i];
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }

        private static int PreColussi(char[] x, ref int[] h, ref int[] next, ref int[] shift)
        {
            int i, k, nd, q, r = 0, s, m = (x.Length - 1);
            int[] hmax = new int[x.Length];
            int[] kmin = new int[x.Length];
            int[] nhd0 = new int[x.Length];
            int[] rmin = new int[x.Length];

            /* Computation of hmax */
            i = k = 1;
            do
            {
                while (i <= m && x[i] == x[i - k])
                    i++;
                hmax[k] = i;
                q = k + 1;
                while (hmax[q - k] + k < i)
                {
                    hmax[q] = hmax[q - k] + k;
                    q++;
                }
                k = q;
                if (k == i + 1)
                    i = k;
            } while (k <= m && i <= m);

            /* Computation of kmin */
            for (i = 0; i < m; i++)
                kmin[i] = 0;
            for (i = m; i >= 1; --i)
                if (hmax[i] < m)
                    kmin[hmax[i]] = i;

            /* Computation of rmin */
            for (i = m - 1; i >= 0; --i)
            {
                if (hmax[i + 1] == m)
                    r = i + 1;
                if (kmin[i] == 0)
                    rmin[i] = r;
                else
                    rmin[i] = 0;
            }

            /* Computation of h */
            s = -1;
            r = m;
            for (i = 0; i < m; ++i)
                if (kmin[i] == 0)
                    h[--r] = i;
                else
                    h[++s] = i;
            nd = s;

            /* Computation of shift */
            for (i = 0; i <= nd; ++i)
                shift[i] = kmin[h[i]];
            for (i = nd + 1; i < m; ++i)
                shift[i] = rmin[h[i]];
            shift[m] = rmin[0];

            /* Computation of nhd0 */
            s = 0;
            for (i = 0; i < m; ++i)
            {
                nhd0[i] = s;
                if (kmin[i] > 0)
                    ++s;
            }

            /* Computation of next */
            for (i = 0; i <= nd; ++i)
                next[i] = nhd0[h[i] - kmin[h[i]]];
            for (i = nd + 1; i < m; ++i)
                next[i] = nhd0[m - rmin[h[i]]];
            next[m] = nhd0[m - rmin[h[m - 1]]];

            return (nd);
        }        
    }
}
