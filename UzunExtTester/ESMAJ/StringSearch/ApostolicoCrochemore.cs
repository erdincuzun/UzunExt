using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class ApostolicoCrochemore
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, k, ell, m = ptrn.Length, n = y.Length;

            int[] kmpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreKmp(x, ref kmpNext);
            for (ell = 1; x[ell - 1] == x[ell]; ell++) ;
            if (ell == m)
                ell = 0;
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            /* Searching */
            i = ell;
            j = k = 0;
            while (j <= n - m)
            {
                while (i < m && x[i] == y[i + j])
                    ++i;
                if (i >= m)
                {
                    while (k < ell && x[k] == y[j + k])
                        ++k;
                    if (k >= ell)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return j + startIndex;
                    }
                }
                j += (i - kmpNext[i]);
                if (i == ell)
                    k = Math.Max(0, k - 1);
                else if (kmpNext[i] <= ell)
                {
                    k = Math.Max(0, kmpNext[i]);
                    i = ell;
                }
                else
                {
                    k = ell;
                    i = kmpNext[i];
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
            int i, j, k, ell, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] kmpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreKmp(x, ref kmpNext);
            for (ell = 1; x[ell - 1] == x[ell]; ell++) ;
            if (ell == m)
                ell = 0;

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            i = ell;
            j = k = 0;
            while (j <= n - m)
            {
                while (i < m && x[i] == y[i + j])
                    ++i;
                if (i >= m)
                {
                    while (k < ell && x[k] == y[j + k])
                        ++k;
                    if (k >= ell)
                        result.Add(j);
                }
                j += (i - kmpNext[i]);
                if (i == ell)
                    k = Math.Max(0, k - 1);
                else if (kmpNext[i] <= ell)
                {
                    k = Math.Max(0, kmpNext[i]);
                    i = ell;
                }
                else
                {
                    k = ell;
                    i = kmpNext[i];
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return result;
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
    }
}

