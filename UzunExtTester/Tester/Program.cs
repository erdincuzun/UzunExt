using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Tester
{
    class Program
    {
        //parametre:0 dir:1 file:2 rule:3 searchAlg(0-33):4 Test(11): 

        //searchAlg: 34 different search algorithm
        
        //Search All
        //Search by Position(Find First and break)
        //Extract by Pos=0 (One content)
        //Extract by Position(One content)
        //Extract by Pos=0 (All contents)
        //Extract by Position(All contents)
        //Extract by Pos=0 & End Tag(One content)
        //Extract by Position & End Tag(One content)
        //Extract by Pos=0 & End Tag(All contents)
        //Extract by Position & End Tag(All contents)
        //Extract by DOM Algoritms

        static void Main(string[] args)
        {
            try
            {
                if (!Stopwatch.IsHighResolution)
                    throw new NotSupportedException("Your hardware doesn't support high resolution counter");
                long seed = Environment.TickCount;
                Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                Thread.CurrentThread.Priority = ThreadPriority.Highest;

                int test_Cnt = 5;
                foreach (string thearg in args)
                    Console.WriteLine(thearg);


                //start_path(1) file_path(2) filename(3) rule[0](4) searchAlg(0-33) Test(11)  startIndex(rule[1]) endTagCount(rule[2])
                string app_path = args[0] + "\\";
                string file_path = args[1];
                string filename = args[2];
                string source = File.ReadAllText(file_path + filename);
                string tagName = args[3].Replace(".", " ").Replace("*", "\"");
                int alg_No = Convert.ToInt32(args[4]);
                int selection = Convert.ToInt32(args[5]);
                int startIndex = Convert.ToInt32(args[6]);
                int endTagCount = Convert.ToInt32(args[7]);

                double preProcessTime_warmup, searchTime_warmup;
                int cnt_warmup;
                List<double> preProcessTime = new List<double>();
                List<double> searchTime = new List<double>();
                List<int> cnt = new List<int>();
                int ind = -2;
                string algotihm_name = "";

                for (int i = 0; i <= test_Cnt; i++) //first warmup, others normal test
                {
                    List<string> result = null;
                    List<int> result_int = null;
                    if (selection == 0)
                    {
                        result_int = ESMAJ.SearchAlgoritms.Search(tagName, source, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                        startIndex = 0;
                        endTagCount = -1;
                    }
                    else if (selection == 1)
                    {
                        if (startIndex >= 0)//eğer startIndex sıfırdan büyük değilse anlamı yok
                        {
                            ind = ESMAJ.SearchAlgoritms.Search(tagName, source, startIndex, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                            endTagCount = -1;
                        }
                    }
                    else if (selection == 2)
                    {
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, 0, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                        startIndex = 0;
                        endTagCount = -1;
                    }
                    else if (selection == 3)
                    {
                        if (startIndex >= 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, startIndex, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                            endTagCount = -1;
                        }
                    }
                    else if (selection == 4)
                    {
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, 0, -1, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                        startIndex = 0;
                        endTagCount = -1;
                    }
                    else if (selection == 5)
                    {
                        if (startIndex >= 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, startIndex, -1, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                            endTagCount = -1;
                        }
                    }
                    else if (selection == 6)
                    {
                        if (endTagCount > 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, 0, endTagCount, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                            startIndex = 0;
                        }
                    }
                    else if (selection == 7)
                    {
                        if (startIndex >= 0 && endTagCount > 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, startIndex, endTagCount, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                        }
                    }
                    else if (selection == 8)
                    {
                        if (endTagCount > 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, 0, endTagCount, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                            startIndex = 0;
                        }
                    }
                    else if (selection == 9)
                    {
                        if (startIndex >= 0 && endTagCount > 0)
                        {
                            result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagName, source, startIndex, endTagCount, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                        }
                    }                    
                    else if (selection == 10)
                    {
                        result_int = ESMAJ.SearchAlgoritms.Search("<div", source, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                    }
                    else if (selection == 11)
                    {
                        result_int = ESMAJ.SearchAlgoritms.Search("</div>", source, (ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No);
                    }
                    else if (selection == 12)
                    {
                        result = DOMBasedAlgorithms.DOMBased.Extract(tagName, source, (DOMBasedAlgorithms.DOMBased.DOMAlgorithm)alg_No);
                    }


                    //for results
                    if (selection == 0 || selection == 1 || selection == 10 || selection == 11)
                    {
                        if (i == 0)
                        {
                            preProcessTime_warmup = ESMAJ.SearchAlgoritms.preProcessTime;
                            searchTime_warmup = ESMAJ.SearchAlgoritms.searchTime;
                            if (result_int != null)
                                cnt_warmup = result_int.Count; //selection1
                            else
                                cnt.Add(ind - startIndex); //selection2                            
                        }
                        else
                        {
                            preProcessTime.Add(ESMAJ.SearchAlgoritms.preProcessTime);
                            searchTime.Add(ESMAJ.SearchAlgoritms.searchTime);
                            if (result_int != null)
                                cnt.Add(result_int.Count);
                            else
                                cnt.Add(ind - startIndex);
                        }

                        string temp = i + "," + ((ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No).ToString() + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                               tagName.Length + "," + source.Length + "," + ESMAJ.SearchAlgoritms.preProcessTime + "," + ESMAJ.SearchAlgoritms.searchTime + "," +
                               (ESMAJ.SearchAlgoritms.preProcessTime + ESMAJ.SearchAlgoritms.searchTime);
                        algotihm_name = ((ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No).ToString();
                        if (result_int != null)
                        {
                            WriteRes_Header(selection.ToString("D2") + "_All.txt", "TestNo,Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, Result");
                            temp += "," + result_int.Count;
                            WriteRes(selection.ToString("D2") + "_All.txt", temp);
                        }
                        else
                        {
                            if (ind != -2)
                            {
                                WriteRes_Header(selection.ToString("D2") + "_All.txt", "TestNo,Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, Index, StartIndex, Difference");
                                temp += "," + ind + "," + startIndex + "," + (ind - startIndex);
                                WriteRes(selection.ToString("D2") + "_All.txt", temp);
                            }
                        }
                    }
                    else if (selection == 12)
                    {
                        if (i == 0)
                        {
                            preProcessTime_warmup = DOMBasedAlgorithms.DOMBased.preProcessTime;
                            searchTime_warmup = DOMBasedAlgorithms.DOMBased.searchTime;
                            if (result != null)
                                cnt_warmup = result.Count;

                            WriteRes_Header(selection.ToString("D2") + "_All.txt", "TestNo,Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, Result");
                        }
                        else
                        {
                            preProcessTime.Add(DOMBasedAlgorithms.DOMBased.preProcessTime);
                            searchTime.Add(DOMBasedAlgorithms.DOMBased.searchTime);
                            if (result != null)
                                cnt.Add(result.Count);
                        }

                        string temp = i + "," + ((DOMBasedAlgorithms.DOMBased.DOMAlgorithm)alg_No).ToString() + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                              tagName.Length + "," + source.Length + "," + DOMBasedAlgorithms.DOMBased.preProcessTime + "," + DOMBasedAlgorithms.DOMBased.searchTime + "," +
                              (DOMBasedAlgorithms.DOMBased.preProcessTime + DOMBasedAlgorithms.DOMBased.searchTime) + "," + result.Count;
                        algotihm_name = ((DOMBasedAlgorithms.DOMBased.DOMAlgorithm)alg_No).ToString();
                        WriteRes(selection.ToString("D2") + "_All.txt", temp);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            preProcessTime_warmup = UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime;
                            searchTime_warmup = UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime;
                            if (result != null)
                                cnt_warmup = result.Count;

                            WriteRes_Header(selection.ToString("D2") + "_All.txt", "TestNo,Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, Result, startIndex, EndTagCount, EndTagCountafterExtraction");
                        }
                        else
                        {
                            preProcessTime.Add(UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime);
                            searchTime.Add(UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime);
                            if (result != null)
                                cnt.Add(result.Count);
                        }

                        if (result != null)
                        {
                            string temp = i + "," + ((ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No).ToString() + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                              tagName.Length + "," + source.Length + "," + UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + "," + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime + "," +
                              (UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime) + "," + result.Count + "," + startIndex + "," + endTagCount + "," + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag;
                            algotihm_name = ((ESMAJ.SearchAlgoritms.SearchAlgorithm)alg_No).ToString();
                            WriteRes(selection.ToString("D2") + "_All.txt", temp);
                        }
                    }
                }//for

                WriteRes_Header(selection.ToString("D2") + "_Min.txt", "Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total");
                WriteRes_Header(selection.ToString("D2") + "_Max.txt", "Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total");
                WriteRes_Header(selection.ToString("D2") + "_Avg.txt", "Algorithm,Directory,FileName,Tag Length, Source Length, preProcess Time, Search Time, Total");
                if (preProcessTime.Count > 0 && algotihm_name != "" && searchTime.Min() != 0)
                {
                    string temp2 = algotihm_name + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                               tagName.Length + "," + source.Length + "," + preProcessTime.Min() + "," + searchTime.Min() + "," +
                               (preProcessTime.Min() + searchTime.Min());
                    WriteRes(selection.ToString("D2") + "_Min.txt", temp2);
                    temp2 = algotihm_name + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                                   tagName.Length + "," + source.Length + "," + preProcessTime.Max() + "," + searchTime.Max() + "," +
                                   (preProcessTime.Max() + searchTime.Max());
                    WriteRes(selection.ToString("D2") + "_Max.txt", temp2);
                    temp2 = algotihm_name + "," + file_path.Substring(0, file_path.LastIndexOf("\\")).Replace(app_path, "") + "," + filename + "," +
                                   tagName.Length + "," + source.Length + "," + preProcessTime.Average() + "," + searchTime.Average() + "," +
                                   (preProcessTime.Average() + searchTime.Average());
                    WriteRes(selection.ToString("D2") + "_Avg.txt", temp2);
                }
            }
            catch
            {
                Environment.Exit(0);
            }                        
        }

        private static void WriteRes(string filename, string res_row)
        {
            if (!Directory.Exists("Results"))
                Directory.CreateDirectory("Results");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Results\\" + filename, true))
            {
                file.WriteLine(res_row);
            }
        }

        private static void WriteRes_Header(string filename, string res_row)
        {
            if (!Directory.Exists("Results"))
                Directory.CreateDirectory("Results");                

            if (!File.Exists("Results\\" + filename))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Results\\" + filename))
                {
                    file.WriteLine(res_row);
                }
            }
        }
    }
}
