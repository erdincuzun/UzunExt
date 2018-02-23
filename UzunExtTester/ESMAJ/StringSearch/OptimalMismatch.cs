using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class OptimalMismatch
    {
        public static double preProcessTime;
        public static double searchTime;

        /* Optimal Mismatch string matching algorithm. */
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int i, j, m = x.Length, n = y.Length;
            int[] adaptedGs = new int[m + 1], qsBc = new int[65536], freq = CalculateCharFreq(x, y, 65536);
            Pattern[] pat = new Pattern[m];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            OrderPattern(x, ref pat, freq);
            PreQsBc(x, ref qsBc);
            PreAdaptedGs(x, ref adaptedGs, pat);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = 0;
                while (i < m && pat[i].c == y[j + pat[i].loc])
                    ++i;
                if (i >= m)
                {
                    stopwatch.Stop();
                    searchTime = stopwatch.Elapsed.TotalMilliseconds;
                    return j + startIndex;
                }
                    
                if (j < n - m)
                    j += Math.Max(adaptedGs[i], qsBc[y[j + m]]);
                else
                    j += adaptedGs[i];
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int i, j, m = x.Length, n = y.Length;
            int[] adaptedGs = new int[m + 1], qsBc = new int[65536], freq = CalculateCharFreq(x, y, 65536);
            Pattern[] pat = new Pattern[m];
            List<int> result = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            OrderPattern(x, ref pat, freq);
            PreQsBc(x, ref qsBc);
            PreAdaptedGs(x, ref adaptedGs, pat);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();

            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = 0;
                while (i < m && pat[i].c == y[j + pat[i].loc])
                    ++i;
                if (i >= m)
                    result.Add(j);
                if (j < n - m)
                    j += Math.Max(adaptedGs[i], qsBc[y[j + m]]);
                else
                    j += adaptedGs[i];
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }

        /* Construct an ordered pattern from a string. */
        private static void OrderPattern(char[] x, ref Pattern[] pat, int[] freq)
        {

            for (int i = 0; i < x.Length; ++i)
            {
                Pattern ptrn = new Pattern();
                ptrn.loc = i;
                ptrn.c = x[i];
                pat[i] = ptrn;
            }

            QsortPtrn(ref pat, 0, x.Length - 1, freq);
        }

        private static void QsortPtrn(ref Pattern[] pat, int low, int n, int[] freq)
        {
            int lo = low;
            int hi = n;
            if (lo >= n)
            {
                return;
            }
            Pattern mid = pat[(lo + hi) / 2];
            while (lo < hi)
            {
                while (lo < hi && OptimalPcmp(pat[lo], mid, freq) < 0)
                {
                    lo++;
                }
                while (lo < hi && OptimalPcmp(pat[hi], mid, freq) > 0)
                {
                    hi--;
                }
                if (lo < hi)
                {
                    Pattern T = pat[lo];
                    pat[lo] = pat[hi];
                    pat[hi] = T;
                }
            }
            if (hi < lo)
            {
                int T = hi;
                hi = lo;
                lo = T;
            }
            QsortPtrn(ref pat, low, lo, freq);
            QsortPtrn(ref pat, lo == low ? lo + 1 : lo, n, freq);
        }

        /* Optimal Mismatch pattern comparison function. */
        private static int OptimalPcmp(Pattern pat1, Pattern pat2, int[] freq)
        {
            int fx;

            fx = freq[pat1.c] - freq[pat2.c];
            return (fx != 0 ? (fx > 0 ? 1 : -1) : (pat2.loc - pat1.loc));
        }

        /*
         * Find the next leftward matching shift for the first ploc pattern elements
         * after a current shift or lshift.
         */
        private static int MatchShift(char[] x, int ploc, int lshift, Pattern[] pat)
        {
            int i, j;

            for (; lshift < x.Length; ++lshift)
            {
                i = ploc;
                while (--i >= 0)
                {
                    if ((j = (pat[i].loc - lshift)) < 0)
                        continue;
                    if (pat[i].c != x[j])
                        break;
                }
                if (i < 0)
                    break;
            }
            return (lshift);
        }

        /*
         * Constructs the good-suffix shift table from an ordered string.
         */
        private static void PreAdaptedGs(char[] x, ref int[] adaptedGs, Pattern[] pat)
        {
            int lshift, i, ploc;

            adaptedGs[0] = lshift = 1;
            for (ploc = 1; ploc <= x.Length; ++ploc)
            {
                lshift = MatchShift(x, ploc, lshift, pat);
                adaptedGs[ploc] = lshift;
            }
            for (ploc = 0; ploc < x.Length; ++ploc)
            {
                lshift = adaptedGs[ploc];
                while (lshift < x.Length)
                {
                    i = pat[ploc].loc - lshift;
                    if (i < 0 || pat[ploc].c != x[i])
                        break;
                    ++lshift;
                    lshift = MatchShift(x, ploc, lshift, pat);
                }
                adaptedGs[ploc] = lshift;
            }
        }

        private static int[] CalculateCharFreq(char[] x, char[] y, int z)
        {
            int i;
            int[] freq = new int[z];
            for (i = 0; i < x.Length; i++)
                freq[x[i]]++;
            for (i = 0; i < y.Length; i++)
                freq[y[i]]++;
            return freq;
        }

        private static void PreQsBc(char[] x, ref int[] qsBc)
        {
            int i, m = x.Length;

            for (i = 0; i < qsBc.Length; ++i)
                qsBc[i] = m + 1;
            for (i = 0; i < m; ++i)
                qsBc[x[i]] = m - i;
        }        
    }
}
