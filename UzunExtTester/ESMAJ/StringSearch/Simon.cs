using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class Simon
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int j, ell, state, m = x.Length, n = y.Length;
            Cell[] list = new Cell[m];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            ell = PreSimon(x, list);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (state = -1, j = 0; j < n; ++j)
            {
                state = GetTransition(x, state, list, y[j]);
                if (state >= m - 1)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j - m + 1 + startIndex;
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int j, ell, state, m = x.Length, n = y.Length;
            Cell[] list = new Cell[m];
            List<int> result = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            ell = PreSimon(x, list);

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (state = -1, j = 0; j < n; ++j)
            {
                state = GetTransition(x, state, list, y[j]);
                if (state >= m - 1)
                {
                    result.Add(j - m + 1);
                    state = ell;
                }
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static int GetTransition(char[] x, int p, Cell[] lst, char c)
        {
            int m = x.Length;
            Cell cell;

            if (p < m - 1 && x[p + 1] == c)
                return (p + 1);
            else if (p > -1)
            {
                cell = lst[p];
                while (cell != null)
                    if (x[cell.element] == c)
                        return (cell.element);
                    else
                        cell = cell.next;
                return (-1);
            }
            else
                return (-1);
        }

        private static void SetTransition(int p, int q, Cell[] list)
        {
            Cell cell = new Cell();

            cell.element = q;
            cell.next = list[p];
            list[p] = cell;
        }

        private static int PreSimon(char[] x, Cell[] list)
        {
            int i, k, ell, m = x.Length;
            Cell cell;

            for (i = 0; i < (m - 2); i++)
                list[i] = null;
            ell = -1;
            for (i = 1; i < m; ++i)
            {
                k = ell;
                cell = (ell == -1 ? null : list[k]);
                ell = -1;
                if (x[i] == x[k + 1])
                    ell = k + 1;
                else
                    SetTransition(i - 1, k + 1, list);
                while (cell != null)
                {
                    k = cell.element;
                    if (x[i] == x[k])
                        ell = k;
                    else
                        SetTransition(i - 1, k, list);
                    cell = cell.next;
                }
            }
            return (ell);
        }       
    }
}
