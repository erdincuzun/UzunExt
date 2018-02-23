using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace DatasetGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void preparingforTest()
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
        }

        private void BTN_Download_Click(object sender, EventArgs e)
        {
            TXT_Source.Text = download(TXT_Url.Text);
            WB1.DocumentText = TXT_Source.Text;
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            saveFile(TXT_Source.Text, TXT_Url.Text);
        }

        private void saveFile(string source, string url)
        {
            LBL_Hata.Text = "";
            if (!Directory.Exists("Dataset"))
                Directory.CreateDirectory("Dataset");

            if (TXT_DirectoryName.Text.Trim() != "")
            {
                string path = "Dataset\\" + TXT_DirectoryName.Text.Trim();

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                int fCount = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
                fCount++;
                File.WriteAllText(path + "\\" + fCount.ToString("D4") + ".html", source);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Dataset\\dataset.txt", true))
                {
                    file.WriteLine( url + "," + path + "\\" + fCount.ToString("D4") + ".html ," + DateTime.Now);
                }
            }
            else
                LBL_Hata.Text = "Please enter directory name";
        }

        private void BTN_LoadRules_Click(object sender, EventArgs e)
        {
            LBL_Hata.Text = "";
            if (!Directory.Exists("Rules"))
                Directory.CreateDirectory("Rules");
            if (TXT_DirectoryName.Text.Trim() != "")
            {
                string path = "Rules\\" + TXT_DirectoryName.Text.Trim() + ".txt";

                if (!File.Exists(path))
                    File.WriteAllText(path, TXT_Rules.Text); //user wrongly clicks to load, if there is not file, we save this text

                TXT_Rules.Text = File.ReadAllText(path);

                //
                string[] rules = File.ReadAllLines(path);
                CB_SearchText.Items.Clear();
                foreach (string item in rules)
                    CB_SearchText.Items.Add(item.Split(',')[0]);
                if (rules.Length > 0)
                    CB_SearchText.Text = rules[0].Split(',')[0];
                
            }
            else
                LBL_Hata.Text = "Please enter directory name";
        }

        private void BTN_SaveRules_Click(object sender, EventArgs e)
        {
            string path = "Rules\\" + TXT_DirectoryName.Text.Trim() + ".txt";
            saveRules(path);
        }

        private void saveRules(string path)
        {
            LBL_Hata.Text = "";
            if (!Directory.Exists("Rules"))
                Directory.CreateDirectory("Rules");
            if (TXT_DirectoryName.Text.Trim() != "")
            {              
                if (!File.Exists(path))
                    File.WriteAllText(path, TXT_Rules.Text); //user wrongly clicks to load, if there is not file, we save this text

                File.WriteAllText(path, TXT_Rules.Text);
            }
            else
                LBL_Hata.Text = "Please enter directory name";

        }

        private void BTN_Search_Click(object sender, EventArgs e)
        {
            TXT_Res.Text = "";
            List<int> res = ESMAJ.SearchAlgoritms.Search(CB_SearchText.Text, TXT_Source.Text, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
            if (res.Count == 0)
                TXT_Res.Text = "-1: No matches";
            else
                foreach (var item in res)
                    TXT_Res.Text += item + Environment.NewLine;

            List<string> res2 = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(CB_SearchText.Text, TXT_Source.Text, 0, -1, false, (ESMAJ.SearchAlgoritms.SearchAlgorithm)34);
            TXT_Res.Text += "EndTagCount: " + UzunExtAlgorithmLib.UzunExtAlgorithm.endTag + Environment.NewLine;
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            preparingforTest();

            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt"); 
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");
                foreach (string rule in rules)//for all rules
                {
                    string[] theRule = rule.Split(',');
                    if (theRule.Length > 2)
                    {
                        foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                        {
                            for (int i = 0; i < 35; i++)//for 34 search algorithms
                            {
                                for (int test = 0; test < 12; test++)
                                {
                                    ProcessStartInfo startInfo = new ProcessStartInfo("Tester.exe");
                                    startInfo.Arguments = Application.StartupPath + " " + d_inner.FullName + " " + file2.Name + " " + theRule[0].Replace(" ", ".").Replace("\"", "*") + " "
                                         + i + " " + test + " " + theRule[1] + " " + theRule[2];
                                    var pro = Process.Start(startInfo);
                                    pro.WaitForExit();
                                }
                                //start_path(1) file_path(2) filename(3) rule[0](4) searchAlg(0-33) Test(11)  startIndex(rule[1]) endTagCount(rule[2])
                                //C: \Users\Erdinc\Desktop\Temp\UzunAlgorithm\SearchForm\Tester\bin\Debug
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                //dombasedtest
                                ProcessStartInfo startInfo = new ProcessStartInfo("Tester.exe");
                                startInfo.Arguments = Application.StartupPath + " " + d_inner.FullName + " " + file2.Name + " " + theRule[0].Replace(" ", ".").Replace("\"", "*") + " "
                                     + i + " 12 " + theRule[1] + " " + theRule[2];
                                var pro = Process.Start(startInfo);
                                pro.WaitForExit();
                            }
                        }
                    }                    
                }                                  
            }
        }

        private Dictionary<string, string> DomainList()
        {
            Dictionary<string, string> _list = new Dictionary<string, string>();
            string[] arr = File.ReadAllLines("Dataset\\category.txt");
            foreach (string item in arr)
            {
                string[] sub_item = item.Split(',');
                _list.Add(sub_item[0], sub_item[1]);
            }
            return _list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 35; i++)//for 34 search algorithms
                CB_Alg.Items.Add((ESMAJ.SearchAlgoritms.SearchAlgorithm)i);
            for (int i = 0; i < 3; i++)
                CB_Alg.Items.Add((DOMBasedAlgorithms.DOMBased.DOMAlgorithm)i);

            CB_Alg.Items.Add("Set Parser");

            CB_Alg.SelectedIndex = 34;
            CB_PosLearn.SelectedIndex = 1;
            CB_ITC.SelectedIndex = 0;
            CB_Repetition.SelectedIndex = 0;
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

         private string download(string url)
        {
            string main_html = "";
            using (WebClient webClient = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                ServicePointManager.ServerCertificateValidationCallback =   new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

                webClient.Encoding = Encoding.UTF8;
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers["Accept"] = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                //webClient.Headers["User-Agent"] = "Mozilla/5.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; MDDC)";
                webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                try
                {
                    main_html = webClient.DownloadString(url);
                }
                catch(WebException ex)
                {
                    main_html = "";
                }

            }

            return main_html;
        }

        private void BTN_Crawl_Click(object sender, EventArgs e)
        {
            string main_html = download(TXT_Url.Text);

            List<string> url_list = all_links(main_html, TXT_Url.Text.Trim(), TXT_ContainStr.Text.Trim());

                string path = "Rules\\" + TXT_DirectoryName.Text.Trim() + ".txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("No rules!");
                    return;
                }

                string[] rules = File.ReadAllLines(path);

            string pathc = "Dataset\\" + TXT_DirectoryName.Text.Trim();

            if (!Directory.Exists(pathc))
                Directory.CreateDirectory(pathc);
            int page_count = Directory.GetFiles(pathc, "*", SearchOption.AllDirectories).Length;

            WriteRes_Header("positions.txt", "DirName, TagName, Tag Length, Source Length, Position, minInAll");
                WriteRes_Header("positions_summary.txt", "DirName, Rule, minPos, MaxPos, AvgPos, minLegth, maxLegth, avgLegth, minInAll");
                //pos_inf
                Dictionary<string, int> min_pos = new Dictionary<string, int>();
                Dictionary<string, int> max_pos = new Dictionary<string, int>();
                Dictionary<string, double> avg_pos = new Dictionary<string, double>();
                Dictionary<string, int> cnt = new Dictionary<string, int>();
                Dictionary<string, int> min_source = new Dictionary<string, int>();
                Dictionary<string, int> max_source = new Dictionary<string, int>();
                Dictionary<string, double> avg_source = new Dictionary<string, double>();

                foreach (string theURL in url_list)
                {
                    if (rules.Length > 0)
                    {
                    string temp_html = download(theURL);                        

                        if(temp_html != "")
                        {
                            bool rules_ok = true;
                            //apply all rules, and take only web pages returned true from rules.
                            foreach (string theRule in rules)
                            {
                                string tag = theRule.Split(',')[0];
                                int res = ESMAJ.SearchAlgoritms.Search(tag, temp_html, 0, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                                if (res == -1)
                                {
                                    rules_ok = false;
                                    break;
                                }
                                else
                                {
                                    WriteRes("positions.txt", TXT_DirectoryName.Text.Trim() + "," + tag + "," + tag.Length + "," + temp_html.Length + "," + res + "," + theRule.Split(',')[1]);
                                    if (!min_pos.ContainsKey(theRule))
                                        min_pos.Add(theRule, res);
                                    else if (min_pos[theRule] > res)
                                        min_pos[theRule] = res;
                                    if (!max_pos.ContainsKey(theRule))
                                        max_pos.Add(theRule, res);
                                    else if (max_pos[theRule] < res)
                                        max_pos[theRule] = res;
                                    if (!avg_pos.ContainsKey(theRule))
                                        avg_pos.Add(theRule, res);
                                    else
                                        avg_pos[theRule] += res;

                                    if (!min_source.ContainsKey(theRule))
                                        min_source.Add(theRule, temp_html.Length);
                                    else if (min_source[theRule] > temp_html.Length)
                                        min_source[theRule] = temp_html.Length;
                                    if (!max_source.ContainsKey(theRule))
                                        max_source.Add(theRule, temp_html.Length);
                                    else if (max_source[theRule] < temp_html.Length)
                                        max_source[theRule] = temp_html.Length;
                                    if (!avg_source.ContainsKey(theRule))
                                        avg_source.Add(theRule, temp_html.Length);
                                    else
                                        avg_source[theRule] += temp_html.Length;

                                    if (!cnt.ContainsKey(theRule))
                                        cnt.Add(theRule, 1);
                                    else
                                        cnt[theRule] += 1;
                                }
                            }

                            //all rules passed...
                            if (rules_ok)
                            {
                                saveFile(temp_html, theURL);
                                page_count++;
                                if (page_count == 30)
                                    break;
                            }
                        }//temp_html check if                        
                    }                    
                }//foreach  

                foreach (string theRule in rules)
                {
                    if (avg_pos.Count > 0)
                    {
                        avg_pos[theRule] = (double)avg_pos[theRule] / cnt[theRule];
                        avg_source[theRule] = (double)avg_source[theRule] / cnt[theRule];
                        WriteRes("positions_summary.txt", TXT_DirectoryName.Text.Trim() + "," + theRule + "," + min_pos[theRule] + "," + max_pos[theRule] + "," + avg_pos[theRule] + "," + min_source[theRule] + "," + max_source[theRule] + "," + avg_source[theRule] + "," + theRule.Split(',')[1]);
                    }
                }
        }

        private List<string> all_links(string inputString, string url, string contain_str)
        {
            List<string> list = new List<string>();
            Match m;
            string HRefPattern = "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))";

            Uri base_url = new Uri(@url);
            url = base_url.Host;

            try
            {
                m = Regex.Match(inputString, HRefPattern,
                                RegexOptions.IgnoreCase | RegexOptions.Compiled,
                                TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    string temp = m.Groups[1].Value;                    
                        if (temp.Length > 3)
                            if (temp.Substring(0, 2) == "//")
                                temp = "https:" + temp;
                        temp = temp.Replace("../../", url + "/");
                        temp = temp.Replace("http://", "");
                        temp = temp.Replace("https://", "");

                        if (temp.Length > 2)
                            if (temp[0] == '/' && temp[1] != '/')
                                temp = url + "/" + temp.Substring(1);
                            else if (temp.Length > 4)
                                if (temp.Substring(0, 3) != "www")
                                {
                                    if (temp.Length > url.Length)
                                        if (temp.Substring(0, url.Length) != url)
                                            temp = url + "/" + temp;

                                }

                        if (temp.Length > (url.Length + 10) && !temp.Contains("video") && !temp.Contains("foto") && !temp.Contains("image") &&
                                                !temp.Contains("galeri") && !temp.Contains("gallery") && !temp.Contains("icerik") && !temp.Contains("css") && !temp.Contains("javascript") &&
                                                !temp.Contains(".ico") && !temp.Contains(".png") && !temp.Contains(".jpg") && !temp.Contains("category"))
                        {
                            if (contain_str == "")
                                list.Add(base_url.Scheme + "://" + temp);
                            else if (contain_str[0] == '!')
                            {
                                if (!temp.Contains(contain_str.Substring(1)))
                                    if (!list.Contains(base_url.Scheme + "://" + temp))
                                        list.Add(base_url.Scheme + "://" + temp);
                            }
                            else
                            {
                                if (temp.Contains(contain_str))
                                    if (!list.Contains(base_url.Scheme + "://" + temp))
                                        list.Add(base_url.Scheme + "://" + temp);
                            }
                        }
                
                    m = m.NextMatch();
                }

                return list;
            }
            catch (RegexMatchTimeoutException)
            {
                return list;                
            }
        }

        private void BTN_FindRules_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)//for all rule files
            {                
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");                
                TXT_Rules.Text = "";
                for (int i = 0; i < rules.Length; i++)
                {
                    string[] theRule = rules[i].Split(',');
                    if (theRule.Length > 2)
                    {
                        int min = -1;
                        int element_count = -2;
                        bool repetive = false;
                        int cnt = 0;
                        foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                        {
                            string source = File.ReadAllText(file2.FullName);
                            List<int> res = ESMAJ.SearchAlgoritms.Search(theRule[0], source, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                            if (res.Count > 0)
                            {
                                if (min == -1)
                                    min = res.Min();
                                else if (min > res.Min())
                                    min = res.Min();
                                List<string> res2 = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(theRule[0], source, 0, -1, false, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                                if (element_count == -2)//first_record
                                    element_count = UzunExtAlgorithmLib.UzunExtAlgorithm.endTag;
                                else if (element_count != UzunExtAlgorithmLib.UzunExtAlgorithm.endTag)
                                    element_count = -1;

                                if (res2.Count > 1)
                                    repetive = true;
                            }
                            cnt++;
                            //if (cnt == 20)
                            //   break;
                        }

                        TXT_Rules.Text += theRule[0] + "," + min + "," + element_count + "," + theRule[3] + "," + repetive;
                        if(i != rules.Length - 1)
                            TXT_Rules.Text += Environment.NewLine;
                    }//if rule length > 2
                }
                //save rule
                saveRules("Rules2\\" + file.Name);
                //File.AppendAllText("Rules2\\statistics5.txt", TXT_Rules.Text);
            }
        }

        private void BTN_PrepareML_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            string temp_str = "\"pos\"; \"target\"" + Environment.NewLine;
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");

                for (int i = 0; i < rules.Length; i++)
                {
                    string[] theRule = rules[i].Split(',');
                    if (theRule.Length > 2)
                    {
                        //Random %30
                        Random rnd = new Random();
                        foreach (FileInfo file2 in Files_html)
                        {
                            string source = File.ReadAllText(file2.FullName);
                            List<int> res = ESMAJ.SearchAlgoritms.Search(theRule[0], source, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                            if (res.Count > 0)
                            {
                                double pos = Math.Round(((double)res[0] / source.Length), 3);
                                double min_pos = Math.Round(((double)Convert.ToInt32(theRule[1]) / source.Length), 3);
                                temp_str += pos + ";" + min_pos + Environment.NewLine;
                            }
                        }
                    }//if rule length > 2
                }
                //save ML
                File.WriteAllText("ML2.csv", temp_str);
            }

        }

        private string elementName(string element)
        {
            element = element.Replace(">", " ");
            return element.Substring(1, element.IndexOf(" ") - 1);
        }

        private void BTN_Test4_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Statistics_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");
                List<double> fs_ls = new List<double>();
                List<double> ch_ls = new List<double>();
                List<double> r_ls = new List<double>();
                double fs_min = -1; double fs_max = -1; double t_fs = 0;
                int ch_min = -1; int ch_max = -1; int t_ch = 0;
                int r_min = -1; int r_max = -1; int t_r = 0;
                foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                {
                    string source = File.ReadAllText(file2.FullName);
                    List<int> res = ESMAJ.SearchAlgoritms.Search("</", source, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                    double fs = (double)file2.Length / 1024;
                    t_fs += fs;
                    if (fs_min == -1)  fs_min = fs; else if (fs < fs_min) fs_min = fs;
                    if (fs_max == -1)  fs_max = fs; else if (fs > fs_max) fs_max = fs;
                    fs_ls.Add(fs);

                    int ch = source.Length;
                    t_ch += ch;
                    if (ch_min == -1) ch_min = ch; else if (ch < ch_min) ch_min = ch;
                    if (ch_max == -1) ch_max = ch; else if (ch > ch_max) ch_max = ch;
                    ch_ls.Add(ch);

                    int r = res.Count;
                    t_r += r;
                    if (r_min == -1) r_min = r; else if (r < r_min) r_min = r;
                    if (r_max == -1) r_max = r; else if (r > r_max) r_max = r;
                    r_ls.Add(r);

                    File.AppendAllText("Statistics\\file1.txt", file.Name.Replace(".txt", "") + "," + fs + "," + ch + "," + r + Environment.NewLine);
                }
                double avg_fs = t_fs / fs_ls.Count;
                double avg_ch = t_ch / ch_ls.Count;
                double avg_r = t_r / r_ls.Count;

                double std_fs = 0;
                double std_ch = 0;
                double std_r = 0;
                //std
                for (int i = 0; i < fs_ls.Count; i++)
                {
                    std_fs += (avg_fs - fs_ls[i]) * (avg_fs - fs_ls[i]);
                    std_ch += (avg_ch - ch_ls[i]) * (avg_ch - ch_ls[i]);
                    std_r += (avg_r - r_ls[i]) * (avg_r - r_ls[i]);
                }
                std_fs = Math.Sqrt(std_fs / (fs_ls.Count - 1));
                std_ch = Math.Sqrt(std_ch / (ch_ls.Count - 1));
                std_r = Math.Sqrt(std_r / (r_ls.Count - 1));
                File.AppendAllText("Statistics\\file2.txt", file.Name.Replace(".txt", "") + "," 
                    + avg_fs + "," + fs_min + "," + fs_max + "," + std_fs + ","
                    +avg_ch + "," + ch_min + "," + ch_max + "," + std_ch + ","
                    +avg_r + "," + r_min + "," + r_max + "," + std_r +
                    Environment.NewLine);
                //save rule
            }
        }

        private void Btn_Statistics2_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");
                TXT_Rules.Text = "";
                for (int i = 0; i < rules.Length; i++)
                {
                    string[] theRule = rules[i].Split(',');
                    if (theRule.Length > 2)
                    {
                        int min = -1;
                        int element_count = -2;
                        int rescnt = 0;
                        foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                        {
                            string source = File.ReadAllText(file2.FullName);
                            List<int> res = ESMAJ.SearchAlgoritms.Search(theRule[0], source, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                            rescnt = res.Count();
                            if (res.Count > 0)
                            {
                                if (min == -1)
                                    min = res[0];
                                else if (min > res[0])
                                    min = res[0];
                                List<string> res2 = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(theRule[0], source, 0, -1, true, ESMAJ.SearchAlgoritms.SearchAlgorithm.NET_IndexOf_Ordinal);
                                
                                if (element_count == -2)//first_record
                                    element_count = UzunExtAlgorithmLib.UzunExtAlgorithm.endTag;
                                else if (element_count != UzunExtAlgorithmLib.UzunExtAlgorithm.endTag)
                                    element_count = -1;
                            }
                        }
                        string id = "0";
                        if (theRule[0].Contains("id"))
                            id = "1";
                        string cls = "0";
                        if (theRule[0].Contains("class"))
                            cls = "1";
                        string tmp = theRule[0].Replace("id=", "");
                        tmp = tmp.Replace("class=", "");
                        string otheratt = "0";
                        if (tmp.Contains("="))
                            otheratt = "1";

                        File.AppendAllText("Statistics\\rule.txt", file.Name.Replace(".txt", "") + "," + theRule[0] + "," + theRule[0].Length + "," + elementName(theRule[0]) + "," + theRule[3]
                            + "," + id + "," + cls + "," + otheratt + "," + element_count + "," + rescnt + Environment.NewLine);
                    }//if rule length > 2
                }
                //save rule
            }
        }

        private void BTN_ModelSave_Click(object sender, EventArgs e)
        {
            //UzunAlgorithmLib.RegressionLayer rl = new UzunAlgorithmLib.RegressionLayer();
            //rl.SaveModel(System.IO.Directory.GetCurrentDirectory());
        }

        private void BTN_Search2_Click(object sender, EventArgs e)
        {
            string dosya1 = "Search_" + CB_Alg.Text + ".txt";
            WriteRes_Header(dosya1, "FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, findPos, minPos, domain, category, element");
            string dosya2 = "SearchPos_" + CB_Alg.Text + ".txt";
            WriteRes_Header(dosya2, "FileName,Tag Length, Source Length, preProcess Time, Search Time, Total, findPos, minPos, domain, category, element");

            Dictionary<string, string> dl = DomainList();

            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string path = "Dataset\\" + file.Name.Replace(".txt", "") + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");
                TXT_Rules.Text = "";
                for (int i = 0; i < rules.Length; i++)
                {
                    string[] theRule = rules[i].Split(',');
                    string domain = file.Name.Replace(".txt", "");
                    int startPos = Convert.ToInt32(theRule[1]);
                    if (theRule.Length > 2)
                    {
                        string eName = elementName(theRule[0]);

                        foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                        {
                            List<double> extractTime1 = new List<double>();
                            List<double> preProcessTime1 = new List<double>();
                            List<double> extractTime2 = new List<double>();
                            List<double> preProcessTime2 = new List<double>();

                            string source = File.ReadAllText(file2.FullName);
                            int pos = 0;
                            for (int j = 0; j < 8; j++)
                            {
                                pos = ESMAJ.SearchAlgoritms.Search(theRule[0], source, 0, (ESMAJ.SearchAlgoritms.SearchAlgorithm)CB_Alg.SelectedIndex);
                                extractTime1.Add(ESMAJ.SearchAlgoritms.searchTime);
                                preProcessTime1.Add(ESMAJ.SearchAlgoritms.preProcessTime);

                                pos = ESMAJ.SearchAlgoritms.Search(theRule[0], source, startPos, (ESMAJ.SearchAlgoritms.SearchAlgorithm)CB_Alg.SelectedIndex);
                                extractTime2.Add(ESMAJ.SearchAlgoritms.searchTime);
                                preProcessTime2.Add(ESMAJ.SearchAlgoritms.preProcessTime);

                            }

                            extractTime1.Sort();
                            preProcessTime1.Sort();
                            double temp_ptime1 = preProcessTime1.Take(5).Average();
                            double temp_etime1 = extractTime1.Take(5).Average();

                            WriteRes(dosya1, file2 + "," + theRule[0].Length + "," + source.Length + "," + temp_ptime1 +
                                       "," + temp_etime1 + "," + (temp_ptime1 + temp_etime1)
                                       + "," + pos + "," + theRule[1] + "," + domain + "," + dl[domain] + "," + eName);

                            extractTime2.Sort();
                            preProcessTime2.Sort();
                            double temp_ptime2 = preProcessTime2.Take(5).Average();
                            double temp_etime2 = extractTime2.Take(5).Average();

                            WriteRes(dosya2, file2 + "," + theRule[0].Length + "," + source.Length + "," + temp_ptime2 +
                                       "," + temp_etime2 + "," + (temp_ptime2 + temp_etime2)
                                       + "," + pos + "," + theRule[1] + "," + domain + "," + dl[domain] + "," + eName);
                        }
                    }//if rule length > 2
                }
                //save rule
            }
        }

        private void BTN_CrawlTest_Click(object sender, EventArgs e)
        {
            string dosya1 = "Novel_AVG_" + CB_Alg.Text + "_" + CB_PosLearn.SelectedIndex + "_" + CB_ITC.SelectedIndex + "_" + CB_Repetition.SelectedIndex + ".txt";
            WriteRes_Header(dosya1, "No,FileName,TagLength,SourceLength,PrepRocessTime,SearchTime,TotalTime,FindPos,MinPos,LearnerPos,Topic,Domain,Category,ElementName,InnerTagCount," +
                "LearnerITC,Repetition,LearnerRep,Res0Length,ResCount,SearchTimes");

            ESMAJ.SearchAlgoritms.SearchAlgorithm sa = (ESMAJ.SearchAlgoritms.SearchAlgorithm)CB_Alg.SelectedIndex;

            Dictionary<string, string> dl = DomainList();

            DirectoryInfo d = new DirectoryInfo("Rules");
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)//for all rule files
            {
                string[] rules = File.ReadAllLines(file.FullName);
                string domain = file.Name.Replace(".txt", "");
                string path = "Dataset\\" + domain + "\\";
                DirectoryInfo d_inner = new DirectoryInfo(path);
                FileInfo[] Files_html = d_inner.GetFiles("*.html");
                TXT_Rules.Text = "";
                for (int i = 0; i < rules.Length; i++)
                {
                    string[] theRule = rules[i].Split(',');
                    if (theRule.Length > 2)
                    {
                        string eName = elementName(theRule[0]);
                        int static_startingPos = Convert.ToInt32(theRule[1]);
                        int static_ITC = Convert.ToInt32(theRule[2]);
                        string category = theRule[3];
                        bool static_repetition = Convert.ToBoolean(theRule[4]);

                        int learn_StartingPos = -1;
                        if (CB_PosLearn.SelectedIndex == 0)
                            learn_StartingPos = -2;
                        else if (CB_PosLearn.SelectedIndex == 1)
                            learn_StartingPos = -1;
                        else if (CB_PosLearn.SelectedIndex == 2)
                            learn_StartingPos = static_startingPos;
                        else
                            learn_StartingPos = -3;

                        int learn_ITC = -1;
                        if (CB_ITC.SelectedIndex == 1)
                            learn_ITC = static_ITC;
                        else if (CB_ITC.SelectedIndex == 2)
                            learn_ITC = -2;


                        int learn_Repetition = -1;
                        if (CB_Repetition.SelectedIndex == 0)
                            learn_Repetition = -1;
                        else if (CB_Repetition.SelectedIndex == 1)
                        {
                            if (static_repetition)
                                learn_Repetition = 2;
                            else
                                learn_Repetition = 1;
                        }
                        else if (CB_Repetition.SelectedIndex == 2)
                            learn_Repetition = -2;
                        else
                            learn_Repetition = -3;

                        UzunExtAlgorithmLib.LearningLayer _LL = new UzunExtAlgorithmLib.LearningLayer(learn_StartingPos, learn_ITC, learn_Repetition);

                       
                        int dosyano = 1;
                        foreach (FileInfo file2 in Files_html)// for all files in directory of rule
                        {
                            List<double> extractTime = new List<double>();
                            List<double> preProcessTime = new List<double>();
                            string source = File.ReadAllText(file2.FullName);
                            //warm up
                            List<string> res;
                            if(CB_Alg.SelectedIndex <= 34)
                            {
                                res = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(theRule[0], source, _LL.startingPos, _LL.innerTag, _LL.repetition, sa);
                                for (int j = 0; j < 8; j++)
                                {
                                    //5 test
                                    res = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(theRule[0], source, _LL.startingPos, _LL.innerTag, _LL.repetition, sa);
                                    if (res != null)
                                    {
                                        preProcessTime.Add(UzunExtAlgorithmLib.UzunExtAlgorithm.preProcessTime);
                                        extractTime.Add(UzunExtAlgorithmLib.UzunExtAlgorithm.searchTime);
                                    }
                                }//5 test
                                res = UzunExtAlgorithmLib.UzunExtAlgorithm.Extract(theRule[0], source, _LL.startingPos, _LL.innerTag, _LL.repetition, sa);
                                if (res != null)
                                    if (res.Count > 0)
                                    {                                        
                                        int search_times = 1;
                                        int pos = ESMAJ.SearchAlgoritms.Search(theRule[0], source, _LL.startingPos, sa);
                                        if (pos == -1)
                                        {
                                            pos = ESMAJ.SearchAlgoritms.Search(theRule[0], source.Substring(0, _LL.startingPos), 0, sa);
                                            if (pos == -1)
                                                search_times = 3;
                                            else
                                                search_times = 2;
                                        }

                                        int resSize = 0;
                                        foreach (string item in res)
                                            if (item != null)
                                                resSize += item.Length;

                                        extractTime.Sort();
                                        preProcessTime.Sort();
                                        double temp_ptime = preProcessTime.Take(5).Average();
                                        double temp_etime = extractTime.Take(5).Average();
                                        WriteRes(dosya1, dosyano + "," + file2 + "," + theRule[0].Length + "," + source.Length + "," +
                                          temp_ptime + "," + temp_etime + "," + (temp_ptime + temp_etime) + ","
                                          + UzunExtAlgorithmLib.UzunExtAlgorithm.first_pos + "," + static_startingPos + "," + _LL.startingPos + "," +
                                          domain + "," + dl[domain] + "," + category + "," + eName + "," + static_ITC + "," + _LL.innerTag + "," +
                                          static_repetition + "," + _LL.repetition + "," + resSize + "," + res.Count + "," + search_times);

                                        _LL.Check_Values(UzunExtAlgorithmLib.UzunExtAlgorithm.first_pos, source.Length, UzunExtAlgorithmLib.UzunExtAlgorithm.endTag, UzunExtAlgorithmLib.UzunExtAlgorithm.repeat);
                                        dosyano++;
                                    }
                            }
                            else if(CB_Alg.SelectedIndex <= 37)
                            {
                                res = DOMBasedAlgorithms.DOMBased.Extract(theRule[0], source, (DOMBasedAlgorithms.DOMBased.DOMAlgorithm)(CB_Alg.SelectedIndex - 35));
                                for (int j = 0; j < 8; j++)
                                {
                                    //5 test
                                    res = DOMBasedAlgorithms.DOMBased.Extract(theRule[0], source, (DOMBasedAlgorithms.DOMBased.DOMAlgorithm)(CB_Alg.SelectedIndex - 35));
                                    if (res != null)
                                    {
                                        preProcessTime.Add(DOMBasedAlgorithms.DOMBased.preProcessTime);
                                        extractTime.Add(DOMBasedAlgorithms.DOMBased.searchTime);
                                    }
                                }//5 test

                                if(res != null)
                                    if(res.Count>0)
                                    {
                                        int resSize = 0;
                                        foreach (string item in res)
                                            if (item != null)
                                                resSize += item.Length;

                                        extractTime.Sort();
                                        preProcessTime.Sort();
                                        double temp_ptime = preProcessTime.Take(5).Average();
                                        double temp_etime = extractTime.Take(5).Average();
                                        WriteRes(dosya1, dosyano + "," + file2 + "," + theRule[0].Length + "," + source.Length + "," +
                                          temp_ptime + "," + temp_etime + "," + (temp_ptime + temp_etime) + ","
                                           + "-10,-10,-10," +
                                           domain + "," + dl[domain] + "," + category + "," + eName + ",-10,-10,-10,-10," + resSize + "," + res.Count);
                                        dosyano++;
                                    }
                            }
                            else
                            {
                                string[] sres = SET_Parser.SET_Parser.Contents_of_givenLayout_Tags_TESTER(source, theRule[0], false);
                                for (int j = 0; j < 8; j++)
                                {
                                    //5 test
                                    sres = SET_Parser.SET_Parser.Contents_of_givenLayout_Tags_TESTER(source, theRule[0], false);
                                    if (sres != null)
                                    {
                                        preProcessTime.Add(SET_Parser.SET_Parser.preProcessTime);
                                        extractTime.Add(SET_Parser.SET_Parser.searchTime);
                                    }
                                }//5 test

                                res = null;
                                if (sres != null)
                                    res = new List<string>(sres);

                                if (res != null)
                                    if (res.Count > 0)
                                    {
                                        int resSize = 0;
                                        foreach (string item in res)
                                            if (item != null)
                                                resSize += item.Length;

                                        extractTime.Sort();
                                        preProcessTime.Sort();
                                        double temp_ptime = preProcessTime.Take(5).Average();
                                        double temp_etime = extractTime.Take(5).Average();
                                        WriteRes(dosya1, dosyano + "," + file2 + "," + theRule[0].Length + "," + source.Length + "," +
                                          temp_ptime + "," + temp_etime + "," + (temp_ptime + temp_etime) + ","
                                           + "-10,-10,-10," +
                                           domain + "," + dl[domain] + "," + category + "," + eName + ",-10,-10,-10,-10," + resSize + "," + res.Count);
                                        dosyano++;
                                    }
                            }//algorithms                                                     
                        }
                    }//if rule length > 2
                }
                //save rule
            }
        }
    }
}
