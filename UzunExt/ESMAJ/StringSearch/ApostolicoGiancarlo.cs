using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class ApostolicoGiancarlo
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, k, s, shift, m = x.Length, n = y.Length;

            int[] bmGs = new int[m];
            int[] skip = new int[m];
            int[] suff = new int[m];
            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmGs(x, ref bmGs, ref suff);
            PreBmBc(x, ref bmBc);

            for (i = 0; i < m; i++)
                skip[i] = 0;

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                while (i >= 0)
                {
                    k = skip[i];
                    s = suff[i];
                    if (k > 0)
                        if (k > s)
                        {
                            if (i + 1 == s)
                                i = (-1);
                            else
                                i -= s;
                            break;
                        }
                        else
                        {
                            i -= k;
                            if (k < s)
                                break;
                        }
                    else
                    {
                        if (x[i] == y[i + j])
                            --i;
                        else
                            break;
                    }
                }
                if (i < 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                    //result.Add(j);
                    //skip[m - 1] = m;
                    //shift = bmGs[0];
                }
                else
                {
                    skip[m - 1] = m - 1 - i;
                    shift = Math.Max(bmGs[i], bmBc[y[i + j]] - m + 1 + i);
                }
                j += shift;
                ArrayCpy(skip, 0, skip, shift, (m - shift));
                for (i = 0; i < shift; i++)
                    skip[m - shift + i] = 0;
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, k, s, shift, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] bmGs = new int[m];
            int[] skip = new int[m];
            int[] suff = new int[m];
            int[] bmBc = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBmGs(x, ref bmGs, ref suff);
            PreBmBc(x, ref bmBc);

            for (i = 0; i < m; i++)
                skip[i] = 0;

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                while (i >= 0)
                {
                    k = skip[i];
                    s = suff[i];
                    if (k > 0)
                        if (k > s)
                        {
                            if (i + 1 == s)
                                i = (-1);
                            else
                                i -= s;
                            break;
                        }
                        else
                        {
                            i -= k;
                            if (k < s)
                                break;
                        }
                    else
                    {
                        if (x[i] == y[i + j])
                            --i;
                        else
                            break;
                    }
                }
                if (i < 0)
                {
                    result.Add(j);
                    skip[m - 1] = m;
                    shift = bmGs[0];
                }
                else
                {
                    skip[m - 1] = m - 1 - i;
                    shift = Math.Max(bmGs[i], bmBc[y[i + j]] - m + 1 + i);
                }
                j += shift;
                ArrayCpy(skip, 0, skip, shift, (m - shift));
                for (i = 0; i < shift; i++)
                    skip[m - shift + i] = 0;
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

        private static void PreBmGs(char[] x, ref int[] bmGs, ref int[] suff)
        {
            int i, j, m = x.Length;

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

        private static void ArrayCpy(int[] trg, int trgIdx, int[] src, int srcIdx, int length)
        {
            for (int i = 0; i < length; i++)
                trg[trgIdx + i] = src[srcIdx + i];
        }
    }
}
