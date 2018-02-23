using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class StringMatchingonOrderedAlphabets
    {
        public static double preProcessTime;
        public static double searchTime;

        /* String matching on ordered alphabets algorithm. */
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, m = x.Length, n = y.Length;
            int[] ip = new int[1], jp = new int[1], k = new int[1], p = new int[1];

            preProcessTime = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Searching */
            ip[0] = -1;
            i = j = jp[0] = 0;
            k[0] = p[0] = 1;
            while (j <= n - m)
            {
                while (i + j < n && i < m && x[i] == y[i + j])
                    ++i;
                if (i == 0)
                {
                    ++j;
                    ip[0] = -1;
                    jp[0] = 0;
                    k[0] = p[0] = 1;
                }
                else
                {
                    if (i >= m)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return j + startIndex;
                    }
                    NextMaximalSuffix(y, j, i + 1, ref ip, ref jp, ref k, ref p);
                    if (ip[0] < 0
                            || (ip[0] < p[0] && ArrayCmp(y, j, y, j + p[0],
                                    ip[0] + 1) == 0))
                    {
                        j += p[0];
                        i -= p[0];
                        if (i < 0)
                            i = 0;
                        if (jp[0] - ip[0] > p[0])
                            jp[0] -= p[0];
                        else
                        {
                            ip[0] = -1;
                            jp[0] = 0;
                            k[0] = p[0] = 1;
                        }
                    }
                    else
                    {
                        j += (Math.Max(ip[0] + 1, Math.Min(i - ip[0] - 1, jp[0] + 1)) + 1);
                        i = jp[0] = 0;
                        ip[0] = -1;
                        k[0] = p[0] = 1;
                    }
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, m = x.Length, n = y.Length;
            int[] ip = new int[1], jp = new int[1], k = new int[1], p = new int[1];
            List<int> result = new List<int>();
            preProcessTime = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Searching */
            ip[0] = -1;
            i = j = jp[0] = 0;
            k[0] = p[0] = 1;
            while (j <= n - m)
            {
                while (i + j < n && i < m && x[i] == y[i + j])
                    ++i;
                if (i == 0)
                {
                    ++j;
                    ip[0] = -1;
                    jp[0] = 0;
                    k[0] = p[0] = 1;
                }
                else
                {
                    if (i >= m)
                        result.Add(j);
                    NextMaximalSuffix(y, j, i + 1, ref ip, ref jp, ref k, ref p);
                    if (ip[0] < 0
                            || (ip[0] < p[0] && ArrayCmp(y, j, y, j + p[0],
                                    ip[0] + 1) == 0))
                    {
                        j += p[0];
                        i -= p[0];
                        if (i < 0)
                            i = 0;
                        if (jp[0] - ip[0] > p[0])
                            jp[0] -= p[0];
                        else
                        {
                            ip[0] = -1;
                            jp[0] = 0;
                            k[0] = p[0] = 1;
                        }
                    }
                    else
                    {
                        j += (Math.Max(ip[0] + 1, Math.Min(i - ip[0] - 1, jp[0] + 1)) + 1);
                        i = jp[0] = 0;
                        ip[0] = -1;
                        k[0] = p[0] = 1;
                    }
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

        /* Compute the next maximal suffix. */
        private static void NextMaximalSuffix(char[] y, int yIdx, int m, ref int[] i, ref int[] j, ref int[] k, ref int[] p)
        {
            char a, b;
            int c = y.Length;

            while (j[0] + k[0] < m && yIdx + i[0] + k[0] < c && yIdx + j[0] + k[0] < c)
            {
                a = y[yIdx + i[0] + k[0]];
                b = y[yIdx + j[0] + k[0]];
                if (a == b)
                    if (k[0] == p[0])
                    {
                        (j[0]) += p[0];
                        k[0] = 1;
                    }
                    else
                        ++(k[0]);
                else if (a > b)
                {
                    (j[0]) += k[0];
                    k[0] = 1;
                    p[0] = j[0] - i[0];
                }
                else
                {
                    i[0] = j[0];
                    ++(j[0]);
                    k[0] = p[0] = 1;
                }
            }
        }        
    }
}
