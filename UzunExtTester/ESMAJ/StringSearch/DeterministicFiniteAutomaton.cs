using System.Collections.Generic;
using System.Diagnostics;

namespace ESMAJ.StringSearch
{    
    public class DeterministicFiniteAutomaton
    {
        public static double preProcessTime;
        public static double searchTime;
        public static int Search(string pattern, string source, int startIndex)
        {
            char[] x = pattern.ToCharArray(), y = source.ToCharArray(startIndex, source.Length - startIndex);
            int j, state, m = x.Length, n = y.Length;

            Graph aut;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            aut = Automata.NewAutomaton(m + 1, (m + 1) * 65536);
            PreAut(x, aut);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (state = Automata.GetInitial(aut), j = 0; j < n; ++j)
            {
                state = Automata.GetTarget(aut, state, y[j]);
                if (Automata.IsTerminal(aut, state))
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
            int j, state, m = x.Length, n = y.Length;
            List<int> result = new List<int>();

            Graph aut;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            /* Preprocessing */
            aut = Automata.NewAutomaton(m + 1, (m + 1) * 65536);
            PreAut(x, aut);
            stopwatch.Stop();
            preProcessTime = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Restart();
            /* Searching */
            for (state = Automata.GetInitial(aut), j = 0; j < n; ++j)
            {
                state = Automata.GetTarget(aut, state, y[j]);
                if (Automata.IsTerminal(aut, state))
                    result.Add(j - m + 1);
            }

            stopwatch.Stop();
            searchTime = stopwatch.Elapsed.TotalMilliseconds;
            return result;
        }
        private static void PreAut(char[] x, Graph aut)
        {
            int i, state, target, oldTarget, m = x.Length;

            for (state = Automata.GetInitial(aut), i = 0; i < m; ++i)
            {
                oldTarget = Automata.GetTarget(aut, state, x[i]);
                target = Automata.NewVertex(aut);
                Automata.SetTarget(aut, state, x[i], target);
                Automata.CopyVertex(aut, target, oldTarget);
                state = target;
            }
            Automata.SetTerminal(aut, state);
        }               
    }
}
