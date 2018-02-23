using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SearchForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Extract_Click(object sender, EventArgs e)
        {
            if (!Stopwatch.IsHighResolution)
                throw new NotSupportedException("Your hardware doesn't support high resolution counter");
            //prevent the JIT Compiler from optimizing Fkt calls away
            long seed = Environment.TickCount;
            //use the second Core/Processor for the test
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            //prevent "Normal" Processes from interrupting Threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            //prevent "Normal" Threads from interrupting this thread
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            //UzunAlgorithm _uzun = new UzunAlgorithm();
            string tagname = TXT_TagName.Text;
            string source = TXT_Source.Text;
            int startIndex = Convert.ToInt32(TXT_Pos.Text);
            int endTagCount = Convert.ToInt32(TXT_EndTag.Text);
            TXT_Result.Text = "";
            List<string> result = null;
            TXT_SourceResult.Text = "";
            WB2.DocumentText = "";

            if (CB_Process.SelectedIndex == 0)
            {
                List<int> result_int = null;
                for (int i = 0; i < 35; i++)
                {
                    //int find_pos = ESMAJ.SearchAlgoritms.Search(tagname, source, start_pos, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    result_int = ESMAJ.SearchAlgoritms.Search(tagname, source, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    
                    int cnt = -1;
                    if (result_int != null)
                        cnt = result_int.Count;
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (" + cnt + ") : " + (ESMAJ.SearchAlgoritms.preProcessTime + ESMAJ.SearchAlgoritms.searchTime)
                    + "= Preprocess:" + ESMAJ.SearchAlgoritms.preProcessTime + " + Searching:" + ESMAJ.SearchAlgoritms.searchTime + Environment.NewLine;
                }

                TXT_SourceResult.Text = "No Matches";
                WB2.DocumentText = "";
                if (result_int != null)
                {
                    TXT_SourceResult.Text = "Start Index of All Matches" + Environment.NewLine;
                    string html_res = "<h3>Start Index of All Matches</h3><hr>";

                    for (int i = 0; i < result_int.Count; i++)
                    {
                        TXT_SourceResult.Text += (i+1).ToString() + " : " + result_int[i] + Environment.NewLine;
                        html_res += "<b>" + (i + 1).ToString() + "</b> : " + result_int[i] + "<br />";
                    }
                    WB2.DocumentText = html_res;
                }
            }
            else if(CB_Process.SelectedIndex == 1)
            {
                int find_pos = -1;
                for (int i = 0; i < 35; i++)
                {
                    find_pos = ESMAJ.SearchAlgoritms.Search(tagname, source, startIndex, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (" + find_pos + ") : " + (ESMAJ.SearchAlgoritms.preProcessTime + ESMAJ.SearchAlgoritms.searchTime)
                    + "= Preprocess:" + ESMAJ.SearchAlgoritms.preProcessTime + " + Searching:" + ESMAJ.SearchAlgoritms.searchTime + Environment.NewLine;
                }

                TXT_SourceResult.Text = "No Matches";
                WB2.DocumentText = "<h3>No Matches</h3>";
                if (find_pos != -1)
                {
                    TXT_SourceResult.Text = "Index of First Match with Start Index" + Environment.NewLine;
                    TXT_SourceResult.Text += find_pos;
                    WB2.DocumentText = "<h3>Index of First Match with Start Index</h3><hr><b>" + find_pos + "<b>";
                }
            }
            else if (CB_Process.SelectedIndex == 2 || CB_Process.SelectedIndex == 6)
            {
                for (int i = 0; i < 35; i++)
                {
                    if(CB_Process.SelectedIndex == 2)
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, 0, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    else
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, 0, endTagCount, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    int cnt = -1;
                    if (result != null)
                        cnt = result.Count;
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (Cnt: " + cnt + "- EndTag:" + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag + ") : " + (UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime)
                    + "= Preprocess:" + UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + " + Searching:" + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime + Environment.NewLine;
                }              
            }
            else if (CB_Process.SelectedIndex == 3 || CB_Process.SelectedIndex == 7)
            {
                for (int i = 0; i < 35; i++)
                {
                    if (CB_Process.SelectedIndex == 3)
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, startIndex, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    else
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, startIndex, endTagCount, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    int cnt = -1;
                    if (result != null)
                        cnt = result.Count;
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (Cnt: " + cnt + "- EndTag:" + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag + ") : " + (UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime)
                    + "= Preprocess:" + UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + " + Searching:" + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime + Environment.NewLine;
                }                
            }
            else if (CB_Process.SelectedIndex == 4 || CB_Process.SelectedIndex == 8)
            {
                for (int i = 0; i < 35; i++)
                {
                    if(CB_Process.SelectedIndex == 4)
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, 0, -1, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    else
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, 0, endTagCount, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    int cnt = -1;
                    if (result != null)
                        cnt = result.Count;
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (Cnt: " + cnt + "- EndTag:" + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag + ") : " + (UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime)
                    + "= Preprocess:" + UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + " + Searching:" + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime + Environment.NewLine;
                }               
            }
            else if (CB_Process.SelectedIndex == 5 || CB_Process.SelectedIndex == 9)
            {
                for (int i = 0; i < 35; i++)
                {
                    if (CB_Process.SelectedIndex == 5)
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, startIndex, -1, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    else
                        result = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(tagname, source, startIndex, endTagCount, true, (ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
                    int cnt = -1;
                    if (result != null)
                        cnt = result.Count;
                    TXT_Result.Text += ((ESMAJ.SearchAlgoritms.SearchAlgorithm)i).ToString() + " : (Cnt: " + cnt + "- EndTag:" + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag + ") : " + (UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime)
                    + "= Preprocess:" + UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime + " + Searching:" + UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime + Environment.NewLine;
                }                
            }
            else if (CB_Process.SelectedIndex == 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    result = DOMBasedAlgorithms.DOMBased.Extract(tagname, source, (DOMBasedAlgorithms.DOMBased.DOMAlgorithm)i);
                    int cnt = -1;
                    if (result != null)
                        cnt = result.Count;
                    TXT_Result.Text += ((DOMBasedAlgorithms.DOMBased.DOMAlgorithm)i).ToString() + " : (Cnt: " + cnt +") : " + (DOMBasedAlgorithms.DOMBased.preProcessTime + DOMBasedAlgorithms.DOMBased.searchTime)
                    + "= Preprocess:" + DOMBasedAlgorithms.DOMBased.preProcessTime + " + Searching:" + DOMBasedAlgorithms.DOMBased.searchTime + Environment.NewLine;
                }
            }
            else if (CB_Process.SelectedIndex == 11)
            {
                string[] s = SET_Parser.SET_Parser.Contents_of_givenLayout_Tags_TESTER(source, tagname, false);
                if (s != null)
                    result = new List<string>(s);
                int cnt = -1;
                if (result != null)
                    cnt = result.Count;
                TXT_Result.Text += "Set Parser : (Cnt: " + cnt + ") : " + (SET_Parser.SET_Parser.preProcessTime + SET_Parser.SET_Parser.searchTime)
                + "= Preprocess:" + SET_Parser.SET_Parser.preProcessTime + " + Searching:" + SET_Parser.SET_Parser.searchTime + Environment.NewLine;
            }

            if (result != null)
            {
                TXT_SourceResult.Text = "Source of All Matches" + Environment.NewLine;
                string html_res = "<h3>All Matches</h3> <hr>";

                for (int i = 0; i < result.Count; i++)
                {
                    //TXT_SourceResult.Text += (i + 1).ToString() + " : " + Environment.NewLine + result[i] + Environment.NewLine;
                    TXT_SourceResult.Text += result[i] + Environment.NewLine;
                    //html_res += "<h3>" + (i + 1).ToString() + "</h3>" + result[i] + "<br />";
                    html_res += result[i]+ "<br />";
                }
                WB2.DocumentText = html_res;
            }
        }

        private void CB_Process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Process.SelectedIndex == 0 || CB_Process.SelectedIndex == 2 || CB_Process.SelectedIndex == 4)
            {
                TXT_Pos.Visible = false;
                LBL_Pos.Visible = false;
                TXT_EndTag.Visible = false;
                LBL_EndTag.Visible = false;
            }
            else if(CB_Process.SelectedIndex == 1 || CB_Process.SelectedIndex == 3 || CB_Process.SelectedIndex == 5)
            {
                TXT_Pos.Visible = true;
                LBL_Pos.Visible = true;
                TXT_EndTag.Visible = false;
                LBL_EndTag.Visible = false;
            }
            else if (CB_Process.SelectedIndex == 6 || CB_Process.SelectedIndex == 8)
            {
                TXT_Pos.Visible = false;
                LBL_Pos.Visible = false;
                TXT_EndTag.Visible = true;
                LBL_EndTag.Visible = true;
            }
            else if (CB_Process.SelectedIndex == 7 || CB_Process.SelectedIndex == 9)
            {
                TXT_Pos.Visible = true;
                LBL_Pos.Visible = true;
                TXT_EndTag.Visible = true;
                LBL_EndTag.Visible = true;
            }
            else if (CB_Process.SelectedIndex == 10 || CB_Process.SelectedIndex == 11)
            {
                TXT_Pos.Visible = false;
                LBL_Pos.Visible = false;
                TXT_EndTag.Visible = false;
                LBL_EndTag.Visible = false;
            }
        }

        private void BTN_LoadURL_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                TXT_Source.Text = webClient.DownloadString(TXT_Url.Text);                
            }
            WB1.DocumentText = TXT_Source.Text;
        }
    }
}
