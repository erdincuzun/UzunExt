using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class KnuthMorrisPratt
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, m = ptrn.Length, n = y.Length;

            int[] kmpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreKmp(x, ref kmpNext);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            i = j = 0;
            while (j < n)
            {
                while (i > -1 && x[i] != y[j])
                    i = kmpNext[i];
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

            int[] kmpNext = new int[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreKmp(x, ref kmpNext);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            i = j = 0;
            while (j < n)
            {
                while (i > -1 && x[i] != y[j])
                    i = kmpNext[i];
                i++;
                j++;
                if (i >= m)
                {
                    result.Add(j - i);
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
