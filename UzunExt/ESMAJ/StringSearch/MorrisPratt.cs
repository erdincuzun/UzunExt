using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class MorrisPratt
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, m = ptrn.Length, n = y.Length;

            int[] mpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreMp(x, ref mpNext);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            i = j = 0;
            while (j < n)
            {
                while (i > -1 && x[i] != y[j])
                    i = mpNext[i];
                i++;
                j++;
                if (i >= m)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j - i + startIndex;
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
            int i, j, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] mpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreMp(x, ref mpNext);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            i = j = 0;
            while (j < n)
            {
                while (i > -1 && x[i] != y[j])
                    i = mpNext[i];
                i++;
                j++;
                if (i >= m)
                {
                    result.Add(j - i);
                    i = mpNext[i];
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
    }
}
