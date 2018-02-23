using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class KMPSkipSearch
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, k, kmpStart, per, start, wall, m = ptrn.Length, n = y.Length;

            int[] kmpNext = new int[x.Length];
            int[] list = new int[x.Length];
            int[] mpNext = new int[x.Length];
            int[] z = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreMp(x, ref mpNext);
            PreKmp(x, ref kmpNext);

            for (i = 0; i < z.Length; i++)
                z[i] = -1;
            for (i = 0; i < m; i++)
                list[i] = -1;
            z[x[0]] = 0;
            for (i = 1; i < m; ++i)
            {
                list[i] = z[x[i]];
                z[x[i]] = i;
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            wall = 0;
            per = m - kmpNext[m];
            i = j = -1;
            do
            {
                j += m;
            } while (j < n && z[y[j]] < 0);
            if (j >= n)
            {
                stopwatch.Stop();
                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                return -1;
            }
                
            i = z[y[j]];
            start = j - i;
            while (start <= n - m)
            {
                if (start > wall)
                    wall = start;
                k = Attempt(y, x, start, wall);
                wall = start + k;
                if (k == m)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return start + startIndex;                    
                }
                else
                    i = list[i];
                if (i < 0)
                {
                    do
                    {
                        j += m;
                    } while (j < n && z[y[j]] < 0);
                    if (j >= n)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return -1;
                    }

                    i = z[y[j]];
                }
                kmpStart = start + k - kmpNext[k];
                k = kmpNext[k];
                start = j - i;
                while (start < kmpStart || (kmpStart < start && start < wall))
                {
                    if (start < kmpStart)
                    {
                        i = list[i];
                        if (i < 0)
                        {
                            do
                            {
                                j += m;
                            } while (j < n && z[y[j]] < 0);
                            if (j >= n)
                            {
                                stopwatch.Stop();
                                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                                return -1;
                            }

                            i = z[y[j]];
                        }
                        start = j - i;
                    }
                    else
                    {
                        kmpStart += (k - mpNext[k]);
                        k = mpNext[k];
                    }
                }
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
            int i, j, k, kmpStart, per, start, wall, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] kmpNext = new int[x.Length];
            int[] list = new int[x.Length];
            int[] mpNext = new int[x.Length];
            int[] z = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreMp(x, ref mpNext);
            PreKmp(x, ref kmpNext);

            for (i = 0; i < z.Length; i++)
                z[i] = -1;
            for (i = 0; i < m; i++)
                list[i] = -1;
            z[x[0]] = 0;
            for (i = 1; i < m; ++i)
            {
                list[i] = z[x[i]];
                z[x[i]] = i;
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            wall = 0;
            per = m - kmpNext[m];
            i = j = -1;
            do
            {
                j += m;
            } while (j < n && z[y[j]] < 0);
            if (j >= n)
            {
                stopwatch.Stop();
                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                return result;
            }                
            i = z[y[j]];
            start = j - i;
            while (start <= n - m)
            {
                if (start > wall)
                    wall = start;
                k = Attempt(y, x, start, wall);
                wall = start + k;
                if (k == m)
                {
                    result.Add(start);
                    i -= per;
                }
                else
                    i = list[i];
                if (i < 0)
                {
                    do
                    {
                        j += m;
                    } while (j < n && z[y[j]] < 0);
                    if (j >= n)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return result;
                    }

                    i = z[y[j]];
                }
                kmpStart = start + k - kmpNext[k];
                k = kmpNext[k];
                start = j - i;
                while (start < kmpStart || (kmpStart < start && start < wall))
                {
                    if (start < kmpStart)
                    {
                        i = list[i];
                        if (i < 0)
                        {
                            do
                            {
                                j += m;
                            } while (j < n && z[y[j]] < 0);
                            if (j >= n)
                            {
                                stopwatch.Stop();
                                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                                return result;
                            }

                            i = z[y[j]];
                        }
                        start = j - i;
                    }
                    else
                    {
                        kmpStart += (k - mpNext[k]);
                        k = mpNext[k];
                    }
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }

        private static void PreMp(char[] x, ref int[] mpNext)
        {
            int i, j, m = (x.Length - 1);

            i = 0;
            j = mpNext[0] = -1;
            while (i < m)
            {
                while (j > -1 && x[i] != x[j])
                    j = mpNext[j];
                mpNext[++i] = ++j;
            }
        }

        private static void PreKmp(char[] x, ref int[] kmpNext)
        {
            int i, j, m = (x.Length - 1);

            i = 0;
            j = kmpNext[0] = -1;
            while (i < m)
            {
                while (j > -1 && x[i] != x[j])
                    j = kmpNext[j];
                i++;
                j++;
                if (x[i] == x[j])
                    kmpNext[i] = kmpNext[j];
                else
                    kmpNext[i] = j;
            }
        }

        private static int Attempt(char[] y, char[] x, int start, int wall)
        {
            int k, m = (x.Length - 1);

            k = wall - start;
            while (k < m && x[k] == y[k + start])
                ++k;
            return (k);
        }        
    }
}
