using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class GalilSeiferas
    {
        public static double preProcessTime;
        public static double searchTime;
        public static List<int> Search(string pattern, string source)
        {
            char[] ptrn = pattern.ToCharArray(), y = source.ToCharArray();
            char[] x = new char[ptrn.Length + 1];
            Array.Copy(ptrn, 0, x, 0, ptrn.Length);
            int k = 4, p1 = 1, p = 0, q = 0, s = 0, q1 = 0, p2 = 0, q2 = 0, m = ptrn.Length, n = y.Length;
            List<int> result = new List<int>();
            preProcessTime = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            NewP1(x, y, s, q1, p1, q2, p2, q, p, k, m, n, ref result);
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;

            return result;
        }
        private static int ArrayCmp(ref char[] a, int aIdx, ref char[] b, int bIdx,  int Length)
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

        private static void Search(char[] x, int p, int n, int m, int s, int q, char[] y, int p1, int q1, int k, ref List<int> result)
        {
            while (p <= n - m)
            {
                while (p + s + q < n && s + q < m && x[s + q] == y[p + s + q])
                    ++q;
                if (q == m - s && ArrayCmp(ref x, 0, ref y, p, (s + 1)) == 0)
                {
                    result.Add(p);
                }
                if (q == p1 + q1)
                {
                    p += p1;
                    q -= p1;
                }
                else
                {
                    p += (q / k + 1);
                    q = 0;
                }
            }
        }

        private static void Parse(char[] x, char[] y, int s, int q2, int p2,
                int q1, int p1, int q, int p, int k, int m, int n, ref List<int> result)
        {

            while (true)
            {
                while (x[s + q1] == x[s + p1 + q1])
                    ++q1;
                while (p1 + q1 >= k * p1)
                {
                    s += p1;
                    q1 -= p1;
                }
                p1 += (q1 / k + 1);
                q1 = 0;
                if (p1 >= p2)
                    break;
            }
            NewP1(x, y, s, q1, p1, q2, p2, q, p, k, m, n, ref result);
        }

        private static void NewP2(char[] x, char[] y, int s, int q2, int p2, int q1,
                int p1, int p, int q, int k, int m, int n, ref List<int> result)
        {
            while (x[s + q2] == x[s + p2 + q2] && p2 + q2 < k * p2)
                ++q2;
            if (p2 + q2 == k * p2)
                Parse(x, y, s, q2, p2, q1, p1, q, p, k, m, n, ref result);
            else if (s + p2 + q2 == m)
                Search(x, p, n, m, s, q, y, p1, q1, k, ref result);
            else
            {
                if (q2 == p1 + q1)
                {
                    p2 += p1;
                    q2 -= p1;
                }
                else
                {
                    p2 += (q2 / k + 1);
                    q2 = 0;
                }
                NewP2(x, y, s, q2, p2, q1, p1, p, q, k, m, n, ref result);
            }
        }

        private static void NewP1(char[] x, char[] y, int s, int q1, int p1, int q2,
            int p2, int q, int p, int k, int m, int n, ref List<int> result)
        {
            while (s + p1 + q1 < m && x[s + q1] == x[s + p1 + q1])
                ++q1;
            if (p1 + q1 >= k * p1)
            {
                p2 = q1;
                q2 = 0;
                NewP2(x, y, s, q2, p2, q1, p1, p, q, k, m, n, ref result);
            }
            else
            {
                if (s + p1 + q1 == m)
                    Search(x, p, n, m, s, q, y, p1, q1, k, ref result);
                else
                {
                    p1 += (q1 / k + 1);
                    q1 = 0;
                    NewP1(x, y, s, q1, p1, q2, p2, q, p, k, m, n, ref result);
                }
            }
        }        
    }
}
