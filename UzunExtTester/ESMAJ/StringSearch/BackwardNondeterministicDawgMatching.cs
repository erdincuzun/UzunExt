using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class BackwardNondeterministicDawgMatching
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, s, d, last, m = x.Length, n = y.Length;

            int[] b = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Pre processing */
            for (i = 0; i < b.Length; i++)
                b[i] = 0;
            s = 1;
            for (i = m - 1; i >= 0; i--)
            {
                b[x[i]] |= s;
                s <<= 1;
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching phase */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                last = m;
                d = ~0;
                while (i >= 0 && d != 0)
                {
                    d &= b[y[j + i]];
                    i--;
                    if (d != 0)
                    {
                        if (i >= 0)
                            last = i + 1;
                        else
                        {
                            stopwatch.Stop();
                            searchTime = stopwatch.Elapsed.TotalMilliseconds;
                            return j + startIndex;
                        }
                    }
                    d <<= 1;
                }
                j += last;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, s, d, last, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            int[] b = new int[65536];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Pre processing */
            for (i = 0; i < b.Length; i++)
                b[i] = 0;
            s = 1;
            for (i = m - 1; i >= 0; i--)
            {
                b[x[i]] |= s;
                s <<= 1;
            }

            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching phase */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                last = m;
                d = ~0;
                while (i >= 0 && d != 0)
                {
                    d &= b[y[j + i]];
                    i--;
                    if (d != 0)
                    {
                        if (i >= 0)
                            last = i + 1;
                        else
                            result.Add(j);
                    }
                    d <<= 1;
                }
                j += last;
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
    }
}
