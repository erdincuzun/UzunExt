using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{
    public class TurboReverseFactor
    {
        public static double preProcessTime;
        public static double searchTime;

        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int period, i, j, shift, u, periodOfU, disp, init, state, mu, m = x.Length, n = y.Length;
            int[] mpNext = new int[m + 1];

            char[] xR;
            Graph aut;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            aut = Automata.NewSuffixAutomaton(2 * (m + 2), 2 * (m + 2)
                    * 65536);
            xR = Reverse(x);
            BuildSuffixAutomaton(xR, ref aut);
            init = Automata.GetInitial(aut);
            PreMp(x, ref mpNext);
            period = m - mpNext[m];
            i = 0;
            shift = m;
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                state = init;
                u = m - 1 - shift;
                periodOfU = (shift != m ? m - shift - mpNext[m - shift] : 0);
                shift = m;
                disp = 0;
                while (i > u
                        && Automata.GetTarget(aut, state, y[i + j]) != -1)
                {
                    disp += Automata.GetShift(aut, state, y[i + j]);
                    state = Automata.GetTarget(aut, state, y[i + j]);
                    if (Automata.IsTerminal(aut, state))
                        shift = i;
                    --i;
                }
                if (i <= u)
                    if (disp == 0)
                    {
                        stopwatch.Stop();
                        searchTime = stopwatch.Elapsed.TotalMilliseconds;
                        return j + startIndex;
                    }
                    else
                    {
                        mu = (u + 1) / 2;
                        if (periodOfU <= mu)
                        {
                            u -= periodOfU;
                            while (i > u
                                    && Automata.GetTarget(aut, state, y[i + j]) != -1)
                            {
                                disp += Automata.GetShift(aut, state, y[i + j]);
                                state = Automata.GetTarget(aut, state, y[i + j]);
                                if (Automata.IsTerminal(aut, state))
                                    shift = i;
                                --i;
                            }
                            if (i <= u)
                                shift = disp;
                        }
                        else
                        {
                            u = u - mu - 1;
                            while (i > u
                                    && Automata.GetTarget(aut, state, y[i + j]) != -1)
                            {
                                disp += Automata.GetShift(aut, state, y[i + j]);
                                state = Automata.GetTarget(aut, state, y[i + j]);
                                if (Automata.IsTerminal(aut, state))
                                    shift = i;
                                --i;
                            }
                        }
                    }
                j += shift;
            }
            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return -1;
        }
        public static List<int> Search(string pattern, string source)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray();
            int period, i, j, shift, u, periodOfU, disp, init, state, mu, m = x.Length, n = y.Length;
            int[] mpNext = new int[m + 1];
            List<int> result = new List<int>();

            char[] xR;
            Graph aut;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            aut = Automata.NewSuffixAutomaton(2 * (m + 2), 2 * (m + 2)
                    * 65536);
            xR = Reverse(x);
            BuildSuffixAutomaton(xR, ref aut);
            init = Automata.GetInitial(aut);
            PreMp(x, ref mpNext);
            period = m - mpNext[m];
            i = 0;
            shift = m;
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            j = 0;
            while (j <= n - m)
            {
                i = m - 1;
                state = init;
                u = m - 1 - shift;
                periodOfU = (shift != m ? m - shift - mpNext[m - shift] : 0);
                shift = m;
                disp = 0;
                while (i > u
                        && Automata.GetTarget(aut, state, y[i + j]) != -1)
                {
                    disp += Automata.GetShift(aut, state, y[i + j]);
                    state = Automata.GetTarget(aut, state, y[i + j]);
                    if (Automata.IsTerminal(aut, state))
                        shift = i;
                    --i;
                }
                if (i <= u)
                    if (disp == 0)
                    {
                        result.Add(j);
                        shift = period;
                    }
                    else
                    {
                        mu = (u + 1) / 2;
                        if (periodOfU <= mu)
                        {
                            u -= periodOfU;
                            while (i > u
                                    && Automata.GetTarget(aut, state, y[i + j]) != -1)
                            {
                                disp += Automata.GetShift(aut, state, y[i + j]);
                                state = Automata.GetTarget(aut, state, y[i + j]);
                                if (Automata.IsTerminal(aut, state))
                                    shift = i;
                                --i;
                            }
                            if (i <= u)
                                shift = disp;
                        }
                        else
                        {
                            u = u - mu - 1;
                            while (i > u
                                    && Automata.GetTarget(aut, state, y[i + j]) != -1)
                            {
                                disp += Automata.GetShift(aut, state, y[i + j]);
                                state = Automata.GetTarget(aut, state, y[i + j]);
                                if (Automata.IsTerminal(aut, state))
                                    shift = i;
                                --i;
                            }
                        }
                    }
                j += shift;
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

        private static void BuildSuffixAutomaton(char[] x, ref Graph aut)
        {
            int i, art, init, last, p, q, r, m = (x.Length - 1);
            char c;

            init = Automata.GetInitial(aut);
            art = Automata.NewVertex(aut);
            Automata.SetSuffixLink(aut, init, art);
            last = init;
            for (i = 0; i < m; ++i)
            {
                c = x[i];
                p = last;
                q = Automata.NewVertex(aut);
                Automata.SetLength(aut, q, Automata.GetLength(aut, p) + 1);
                Automata.SetPosition(aut, q, Automata.GetPosition(aut, p) + 1);
                while (p != init
                        && Automata.GetTarget(aut, p, c) == -1)
                {
                    Automata.SetTarget(aut, p, c, q);
                    Automata.SetShift(aut, p, c, Automata.GetPosition(aut, q)
                            - Automata.GetPosition(aut, p) - 1);
                    p = Automata.GetSuffixLink(aut, p);
                }
                if (Automata.GetTarget(aut, p, c) == -1)
                {
                    Automata.SetTarget(aut, init, c, q);
                    Automata.SetShift(aut, init, c, Automata.GetPosition(aut, q)
                            - Automata.GetPosition(aut, init) - 1);
                    Automata.SetSuffixLink(aut, q, init);
                }
                else if (Automata.GetLength(aut, p) + 1 == Automata.GetLength(
                      aut, Automata.GetTarget(aut, p, c)))
                    Automata.SetSuffixLink(aut, q, Automata.GetTarget(aut, p, c));
                else
                {
                    r = Automata.NewVertex(aut);
                    Automata.CopyVertex(aut, r, Automata.GetTarget(aut, p, c));
                    Automata.SetLength(aut, r, Automata.GetLength(aut, p) + 1);
                    Automata.SetSuffixLink(aut, Automata.GetTarget(aut, p, c), r);
                    Automata.SetSuffixLink(aut, q, r);
                    while (p != art
                            && Automata.GetLength(aut, Automata
                                    .GetTarget(aut, p, c)) >= Automata.GetLength(
                                    aut, r))
                    {
                        Automata.SetShift(aut, p, c, Automata.GetPosition(aut,
                                Automata.GetTarget(aut, p, c))
                                - Automata.GetPosition(aut, p) - 1);
                        Automata.SetTarget(aut, p, c, r);
                        p = Automata.GetSuffixLink(aut, p);
                    }
                }
                last = q;
            }
            Automata.SetTerminal(aut, last);
            while (last != init)
            {
                last = Automata.GetSuffixLink(aut, last);
                Automata.SetTerminal(aut, last);
            }
        }

        private static char[] Reverse(char[] x)
        {
            char[] xR;
            int i, m = x.Length;

            xR = new char[m + 1];
            for (i = 0; i < m; ++i)
                xR[i] = x[m - 1 - i];
            xR[m] = '\0';
            return (xR);
        }
    }
}
