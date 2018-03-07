# UzunExt Algorithm
UzunExt Algorithm is an efficient and effective web content extractor. The algorithm has two different libraries for extraction and learning process.

# Extraction Stage
A DOM Tree can be used for extraction from web pages. However, this tree takes all elements in a web page into consideration for this task. UzunExt extracts web content quickly by using string methods and additional information without utilizing DOM Tree. The following method is the extraction stage of this algorithm.

```csharp
List<string> Extract(string tagname, string source, int startIndex, int endtag_cnt, bool repeative, ESMAJ.SearchAlgoritms.SearchAlgorithm sa);

//usage
UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, 0, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)34);
```
Parameters:
* tagname is an element for using extraction process. For example: <div id="main"> 
* source is a Web page that contains tagname.
* startindex is approximate starting index for searching.
* endtag_Cnt is the number of element name of tagname. 
* repetitive is used to break the loop for stopping extraction process.
* Search algorithms determine pattern matching algorithm. Algorithms: ApostolicoCrochemore, ApostolicoGiancarlo, BackwardNondeterministicDawgMatching, BackwardOracleMatching, BerryRavindran, BoyerMoore, BruteForce, Colussi, DeterministicFiniteAutomaton, ForwardDawgMatching, GalilGiancarlo, Horspool,KarpRabin, KMPSkipSearch, KnuthMorrisPratt, MaximalShift, MorrisPratt, NotSoNaive, OptimalMismatch, QuickSearch, Raita, ReverseColussi, ReverseFactor, ShiftOr, Simon,SkipSearch, Smith, StringMatchingonOrderedAlphabets, TunedBoyerMoore, TurboBM, TurboReverseFactor, TwoWay, ZhuTakaoka, NET_IndexOf, NET_IndexOf_Ordinal
