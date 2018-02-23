using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class TunedBoyerMoore
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), src = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] y = new char[src.Length + x.Length];
            Array.Copy(src, 0, y, 0, src.Length);
            int j, k, shift, m = x.Length, n = src.Length;

            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmBc(x, ref bmBc);
            shift = bmBc[x[m - 1]];
            bmBc[x[m - 1]] = 0;
            for (int i = 0; i < m; i++)
                y[n + i] = x[m - 1];

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n)
            {
                k = bmBc[y[j + m - 1]];
                while (k != 0)
                {
                    j += k;
                    k = bmBc[y[j + m - 1]];
                    j += k;
                    k = bmBc[y[j + m - 1]];
                    j += k;
                    k = bmBc[y[j + m - 1]];
                }
                if (ArrayCmp(x, 0, y, j, (m - 1)) == 0 && j + m - 1 < n)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }

                j += shift; /* shift */
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), src = source.ToCharArray();
            char[] y = new char[src.Length + x.Length];
            Array.Copy(src, 0, y, 0, src.Length);
            int j, k, shift, m = x.Length, n = src.Length;
            List<int> result = new List<int>();

            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmBc(x, ref bmBc);
            shift = bmBc[x[m - 1]];
            bmBc[x[m - 1]] = 0;
            for (int i = 0; i < m; i++)
                y[n + i] = x[m - 1];

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j < n)
            {
                k = bmBc[y[j + m - 1]];
                while (k != 0)
                {
                    j += k;
                    k = bmBc[y[j + m - 1]];
                    j += k;
                    k = bmBc[y[j + m - 1]];
                    j += k;
                    k = bmBc[y[j + m - 1]];
                }
                if (ArrayCmp(x, 0, y, j, (m - 1)) == 0 && j + m - 1 < n)
                    result.Add(j);
                j += shift; /* shift */
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

        private static int ArrayCmp(char[] a, int aIdx, char[] b, int bIdx, int length)
        {
            int i = 0;

            for (i = 0; i < length && aIdx + i < a.Length && bIdx + i < b.Length; i++)
            {
                if (a[aIdx + i] == b[bIdx + i])
                    continue;
                else if (a[aIdx + i] > b[bIdx + i])
                    return 1;
                else
                    return 2;
            }

            if (i < length)
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
