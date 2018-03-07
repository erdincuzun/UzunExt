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

# Learning Stage
This library is used for determining parameters of startIndex, endtag_cnt and repeative. You can set situations of these parameters in contructor of class.
* startIndex; //-1:learn1, -2:learn2, >= 0, -3: close
* innerTagL; //-1:learn, >= 0, -2: close
* int repetitionL; //-1:learn, 1:fixed false; 2:fixed true, -2: close (false), -3: close (true)
```csharp
UzunExtAlgorithmLib.LearningLayer _LL = new UzunExtAlgorithmLib.LearningLayer(learn_StartingPos, learn_ITC, learn_Repetition);
```
If values of these parameters -1, -1, -1, respecetively; the algorithm decides on appropriate values in a crawling process. For understading the execution of this method, yo can examine the directory : UzunExtAlgorithm/UzunExtTester/DatasetGenerator/.

# Licence
Copyright (c) 2018 Erdinç Uzun

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
