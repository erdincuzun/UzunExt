using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class ReverseColussi
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, s, m = ptrn.Length, n = y.Length;

            int[,] rcBc = new int[65536, x.Length];
            int[] rcGs = new int[x.Length];
            int[] h = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreRc(x, ref h, ref rcBc, ref rcGs);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            s = m;
            while (j <= n - m)
            {
                while (j <= n - m && x[m - 1] != y[j + m - 1])
                {
                    s = rcBc[y[j + m - 1], s];
                    j += s;
                }
                for (i = 1; i < m && j + h[i] < n && x[h[i]] == y[j + h[i]]; ++i)
                    ;
                if (j <= n - m && i >= m)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                s = rcGs[i];
                j += s;
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
            int i, j, s, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            int[,] rcBc = new int[65536, x.Length];
            int[] rcGs = new int[x.Length];
            int[] h = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreRc(x, ref h, ref rcBc, ref rcGs);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            s = m;
            while (j <= n - m)
            {
                while (j <= n - m && x[m - 1] != y[j + m - 1])
                {
                    s = rcBc[y[j + m - 1], s];
                    j += s;
                }
                for (i = 1; i < m && j + h[i] < n && x[h[i]] == y[j + h[i]]; ++i)
                    ;
                if (j <= n - m && i >= m)
                    result.Add(j);
                s = rcGs[i];
                j += s;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static void PreRc(char[] x, ref int[] h, ref int[,] rcBc, ref int[] rcGs)
        {
            int a, i, j, k, q, r = 0, s, m = (x.Length - 1);

            int[] hmin = new int[x.Length];
            int[] kmin = new int[x.Length];
            int[] link = new int[x.Length];
            int[] locc = new int[rcBc.GetLength(0)];
            int[] rmin = new int[x.Length];

            /* Computation of link and locc */
            for (a = 0; a < locc.Length; ++a)
                locc[a] = -1;
            link[0] = -1;
            for (i = 0; i < m - 1; ++i)
            {
                link[i + 1] = locc[x[i]];
                locc[x[i]] = i;
            }

            /* Computation of rcBc */
            for (a = 0; a < locc.Length; ++a)
                for (s = 1; s <= m; ++s)
                {
                    i = locc[a];
                    j = link[m - s];
                    while (i - j != s && j >= 0)
                        if (i - j > s)
                            i = link[i + 1];
                        else
                            j = link[j + 1];
                    while (i - j > s)
                        i = link[i + 1];
                    rcBc[a, s] = m - i - 1;
                }

            /* Computation of hmin */
            k = 1;
            i = m - 1;
            while (k <= m)
            {
                while (i - k >= 0 && x[i - k] == x[i])
                    --i;
                hmin[k] = i;
                q = k + 1;
                while (hmin[q - k] - (q - k) > i)
                {
                    hmin[q] = hmin[q - k];
                    ++q;
                }
                i += (q - k);
                k = q;
                if (i == m)
                    i = m - 1;
            }

            /* Computation of kmin */
            for (i = 0; i < m; i++)
                kmin[i] = 0;
            for (k = m; k > 0; --k)
                kmin[hmin[k]] = k;

            /* Computation of rmin */
            for (i = m - 1; i >= 0; --i)
            {
                if (hmin[i + 1] == i)
                    r = i + 1;
                rmin[i] = r;
            }

            /* Computation of rcGs */
            i = 1;
            for (k = 1; k <= m; ++k)
                if (hmin[k] != m - 1 && kmin[hmin[k]] == k)
                {
                    h[i] = hmin[k];
                    rcGs[i++] = k;
                }
            i = m - 1;
            for (j = m - 2; j >= 0; --j)
                if (kmin[j] == 0)
                {
                    h[i] = j;
                    rcGs[i--] = rmin[j];
                }
            rcGs[m] = rmin[0];
        }        
    }
}
