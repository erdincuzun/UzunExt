using System.Collections.Generic;
using ESMAJ.StringSearch;


namespace ESMAJ
{
    //ref:http://www-igm.univ-mlv.fr/~lecroq/string/ //Description of Algorithms 
    //https://github.com/almondtools/ESMAJ/blob/master/src/main/java/com/javacodegeeks/stringsearch/ //Java Codes
    public class SearchAlgoritms
    {
        public static double preProcessTime;
        public static double searchTime;
        public enum SearchAlgorithm { ApostolicoCrochemore, ApostolicoGiancarlo, BackwardNondeterministicDawgMatching,
            BackwardOracleMatching, BerryRavindran, BoyerMoore, BruteForce,
            Colussi, DeterministicFiniteAutomaton, ForwardDawgMatching, GalilGiancarlo, Horspool,
            KarpRabin, KMPSkipSearch, KnuthMorrisPratt, MaximalShift, MorrisPratt,
            NotSoNaive, OptimalMismatch, QuickSearch, Raita, ReverseColussi, ReverseFactor, ShiftOr, Simon,
            SkipSearch, Smith, StringMatchingonOrderedAlphabets, TunedBoyerMoore,
            TurboBM, TurboReverseFactor, TwoWay, ZhuTakaoka, NET_IndexOf, NET_IndexOf_Ordinal
        };

        public static int Search(string pattern, string source, int startIndex, SearchAlgorithm sa)
        {
            if (startIndex > source.Length)
                startIndex = 0;
            int id = (int)sa;
            int res = 0;
            if (id == 0)
            {
                res = ApostolicoCrochemore.Search(pattern, source, startIndex);
                preProcessTime = ApostolicoCrochemore.preProcessTime;
                searchTime = ApostolicoCrochemore.searchTime;
                return res;
            }
            else if (id == 1)
            {
                res = ApostolicoGiancarlo.Search(pattern, source, startIndex);
                preProcessTime = ApostolicoGiancarlo.preProcessTime;
                searchTime = ApostolicoGiancarlo.searchTime;
                return res;
            }
            else if (id == 2)
            {
                res = BackwardNondeterministicDawgMatching.Search(pattern, source, startIndex);
                preProcessTime = BackwardNondeterministicDawgMatching.preProcessTime;
                searchTime = BackwardNondeterministicDawgMatching.searchTime;
                return res;
            }
            else if (id == 3)
            {
                res = BackwardOracleMatching.Search(pattern, source, startIndex);
                preProcessTime = BackwardOracleMatching.preProcessTime;
                searchTime = BackwardOracleMatching.searchTime;
                return res;    
            }
            else if (id == 4)
            {
                res = BerryRavindran.Search(pattern, source, startIndex);
                preProcessTime = BerryRavindran.preProcessTime;
                searchTime = BerryRavindran.searchTime;
                return res;
            }
            else if (id == 5)
            {
                res = BoyerMoore.Search(pattern, source, startIndex);
                preProcessTime = BoyerMoore.preProcessTime;
                searchTime = BoyerMoore.searchTime;
                return res;
            }
            else if (id == 6)
            {
                res = BruteForce.Search(pattern, source, startIndex);
                preProcessTime = BruteForce.preProcessTime;
                searchTime = BruteForce.searchTime;
                return res;
            }
            else if (id == 7)
            {
                res = Colussi.Search(pattern, source, startIndex);
                preProcessTime = Colussi.preProcessTime;
                searchTime = Colussi.searchTime;
                return res;
            }
            else if (id == 8)
            {
                res = DeterministicFiniteAutomaton.Search(pattern, source, startIndex);
                preProcessTime = DeterministicFiniteAutomaton.preProcessTime;
                searchTime = DeterministicFiniteAutomaton.searchTime;
                return res;
            }
            else if (id == 9)
            {
                res = ForwardDawgMatching.Search(pattern, source, startIndex);
                preProcessTime = ForwardDawgMatching.preProcessTime;
                searchTime = ForwardDawgMatching.searchTime;
                return res;
            }
            else if (id == 10)
            {
                res = GalilGiancarlo.Search(pattern, source, startIndex);
                preProcessTime = GalilGiancarlo.preProcessTime;
                searchTime = GalilGiancarlo.searchTime;
                return res;
            }            
            else if (id == 11)
            {
                res = Horspool.Search(pattern, source, startIndex);
                preProcessTime = Horspool.preProcessTime;
                searchTime = Horspool.searchTime;
                return res;
            }
            else if (id == 12)
            {
                res = KarpRabin.Search(pattern, source, startIndex);
                preProcessTime = KarpRabin.preProcessTime;
                searchTime = KarpRabin.searchTime;
                return res;
            }
            else if (id == 13)
            {
                res = KMPSkipSearch.Search(pattern, source, startIndex);
                preProcessTime = KMPSkipSearch.preProcessTime;
                searchTime = KMPSkipSearch.searchTime;
                return res;
            }
            else if (id == 14)
            {
                res = KnuthMorrisPratt.Search(pattern, source, startIndex);
                preProcessTime = KnuthMorrisPratt.preProcessTime;
                searchTime = KnuthMorrisPratt.searchTime;
                return res;
            }
            else if (id == 15)
            {
                res = MaximalShift.Search(pattern, source, startIndex);
                preProcessTime = MaximalShift.preProcessTime;
                searchTime = MaximalShift.searchTime;
                return res;
            }
            else if (id == 16)
            {
                res = MorrisPratt.Search(pattern, source, startIndex);
                preProcessTime = MorrisPratt.preProcessTime;
                searchTime = MorrisPratt.searchTime;
                return res;
            }
            else if (id == 17)
            {
                res = NotSoNaive.Search(pattern, source, startIndex);
                preProcessTime = NotSoNaive.preProcessTime;
                searchTime = NotSoNaive.searchTime;
                return res;
            }
            else if (id == 18)
            {
                res = OptimalMismatch.Search(pattern, source, startIndex);
                preProcessTime = OptimalMismatch.preProcessTime;
                searchTime = OptimalMismatch.searchTime;
                return res;
            }
            else if (id == 19)
            {
                res = QuickSearch.Search(pattern, source, startIndex);
                preProcessTime = QuickSearch.preProcessTime;
                searchTime = QuickSearch.searchTime;
                return res;
            }
            else if (id == 20)
            {
                res = Raita.Search(pattern, source, startIndex);
                preProcessTime = Raita.preProcessTime;
                searchTime = Raita.searchTime;
                return res;
            }
            else if (id == 21)
            {
                res = ReverseColussi.Search(pattern, source, startIndex);
                preProcessTime = ReverseColussi.preProcessTime;
                searchTime = ReverseColussi.searchTime;
                return res;
            }
            else if (id == 22)
            {
                res = ReverseFactor.Search(pattern, source, startIndex);
                preProcessTime = ReverseFactor.preProcessTime;
                searchTime = ReverseFactor.searchTime;
                return res;
            }
            else if (id == 23)
            {
                res = ShiftOr.Search(pattern, source, startIndex);
                preProcessTime = ShiftOr.preProcessTime;
                searchTime = ShiftOr.searchTime;
                return res;
            }
            else if (id == 24)
            {
                res = Simon.Search(pattern, source, startIndex);
                preProcessTime = Simon.preProcessTime;
                searchTime = Simon.searchTime;
                return res;            
            }
            else if (id == 25)
            {
                res = SkipSearch.Search(pattern, source, startIndex);
                preProcessTime = SkipSearch.preProcessTime;
                searchTime = SkipSearch.searchTime;
                return res;
            }
            else if (id == 26)
            {
                res = Smith.Search(pattern, source, startIndex);
                preProcessTime = Smith.preProcessTime;
                searchTime = Smith.searchTime;
                return res;
            }
            else if (id == 27)
            {
                res = StringMatchingonOrderedAlphabets.Search(pattern, source, startIndex);
                preProcessTime = StringMatchingonOrderedAlphabets.preProcessTime;
                searchTime = StringMatchingonOrderedAlphabets.searchTime;
                return res;
            }
            else if (id == 28)
            {
                res = TunedBoyerMoore.Search(pattern, source, startIndex);
                preProcessTime = TunedBoyerMoore.preProcessTime;
                searchTime = TunedBoyerMoore.searchTime;
                return res;
            }
            else if (id == 29)
            {
                res = TurboBM.Search(pattern, source, startIndex);
                preProcessTime = TurboBM.preProcessTime;
                searchTime = TurboBM.searchTime;
                return res;
            }
            else if (id == 30)
            {
                res = TurboReverseFactor.Search(pattern, source, startIndex);
                preProcessTime = TurboReverseFactor.preProcessTime;
                searchTime = TurboReverseFactor.searchTime;
                return res;
            }
            else if (id == 31)
            {
                res = TwoWay.Search(pattern, source, startIndex);
                preProcessTime = TwoWay.preProcessTime;
                searchTime = TwoWay.searchTime;
                return res;
            }
            else if (id == 32)
            {
                res = ZhuTakaoka.Search(pattern, source, startIndex);
                preProcessTime = ZhuTakaoka.preProcessTime;
                searchTime = ZhuTakaoka.searchTime;
                return res;
            }
            else if (id == 33)
            {
                res = NET_IndexOf.Search(pattern, source, startIndex);
                preProcessTime = NET_IndexOf.preProcessTime;
                searchTime = NET_IndexOf.searchTime;
                return res;
            }
            else if (id == 34)
            {
                res = NET_IndexOf_Ordinal.Search(pattern, source, startIndex);
                preProcessTime = NET_IndexOf_Ordinal.preProcessTime;
                searchTime = NET_IndexOf_Ordinal.searchTime;
                return res;
            }
            else
                return -1;
        }

        public static List<int> Search(string pattern, string source, SearchAlgorithm sa)
        {
            int id = (int)sa;
            List<int> res = new List<int>();
            if (id == 0)
            {
                res = ApostolicoCrochemore.Search(pattern, source);
                preProcessTime = ApostolicoCrochemore.preProcessTime;
                searchTime = ApostolicoCrochemore.searchTime;
                return res;
            }
            else if (id == 1)
            {
                res = ApostolicoGiancarlo.Search(pattern, source);
                preProcessTime = ApostolicoGiancarlo.preProcessTime;
                searchTime = ApostolicoGiancarlo.searchTime;
                return res;
            }
            else if (id == 2)
            {
                res = BackwardNondeterministicDawgMatching.Search(pattern, source);
                preProcessTime = BackwardNondeterministicDawgMatching.preProcessTime;
                searchTime = BackwardNondeterministicDawgMatching.searchTime;
                return res;
            }
            else if (id == 3)
            {
                res = BackwardOracleMatching.Search(pattern, source);
                preProcessTime = BackwardOracleMatching.preProcessTime;
                searchTime = BackwardOracleMatching.searchTime;
                return res;
            }
            else if (id == 4)
            {
                res = BerryRavindran.Search(pattern, source);
                preProcessTime = BerryRavindran.preProcessTime;
                searchTime = BerryRavindran.searchTime;
                return res;
            }
            else if (id == 5)
            {
                res = BoyerMoore.Search(pattern, source);
                preProcessTime = BoyerMoore.preProcessTime;
                searchTime = BoyerMoore.searchTime;
                return res;
            }
            else if (id == 6)
            {
                res = BruteForce.Search(pattern, source);
                preProcessTime = BruteForce.preProcessTime;
                searchTime = BruteForce.searchTime;
                return res;
            }
            else if (id == 7)
            {
                res = Colussi.Search(pattern, source);
                preProcessTime = Colussi.preProcessTime;
                searchTime = Colussi.searchTime;
                return res;
            }
            else if (id == 8)
            {
                res = DeterministicFiniteAutomaton.Search(pattern, source);
                preProcessTime = DeterministicFiniteAutomaton.preProcessTime;
                searchTime = DeterministicFiniteAutomaton.searchTime;
                return res;
            }
            else if (id == 9)
            {
                res = ForwardDawgMatching.Search(pattern, source);
                preProcessTime = ForwardDawgMatching.preProcessTime;
                searchTime = ForwardDawgMatching.searchTime;
                return res;
            }
            else if (id == 10)
            {
                res = GalilGiancarlo.Search(pattern, source);
                preProcessTime = GalilGiancarlo.preProcessTime;
                searchTime = GalilGiancarlo.searchTime;
                return res;
            }
            else if (id == 11)
            {
                res = Horspool.Search(pattern, source);
                preProcessTime = Horspool.preProcessTime;
                searchTime = Horspool.searchTime;
                return res;
            }
            else if (id == 12)
            {
                res = KarpRabin.Search(pattern, source);
                preProcessTime = KarpRabin.preProcessTime;
                searchTime = KarpRabin.searchTime;
                return res;
            }
            else if (id == 13)
            {
                res = KMPSkipSearch.Search(pattern, source);
                preProcessTime = KMPSkipSearch.preProcessTime;
                searchTime = KMPSkipSearch.searchTime;
                return res;
            }
            else if (id == 14)
            {
                res = KnuthMorrisPratt.Search(pattern, source);
                preProcessTime = KnuthMorrisPratt.preProcessTime;
                searchTime = KnuthMorrisPratt.searchTime;
                return res;
            }
            else if (id == 15)
            {
                res = MaximalShift.Search(pattern, source);
                preProcessTime = MaximalShift.preProcessTime;
                searchTime = MaximalShift.searchTime;
                return res;
            }
            else if (id == 16)
            {
                res = MorrisPratt.Search(pattern, source);
                preProcessTime = MorrisPratt.preProcessTime;
                searchTime = MorrisPratt.searchTime;
                return res;
            }
            else if (id == 17)
            {
                res = NotSoNaive.Search(pattern, source);
                preProcessTime = NotSoNaive.preProcessTime;
                searchTime = NotSoNaive.searchTime;
                return res;
            }
            else if (id == 18)
            {
                res = OptimalMismatch.Search(pattern, source);
                preProcessTime = OptimalMismatch.preProcessTime;
                searchTime = OptimalMismatch.searchTime;
                return res;
            }
            else if (id == 19)
            {
                res = QuickSearch.Search(pattern, source);
                preProcessTime = QuickSearch.preProcessTime;
                searchTime = QuickSearch.searchTime;
                return res;
            }
            else if (id == 20)
            {
                res = Raita.Search(pattern, source);
                preProcessTime = Raita.preProcessTime;
                searchTime = Raita.searchTime;
                return res;
            }
            else if (id == 21)
            {
                res = ReverseColussi.Search(pattern, source);
                preProcessTime = ReverseColussi.preProcessTime;
                searchTime = ReverseColussi.searchTime;
                return res;
            }
            else if (id == 22)
            {
                res = ReverseFactor.Search(pattern, source);
                preProcessTime = ReverseFactor.preProcessTime;
                searchTime = ReverseFactor.searchTime;
                return res;
            }
            else if (id == 23)
            {
                res = ShiftOr.Search(pattern, source);
                preProcessTime = ShiftOr.preProcessTime;
                searchTime = ShiftOr.searchTime;
                return res;
            }
            else if (id == 24)
            {
                res = Simon.Search(pattern, source);
                preProcessTime = Simon.preProcessTime;
                searchTime = Simon.searchTime;
                return res;
            }
            else if (id == 25)
            {
                res = SkipSearch.Search(pattern, source);
                preProcessTime = SkipSearch.preProcessTime;
                searchTime = SkipSearch.searchTime;
                return res;
            }
            else if (id == 26)
            {
                res = Smith.Search(pattern, source);
                preProcessTime = Smith.preProcessTime;
                searchTime = Smith.searchTime;
                return res;
            }
            else if (id == 27)
            {
                res = StringMatchingonOrderedAlphabets.Search(pattern, source);
                preProcessTime = StringMatchingonOrderedAlphabets.preProcessTime;
                searchTime = StringMatchingonOrderedAlphabets.searchTime;
                return res;
            }
            else if (id == 28)
            {
                res = TunedBoyerMoore.Search(pattern, source);
                preProcessTime = TunedBoyerMoore.preProcessTime;
                searchTime = TunedBoyerMoore.searchTime;
                return res;
            }
            else if (id == 29)
            {
                res = TurboBM.Search(pattern, source);
                preProcessTime = TurboBM.preProcessTime;
                searchTime = TurboBM.searchTime;
                return res;
            }
            else if (id == 30)
            {
                res = TurboReverseFactor.Search(pattern, source);
                preProcessTime = TurboReverseFactor.preProcessTime;
                searchTime = TurboReverseFactor.searchTime;
                return res;
            }
            else if (id == 31)
            {
                res = TwoWay.Search(pattern, source);
                preProcessTime = TwoWay.preProcessTime;
                searchTime = TwoWay.searchTime;
                return res;
            }
            else if (id == 32)
            {
                res = ZhuTakaoka.Search(pattern, source);
                preProcessTime = ZhuTakaoka.preProcessTime;
                searchTime = ZhuTakaoka.searchTime;
                return res;
            }
            else if (id == 33)
            {
                res = NET_IndexOf.Search(pattern, source);
                preProcessTime = NET_IndexOf.preProcessTime;
                searchTime = NET_IndexOf.searchTime;
                return res;
            }
            else if (id == 34)
            {
                res = NET_IndexOf_Ordinal.Search(pattern, source);
                preProcessTime = NET_IndexOf_Ordinal.preProcessTime;
                searchTime = NET_IndexOf_Ordinal.searchTime;
                return res;
            }
            else
                return null;
        }

        public static int Count(string pattern, string source, SearchAlgorithm sa)
        {
            int id = (int)sa;
            List<int> res = new List<int>();
            if (id == 0)
            {
                res = ApostolicoCrochemore.Search(pattern, source);
                preProcessTime = ApostolicoCrochemore.preProcessTime;
                searchTime = ApostolicoCrochemore.searchTime;
                return res.Count;
            }
            else if (id == 1)
            {
                res = ApostolicoGiancarlo.Search(pattern, source);
                preProcessTime = ApostolicoGiancarlo.preProcessTime;
                searchTime = ApostolicoGiancarlo.searchTime;
                return res.Count;
            }
            else if (id == 2)
            {
                res = BackwardNondeterministicDawgMatching.Search(pattern, source);
                preProcessTime = BackwardNondeterministicDawgMatching.preProcessTime;
                searchTime = BackwardNondeterministicDawgMatching.searchTime;
                return res.Count;
            }
            else if (id == 3)
            {
                res = BackwardOracleMatching.Search(pattern, source);
                preProcessTime = BackwardOracleMatching.preProcessTime;
                searchTime = BackwardOracleMatching.searchTime;
                return res.Count;
            }
            else if (id == 4)
            {
                res = BerryRavindran.Search(pattern, source);
                preProcessTime = BerryRavindran.preProcessTime;
                searchTime = BerryRavindran.searchTime;
                return res.Count;
            }
            else if (id == 5)
            {
                res = BoyerMoore.Search(pattern, source);
                preProcessTime = BoyerMoore.preProcessTime;
                searchTime = BoyerMoore.searchTime;
                return res.Count;
            }
            else if (id == 6)
            {
                res = BruteForce.Search(pattern, source);
                preProcessTime = BruteForce.preProcessTime;
                searchTime = BruteForce.searchTime;
                return res.Count;
            }
            else if (id == 7)
            {
                res = Colussi.Search(pattern, source);
                preProcessTime = Colussi.preProcessTime;
                searchTime = Colussi.searchTime;
                return res.Count;
            }
            else if (id == 8)
            {
                res = DeterministicFiniteAutomaton.Search(pattern, source);
                preProcessTime = DeterministicFiniteAutomaton.preProcessTime;
                searchTime = DeterministicFiniteAutomaton.searchTime;
                return res.Count;
            }
            else if (id == 9)
            {
                res = ForwardDawgMatching.Search(pattern, source);
                preProcessTime = ForwardDawgMatching.preProcessTime;
                searchTime = ForwardDawgMatching.searchTime;
                return res.Count;
            }
            else if (id == 10)
            {
                res = GalilGiancarlo.Search(pattern, source);
                preProcessTime = GalilGiancarlo.preProcessTime;
                searchTime = GalilGiancarlo.searchTime;
                return res.Count;
            }
            else if (id == 11)
            {
                res = Horspool.Search(pattern, source);
                preProcessTime = Horspool.preProcessTime;
                searchTime = Horspool.searchTime;
                return res.Count;
            }
            else if (id == 12)
            {
                res = KarpRabin.Search(pattern, source);
                preProcessTime = KarpRabin.preProcessTime;
                searchTime = KarpRabin.searchTime;
                return res.Count;
            }
            else if (id == 13)
            {
                res = KMPSkipSearch.Search(pattern, source);
                preProcessTime = KMPSkipSearch.preProcessTime;
                searchTime = KMPSkipSearch.searchTime;
                return res.Count;
            }
            else if (id == 14)
            {
                res = KnuthMorrisPratt.Search(pattern, source);
                preProcessTime = KnuthMorrisPratt.preProcessTime;
                searchTime = KnuthMorrisPratt.searchTime;
                return res.Count;
            }
            else if (id == 15)
            {
                res = MaximalShift.Search(pattern, source);
                preProcessTime = MaximalShift.preProcessTime;
                searchTime = MaximalShift.searchTime;
                return res.Count;
            }
            else if (id == 16)
            {
                res = MorrisPratt.Search(pattern, source);
                preProcessTime = MorrisPratt.preProcessTime;
                searchTime = MorrisPratt.searchTime;
                return res.Count;
            }
            else if (id == 17)
            {
                res = NotSoNaive.Search(pattern, source);
                preProcessTime = NotSoNaive.preProcessTime;
                searchTime = NotSoNaive.searchTime;
                return res.Count;
            }
            else if (id == 18)
            {
                res = OptimalMismatch.Search(pattern, source);
                preProcessTime = OptimalMismatch.preProcessTime;
                searchTime = OptimalMismatch.searchTime;
                return res.Count;
            }
            else if (id == 19)
            {
                res = QuickSearch.Search(pattern, source);
                preProcessTime = QuickSearch.preProcessTime;
                searchTime = QuickSearch.searchTime;
                return res.Count;
            }
            else if (id == 20)
            {
                res = Raita.Search(pattern, source);
                preProcessTime = Raita.preProcessTime;
                searchTime = Raita.searchTime;
                return res.Count;
            }
            else if (id == 21)
            {
                res = ReverseColussi.Search(pattern, source);
                preProcessTime = ReverseColussi.preProcessTime;
                searchTime = ReverseColussi.searchTime;
                return res.Count;
            }
            else if (id == 22)
            {
                res = ReverseFactor.Search(pattern, source);
                preProcessTime = ReverseFactor.preProcessTime;
                searchTime = ReverseFactor.searchTime;
                return res.Count;
            }
            else if (id == 23)
            {
                res = ShiftOr.Search(pattern, source);
                preProcessTime = ShiftOr.preProcessTime;
                searchTime = ShiftOr.searchTime;
                return res.Count;
            }
            else if (id == 24)
            {
                res = Simon.Search(pattern, source);
                preProcessTime = Simon.preProcessTime;
                searchTime = Simon.searchTime;
                return res.Count;
            }
            else if (id == 25)
            {
                res = SkipSearch.Search(pattern, source);
                preProcessTime = SkipSearch.preProcessTime;
                searchTime = SkipSearch.searchTime;
                return res.Count;
            }
            else if (id == 26)
            {
                res = Smith.Search(pattern, source);
                preProcessTime = Smith.preProcessTime;
                searchTime = Smith.searchTime;
                return res.Count;
            }
            else if (id == 27)
            {
                res = StringMatchingonOrderedAlphabets.Search(pattern, source);
                preProcessTime = StringMatchingonOrderedAlphabets.preProcessTime;
                searchTime = StringMatchingonOrderedAlphabets.searchTime;
                return res.Count;
            }
            else if (id == 28)
            {
                res = TunedBoyerMoore.Search(pattern, source);
                preProcessTime = TunedBoyerMoore.preProcessTime;
                searchTime = TunedBoyerMoore.searchTime;
                return res.Count;
            }
            else if (id == 29)
            {
                res = TurboBM.Search(pattern, source);
                preProcessTime = TurboBM.preProcessTime;
                searchTime = TurboBM.searchTime;
                return res.Count;
            }
            else if (id == 30)
            {
                res = TurboReverseFactor.Search(pattern, source);
                preProcessTime = TurboReverseFactor.preProcessTime;
                searchTime = TurboReverseFactor.searchTime;
                return res.Count;
            }
            else if (id == 31)
            {
                res = TwoWay.Search(pattern, source);
                preProcessTime = TwoWay.preProcessTime;
                searchTime = TwoWay.searchTime;
                return res.Count;
            }
            else if (id == 32)
            {
                res = ZhuTakaoka.Search(pattern, source);
                preProcessTime = ZhuTakaoka.preProcessTime;
                searchTime = ZhuTakaoka.searchTime;
                return res.Count;
            }
            else if (id == 33)
            {
                res = NET_IndexOf.Search(pattern, source);
                preProcessTime = NET_IndexOf.preProcessTime;
                searchTime = NET_IndexOf.searchTime;
                return res.Count;
            }
            else if (id == 34)
            {
                res = NET_IndexOf_Ordinal.Search(pattern, source);
                preProcessTime = NET_IndexOf_Ordinal.preProcessTime;
                searchTime = NET_IndexOf_Ordinal.searchTime;
                return res.Count;
            }
            else
                return 0;
        }
    }
}
