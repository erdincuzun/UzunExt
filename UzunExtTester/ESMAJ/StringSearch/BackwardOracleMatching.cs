using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class BackwardOracleMatching
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int i, j, p, period = 0, q, shift, m = ptrn.Length, n = y.Length;

            bool[] t = new bool[x.Length];
            Cell[] list = new Cell[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            for (i = 0; i < t.Length; i++)
                t[i] = false;
            Oracle(x, ref t, ref list);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                p = m;
                shift = m;
                while (i + j >= 0
                        && (q = GetTransition(x, p, list, y[i + j])) != -1)
                {
                    p = q;
                    if (t[p] == true)
                    {
                        period = shift;
                        shift = i;
                    }
                    --i;
                }
                if (i < 0)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                j += shift;
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
            int i, j, p, period = 0, q, shift, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();

            bool[] t = new bool[x.Length];
            Cell[] list = new Cell[x.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            for (i = 0; i < t.Length; i++)
                t[i] = false;
            Oracle(x, ref t, ref list);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                p = m;
                shift = m;
                while (i + j >= 0
                        && (q = GetTransition(x, p, list, y[i + j])) != -1)
                {
                    p = q;
                    if (t[p] == true)
                    {
                        period = shift;
                        shift = i;
                    }
                    --i;
                }
                if (i < 0)
                {
                    result.Add(j);
                    shift = period;
                }
                j += shift;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static int GetTransition(char[] x, int p, Cell[] list, char c)
        {
            Cell cell;

            if (p > 0 && x[p - 1] == c)
                return (p - 1);
            else
            {
                cell = list[p];
                while (cell != null)
                    if (x[cell.element] == c)
                        return (cell.element);
                    else
                        cell = cell.next;
                return -1;
            }
        }

        private static void SetTransition(int p, int q, ref Cell[] list)
        {
            Cell cell = new Cell();

            cell.element = q;
            cell.next = list[p];
            list[p] = cell;
        }

        private static void Oracle(char[] x, ref bool[] t, ref Cell[] list)
        {
            int i, p, q = -1, m = x.Length - 1;
            int[] s = new int[x.Length];
            char c;

            s[m] = m + 1;
            for (i = m; i > 0; --i)
            {
                c = x[i - 1];
                p = s[i];
                while (p <= m && (q = GetTransition(x, p, list, c)) == -1)
                {
                    SetTransition(p, i - 1, ref list);
                    p = s[p];
                }
                s[i - 1] = (p == m + 1 ? m : q);
            }
            p = 0;
            while (p <= m)
            {
                t[p] = true;
                p = s[p];
            }
        }        
    }
}
