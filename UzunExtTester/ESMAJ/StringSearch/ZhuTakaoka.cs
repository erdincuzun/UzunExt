using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class ZhuTakaoka
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, m = x.Length, n = y.Length;
            preProcessTime = 0;
            searchTime = 0;
            if (calculateZtBcSize(x, y) > 256)
                return -1;

            int[,] ztBc = new int[256, 256];
            int[] bmGs = new int[m];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            /* Preprocessing */
            PreZtBc(x, ref ztBc);
            preBmGs(x, ref bmGs);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                while (i >= 0 && x[i] == y[i + j])
                    --i;
                if (i < 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                else if (j + m - 2 >= 0)
                {
                    j += Math.Max(bmGs[i], ztBc[y[j + m - 2], y[j + m - 1]]);
                }
                else
                    j += bmGs[i];
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

            if (calculateZtBcSize(x, y) > 256)
                return null;

            int[,] ztBc = new int[256, 256];
            int[] bmGs = new int[m];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            /* Preprocessing */
            PreZtBc(x, ref ztBc);
            preBmGs(x, ref bmGs);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                while (i >= 0 && x[i] == y[i + j])
                    --i;
                if (i < 0)
                {
                    result.Add(j);
                    j += bmGs[0];
                }
                else if (j + m - 2 >= 0)
                {
                    j += Math.Max(bmGs[i], ztBc[y[j + m - 2], y[j + m - 1]]);
                }
                else
                    j += bmGs[i];
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static void PreZtBc(char[] x, ref int[,] ztBc)
        {
            int i, j, m = x.Length, z = ztBc.GetLength(0);

            for (i = 0; i < z; ++i)
                for (j = 0; j < z; ++j)
                    ztBc[i, j] = m;
            for (i = 0; i < z; ++i)
                ztBc[i, x[0]] = m - 1;
            for (i = 1; i < m - 1; ++i)
                ztBc[x[i - 1], x[i]] = m - 1 - i;
        }

        private static void Suffixes(char[] x, ref int[] suff)
        {
            int f = 0, g, i, m = x.Length;

            suff[m - 1] = m;
            g = m - 1;
            for (i = m - 2; i >= 0; --i)
            {
                if (i > g && suff[i + m - 1 - f] < i - g)
                    suff[i] = suff[i + m - 1 - f];
                else
                {
                    if (i < g)
                        g = i;
                    f = i;
                    while (g >= 0 && x[g] == x[g + m - 1 - f])
                        --g;
                    suff[i] = f - g;
                }
            }
        }

        private static void preBmGs(char[] x, ref int[] bmGs)
        {
            int i, j, m = x.Length;
            int[] suff = new int[m];

            Suffixes(x, ref suff);

            for (i = 0; i < m; ++i)
                bmGs[i] = m;
            j = 0;
            for (i = m - 1; i >= 0; --i)
                if (suff[i] == i + 1)
                    for (; j < m - 1 - i; ++j)
                        if (bmGs[j] == m)
                            bmGs[j] = m - 1 - i;
            for (i = 0; i <= m - 2; ++i)
                bmGs[m - 1 - suff[i]] = m - 1 - i;
        }

        private static int calculateZtBcSize(char[] x, char[] y)
        {
            int i;
            int maxChar = 0;
            for (i = 0; i < x.Length; i++)
                if (x[i] > maxChar)
                    maxChar = x[i];
            for (i = 0; i < y.Length; i++)
                if (y[i] > maxChar)
                    maxChar = y[i];
            maxChar++;
            return maxChar;
        }
    }
}
