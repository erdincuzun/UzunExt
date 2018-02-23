using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class TwoWay
    {
        public static double preProcessTime;
        public static double searchTime;

        /* Two Way string matching algorithm. */
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, ell, memory, per, m = x.Length, n = y.Length;
            int[] p = new int[1], q = new int[1];
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            i = MaxSuf(x, ref p);
            j = MaxSufTilde(x, ref q);
            if (i > j)
            {
                ell = i;
                per = p[0];
            }
            else
            {
                ell = j;
                per = q[0];
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            if (ArrayCmp(x, 0, x, per, ell + 1) == 0)
            {
                j = 0;
                memory = -1;
                while (j <= n - m)
                {
                    i = Math.Max(ell, memory) + 1;
                    while (i < m && x[i] == y[i + j])
                        ++i;
                    if (i >= m)
                    {
                        i = ell;
                        while (i > memory && x[i] == y[i + j])
                            --i;
                        if (i <= memory)
                        {
                            stopwatch.Stop();
                            searchTime = stopwatch.Elapsed.TotalMilliseconds;
                            return j + startIndex;
                        }
                        j += per;
                        memory = m - per - 1;
                    }
                    else
                    {
                        j += (i - ell);
                        memory = -1;
                    }
                }
            }
            else
            {
                per = Math.Max(ell + 1, m - ell - 1) + 1;
                j = 0;
                while (j <= n - m)
                {
                    i = ell + 1;
                    while (i < m && x[i] == y[i + j])
                        ++i;
                    if (i >= m)
                    {
                        i = ell;
                        while (i >= 0 && x[i] == y[i + j])
                            --i;
                        if (i < 0)
                        {
                            stopwatch.Stop();
                            searchTime = stopwatch.Elapsed.TotalMilliseconds;
                            return j + startIndex;
                        }
                        j += per;
                    }
                    else
                        j += (i - ell);
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, ell, memory, per, m = x.Length, n = y.Length;
            int[] p = new int[1], q = new int[1];
            List<int> result = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            i = MaxSuf(x, ref p);
            j = MaxSufTilde(x, ref q);
            if (i > j)
            {
                ell = i;
                per = p[0];
            }
            else
            {
                ell = j;
                per = q[0];
            }
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            if (ArrayCmp(x, 0, x, per, ell + 1) == 0)
            {
                j = 0;
                memory = -1;
                while (j <= n - m)
                {
                    i = Math.Max(ell, memory) + 1;
                    while (i < m && x[i] == y[i + j])
                        ++i;
                    if (i >= m)
                    {
                        i = ell;
                        while (i > memory && x[i] == y[i + j])
                            --i;
                        if (i <= memory)
                            result.Add(j);
                        j += per;
                        memory = m - per - 1;
                    }
                    else
                    {
                        j += (i - ell);
                        memory = -1;
                    }
                }
            }
            else
            {
                per = Math.Max(ell + 1, m - ell - 1) + 1;
                j = 0;
                while (j <= n - m)
                {
                    i = ell + 1;
                    while (i < m && x[i] == y[i + j])
                        ++i;
                    if (i >= m)
                    {
                        i = ell;
                        while (i >= 0 && x[i] == y[i + j])
                            --i;
                        if (i < 0)
                            result.Add(j);
                        j += per;
                    }
                    else
                        j += (i - ell);
                }
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

        /* Computing of the maximal suffix for <= */
        private static int MaxSuf(char[] x, ref int[] p)
        {
            int ms, j, k, m = x.Length;
            char a, b;

            ms = -1;
            j = 0;
            k = p[0] = 1;
            while (j + k < m)
            {
                a = x[j + k];
                b = x[ms + k];
                if (a < b)
                {
                    j += k;
                    k = 1;
                    p[0] = j - ms;
                }
                else if (a == b)
                    if (k != p[0])
                        ++k;
                    else
                    {
                        j += p[0];
                        k = 1;
                    }
                else
                { /* a > b */
                    ms = j;
                    j = ms + 1;
                    k = p[0] = 1;
                }
            }
            return (ms);
        }

        /* Computing of the maximal suffix for >= */
        private static int MaxSufTilde(char[] x, ref int[] p)
        {
            int ms, j, k, m = x.Length;
            char a, b;

            ms = -1;
            j = 0;
            k = p[0] = 1;
            while (j + k < m)
            {
                a = x[j + k];
                b = x[ms + k];
                if (a > b)
                {
                    j += k;
                    k = 1;
                    p[0] = j - ms;
                }
                else if (a == b)
                    if (k != p[0])
                        ++k;
                    else
                    {
                        j += p[0];
                        k = 1;
                    }
                else
                { /* a < b */
                    ms = j;
                    j = ms + 1;
                    k = p[0] = 1;
                }
            }
            return (ms);
        }       
    }
}
