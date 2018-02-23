using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class BerryRavindran
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), src = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] y = new char[src.Length + 2];
            Array.Copy(src, 0, y, 0, src.Length);
            int j, m = x.Length, n = src.Length;

            if (CalculateBrBcSize(x, src) > 256)
                return -1;

            int[,] brBc = new int[256, 256];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBrBc(x, ref brBc);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            y[n + 1] = '\0';
            while (j < n - m)
            {
                if (ArrayCmp(x, 0, y, j, m) == 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                j += brBc[y[j + m], y[j + m + 1]];
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
            {
                stopwatch.Stop();
                searchTime = stopwatch.Elapsed.TotalMilliseconds;
                return j + startIndex;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }

        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), src = source.ToCharArray();
            char[] y = new char[src.Length + 2];
            Array.Copy(src, 0, y, 0, src.Length);
            int j, m = x.Length, n = src.Length;
            List<int> result = new List<int>();

            if (CalculateBrBcSize(x, src) > 256)
                return null;

            int[,] brBc = new int[256, 256];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            PreBrBc(x, ref brBc);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            y[n + 1] = '\0';
            while (j < n - m)
            {
                if (ArrayCmp(x, 0, y, j, m) == 0)
                    result.Add(j);
                j += brBc[y[j + m], y[j + m + 1]];
            }
            if (j == n - m && ArrayCmp(x, 0, y, j, m) == 0)
                result.Add(j);

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static void PreBrBc(char[] x, ref int[,] brBc)
        {
            int a, b, i, m = x.Length;

            for (a = 0; a < brBc.GetLength(0); ++a)
                for (b = 0; b < brBc.GetLength(1); ++b)
                    brBc[a, b] = m + 2;
            for (a = 0; a < brBc.GetLength(0); ++a)
                brBc[a, x[0]] = m + 1;
            for (i = 0; i < m - 1; ++i)
                brBc[x[i], x[i + 1]] = m - i;
            for (a = 0; a < brBc.GetLength(0); ++a)
                brBc[x[m - 1],a] = 1;
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

        private static int CalculateBrBcSize(char[] x, char[] y)
        {
            int i;
            char maxChar = (char)0;
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
