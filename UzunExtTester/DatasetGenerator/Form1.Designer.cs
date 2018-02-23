namespace DatasetGenerator
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_DirectoryName = new System.Windows.Forms.Label();
            this.TXT_DirectoryName = new System.Windows.Forms.TextBox();
            this.TXT_Url = new System.Windows.Forms.TextBox();
            this.LBL_Url = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.TXT_Source = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WB1 = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTN_LoadRules = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_SaveRules = new System.Windows.Forms.Button();
            this.TXT_Rules = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CB_SearchText = new System.Windows.Forms.ComboBox();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.TXT_Res = new System.Windows.Forms.TextBox();
            this.LBL_Test = new System.Windows.Forms.Label();
            this.LBL_Tag = new System.Windows.Forms.Label();
            this.BTN_Download = new System.Windows.Forms.Button();
            this.LBL_Hata = new System.Windows.Forms.Label();
            this.CB_Alg = new System.Windows.Forms.ComboBox();
            this.BTN_Crawl = new System.Windows.Forms.Button();
            this.TXT_ContainStr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_FindRules = new System.Windows.Forms.Button();
            this.BTN_Statistics = new System.Windows.Forms.Button();
            this.Btn_Statistics2 = new System.Windows.Forms.Button();
            this.BTN_Search2 = new System.Windows.Forms.Button();
            this.LBL_Searching = new System.Windows.Forms.Label();
            this.LBL_Pos = new System.Windows.Forms.Label();
            this.CB_PosLearn = new System.Windows.Forms.ComboBox();
            this.LBL_IT = new System.Windows.Forms.Label();
            this.CB_ITC = new System.Windows.Forms.ComboBox();
            this.LBL_Rep = new System.Windows.Forms.Label();
            this.CB_Repetition = new System.Windows.Forms.ComboBox();
            this.BTN_CrawlTest = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_DirectoryName
            // 
            this.LBL_DirectoryName.AutoSize = true;
            this.LBL_DirectoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_DirectoryName.Location = new System.Drawing.Point(26, 22);
            this.LBL_DirectoryName.Name = "LBL_DirectoryName";
            this.LBL_DirectoryName.Size = new System.Drawing.Size(135, 20);
            this.LBL_DirectoryName.TabIndex = 0;
            this.LBL_DirectoryName.Text = "DirectoryName";
            // 
            // TXT_DirectoryName
            // 
            this.TXT_DirectoryName.Location = new System.Drawing.Point(167, 19);
            this.TXT_DirectoryName.Name = "TXT_DirectoryName";
            this.TXT_DirectoryName.Size = new System.Drawing.Size(278, 27);
            this.TXT_DirectoryName.TabIndex = 1;
            this.TXT_DirectoryName.Text = "E-adys";
            // 
            // TXT_Url
            // 
            this.TXT_Url.Location = new System.Drawing.Point(167, 52);
            this.TXT_Url.Name = "TXT_Url";
            this.TXT_Url.Size = new System.Drawing.Size(706, 27);
            this.TXT_Url.TabIndex = 3;
            this.TXT_Url.Text = "https://www.e-adys.com/obfc-js/object-based-flow-charts-obfc-js/";
            // 
            // LBL_Url
            // 
            this.LBL_Url.AutoSize = true;
            this.LBL_Url.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_Url.Location = new System.Drawing.Point(26, 55);
            this.LBL_Url.Name = "LBL_Url";
            this.LBL_Url.Size = new System.Drawing.Size(46, 20);
            this.LBL_Url.TabIndex = 2;
            this.LBL_Url.Text = "URL";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(30, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 585);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BTN_Save);
            this.tabPage1.Controls.Add(this.TXT_Source);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1017, 552);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(6, 3);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(289, 40);
            this.BTN_Save.TabIndex = 13;
            this.BTN_Save.Text = "Save source to dataset";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // TXT_Source
            // 
            this.TXT_Source.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TXT_Source.Location = new System.Drawing.Point(3, 49);
            this.TXT_Source.Multiline = true;
            this.TXT_Source.Name = "TXT_Source";
            this.TXT_Source.Size = new System.Drawing.Size(1011, 500);
            this.TXT_Source.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WB1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1017, 552);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Web Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WB1
            // 
            this.WB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB1.Location = new System.Drawing.Point(3, 3);
            this.WB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB1.Name = "WB1";
            this.WB1.ScriptErrorsSuppressed = true;
            this.WB1.Size = new System.Drawing.Size(1011, 546);
            this.WB1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BTN_LoadRules);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.BTN_SaveRules);
            this.tabPage3.Controls.Add(this.TXT_Rules);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1017, 552);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rules";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BTN_LoadRules
            // 
            this.BTN_LoadRules.Location = new System.Drawing.Point(15, 13);
            this.BTN_LoadRules.Name = "BTN_LoadRules";
            this.BTN_LoadRules.Size = new System.Drawing.Size(137, 31);
            this.BTN_LoadRules.TabIndex = 14;
            this.BTN_LoadRules.Text = "Load Rules";
            this.BTN_LoadRules.UseVisualStyleBackColor = true;
            this.BTN_LoadRules.Click += new System.EventHandler(this.BTN_LoadRules_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "The rules are saved to the same filename as the directory name.";
            // 
            // BTN_SaveRules
            // 
            this.BTN_SaveRules.Location = new System.Drawing.Point(158, 13);
            this.BTN_SaveRules.Name = "BTN_SaveRules";
            this.BTN_SaveRules.Size = new System.Drawing.Size(157, 31);
            this.BTN_SaveRules.TabIndex = 12;
            this.BTN_SaveRules.Text = "Save Rules";
            this.BTN_SaveRules.UseVisualStyleBackColor = true;
            this.BTN_SaveRules.Click += new System.EventHandler(this.BTN_SaveRules_Click);
            // 
            // TXT_Rules
            // 
            this.TXT_Rules.Location = new System.Drawing.Point(15, 50);
            this.TXT_Rules.Multiline = true;
            this.TXT_Rules.Name = "TXT_Rules";
            this.TXT_Rules.Size = new System.Drawing.Size(831, 482);
            this.TXT_Rules.TabIndex = 11;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CB_SearchText);
            this.tabPage4.Controls.Add(this.BTN_Search);
            this.tabPage4.Controls.Add(this.TXT_Res);
            this.tabPage4.Controls.Add(this.LBL_Test);
            this.tabPage4.Controls.Add(this.LBL_Tag);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1017, 552);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Try rule";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CB_SearchText
            // 
            this.CB_SearchText.FormattingEnabled = true;
            this.CB_SearchText.Location = new System.Drawing.Point(133, 28);
            this.CB_SearchText.Name = "CB_SearchText";
            this.CB_SearchText.Size = new System.Drawing.Size(327, 28);
            this.CB_SearchText.TabIndex = 13;
            // 
            // BTN_Search
            // 
            this.BTN_Search.Location = new System.Drawing.Point(466, 26);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(279, 31);
            this.BTN_Search.TabIndex = 12;
            this.BTN_Search.Text = "Search All";
            this.BTN_Search.UseVisualStyleBackColor = true;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // TXT_Res
            // 
            this.TXT_Res.Location = new System.Drawing.Point(16, 71);
            this.TXT_Res.Multiline = true;
            this.TXT_Res.Name = "TXT_Res";
            this.TXT_Res.Size = new System.Drawing.Size(729, 469);
            this.TXT_Res.TabIndex = 11;
            // 
            // LBL_Test
            // 
            this.LBL_Test.AutoSize = true;
            this.LBL_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_Test.Location = new System.Drawing.Point(22, 0);
            this.LBL_Test.Name = "LBL_Test";
            this.LBL_Test.Size = new System.Drawing.Size(270, 20);
            this.LBL_Test.TabIndex = 10;
            this.LBL_Test.Text = "Check your rules before saving";
            // 
            // LBL_Tag
            // 
            this.LBL_Tag.AutoSize = true;
            this.LBL_Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_Tag.Location = new System.Drawing.Point(12, 33);
            this.LBL_Tag.Name = "LBL_Tag";
            this.LBL_Tag.Size = new System.Drawing.Size(105, 20);
            this.LBL_Tag.TabIndex = 8;
            this.LBL_Tag.Text = "Search Tag";
            // 
            // BTN_Download
            // 
            this.BTN_Download.Location = new System.Drawing.Point(898, 52);
            this.BTN_Download.Name = "BTN_Download";
            this.BTN_Download.Size = new System.Drawing.Size(99, 30);
            this.BTN_Download.TabIndex = 10;
            this.BTN_Download.Text = "Download";
            this.BTN_Download.UseVisualStyleBackColor = true;
            this.BTN_Download.Click += new System.EventHandler(this.BTN_Download_Click);
            // 
            // LBL_Hata
            // 
            this.LBL_Hata.AutoSize = true;
            this.LBL_Hata.ForeColor = System.Drawing.Color.Red;
            this.LBL_Hata.Location = new System.Drawing.Point(466, 19);
            this.LBL_Hata.Name = "LBL_Hata";
            this.LBL_Hata.Size = new System.Drawing.Size(0, 20);
            this.LBL_Hata.TabIndex = 11;
            // 
            // CB_Alg
            // 
            this.CB_Alg.FormattingEnabled = true;
            this.CB_Alg.Location = new System.Drawing.Point(1061, 117);
            this.CB_Alg.Name = "CB_Alg";
            this.CB_Alg.Size = new System.Drawing.Size(299, 28);
            this.CB_Alg.TabIndex = 13;
            // 
            // BTN_Crawl
            // 
            this.BTN_Crawl.Location = new System.Drawing.Point(764, 17);
            this.BTN_Crawl.Name = "BTN_Crawl";
            this.BTN_Crawl.Size = new System.Drawing.Size(233, 30);
            this.BTN_Crawl.TabIndex = 17;
            this.BTN_Crawl.Text = "Crawl and Save";
            this.BTN_Crawl.UseVisualStyleBackColor = true;
            this.BTN_Crawl.Click += new System.EventHandler(this.BTN_Crawl_Click);
            // 
            // TXT_ContainStr
            // 
            this.TXT_ContainStr.Location = new System.Drawing.Point(645, 19);
            this.TXT_ContainStr.Name = "TXT_ContainStr";
            this.TXT_ContainStr.Size = new System.Drawing.Size(114, 27);
            this.TXT_ContainStr.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(459, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "TextinLink (Optimal)";
            // 
            // BTN_FindRules
            // 
            this.BTN_FindRules.Location = new System.Drawing.Point(1066, 572);
            this.BTN_FindRules.Name = "BTN_FindRules";
            this.BTN_FindRules.Size = new System.Drawing.Size(299, 28);
            this.BTN_FindRules.TabIndex = 20;
            this.BTN_FindRules.Text = "Calculate Rule Values 2";
            this.BTN_FindRules.UseVisualStyleBackColor = true;
            this.BTN_FindRules.Click += new System.EventHandler(this.BTN_FindRules_Click);
            // 
            // BTN_Statistics
            // 
            this.BTN_Statistics.Location = new System.Drawing.Point(1066, 606);
            this.BTN_Statistics.Name = "BTN_Statistics";
            this.BTN_Statistics.Size = new System.Drawing.Size(299, 28);
            this.BTN_Statistics.TabIndex = 25;
            this.BTN_Statistics.Text = "Statistics 1";
            this.BTN_Statistics.UseVisualStyleBackColor = true;
            this.BTN_Statistics.Click += new System.EventHandler(this.BTN_Statistics_Click);
            // 
            // Btn_Statistics2
            // 
            this.Btn_Statistics2.Location = new System.Drawing.Point(1066, 638);
            this.Btn_Statistics2.Name = "Btn_Statistics2";
            this.Btn_Statistics2.Size = new System.Drawing.Size(299, 28);
            this.Btn_Statistics2.TabIndex = 26;
            this.Btn_Statistics2.Text = "Statistics 2";
            this.Btn_Statistics2.UseVisualStyleBackColor = true;
            this.Btn_Statistics2.Click += new System.EventHandler(this.Btn_Statistics2_Click);
            // 
            // BTN_Search2
            // 
            this.BTN_Search2.Location = new System.Drawing.Point(1061, 18);
            this.BTN_Search2.Name = "BTN_Search2";
            this.BTN_Search2.Size = new System.Drawing.Size(299, 28);
            this.BTN_Search2.TabIndex = 27;
            this.BTN_Search2.Text = "Searching Test";
            this.BTN_Search2.UseVisualStyleBackColor = true;
            this.BTN_Search2.Click += new System.EventHandler(this.BTN_Search2_Click);
            // 
            // LBL_Searching
            // 
            this.LBL_Searching.AutoSize = true;
            this.LBL_Searching.Location = new System.Drawing.Point(1062, 88);
            this.LBL_Searching.Name = "LBL_Searching";
            this.LBL_Searching.Size = new System.Drawing.Size(160, 20);
            this.LBL_Searching.TabIndex = 28;
            this.LBL_Searching.Text = "Searching Algorithm";
            // 
            // LBL_Pos
            // 
            this.LBL_Pos.AutoSize = true;
            this.LBL_Pos.Location = new System.Drawing.Point(1062, 159);
            this.LBL_Pos.Name = "LBL_Pos";
            this.LBL_Pos.Size = new System.Drawing.Size(139, 20);
            this.LBL_Pos.TabIndex = 30;
            this.LBL_Pos.Text = "Position Learning";
            // 
            // CB_PosLearn
            // 
            this.CB_PosLearn.FormattingEnabled = true;
            this.CB_PosLearn.Items.AddRange(new object[] {
            "Learn with Position Index",
            "Learn with Ratio Position Index",
            "Static (Use Extraction Rules)",
            "Close"});
            this.CB_PosLearn.Location = new System.Drawing.Point(1061, 188);
            this.CB_PosLearn.Name = "CB_PosLearn";
            this.CB_PosLearn.Size = new System.Drawing.Size(299, 28);
            this.CB_PosLearn.TabIndex = 29;
            this.CB_PosLearn.Text = "Learn with Ratio Position Index";
            // 
            // LBL_IT
            // 
            this.LBL_IT.AutoSize = true;
            this.LBL_IT.Location = new System.Drawing.Point(1062, 230);
            this.LBL_IT.Name = "LBL_IT";
            this.LBL_IT.Size = new System.Drawing.Size(128, 20);
            this.LBL_IT.TabIndex = 32;
            this.LBL_IT.Text = "Inner Tag Count";
            // 
            // CB_ITC
            // 
            this.CB_ITC.FormattingEnabled = true;
            this.CB_ITC.Items.AddRange(new object[] {
            "Learn from 10 web pages",
            "Static (Use Extraction Rules)",
            "Close"});
            this.CB_ITC.Location = new System.Drawing.Point(1061, 259);
            this.CB_ITC.Name = "CB_ITC";
            this.CB_ITC.Size = new System.Drawing.Size(299, 28);
            this.CB_ITC.TabIndex = 31;
            this.CB_ITC.Text = "Learn from 10 web pages";
            // 
            // LBL_Rep
            // 
            this.LBL_Rep.AutoSize = true;
            this.LBL_Rep.Location = new System.Drawing.Point(1062, 303);
            this.LBL_Rep.Name = "LBL_Rep";
            this.LBL_Rep.Size = new System.Drawing.Size(84, 20);
            this.LBL_Rep.TabIndex = 34;
            this.LBL_Rep.Text = "Repetition";
            // 
            // CB_Repetition
            // 
            this.CB_Repetition.FormattingEnabled = true;
            this.CB_Repetition.Items.AddRange(new object[] {
            "Learn from 10 web pages",
            "Static (Use Extraction Rules)",
            "Close (True)",
            "Close (False)"});
            this.CB_Repetition.Location = new System.Drawing.Point(1061, 332);
            this.CB_Repetition.Name = "CB_Repetition";
            this.CB_Repetition.Size = new System.Drawing.Size(299, 28);
            this.CB_Repetition.TabIndex = 33;
            this.CB_Repetition.Text = "Learn from 10 web pages";
            // 
            // BTN_CrawlTest
            // 
            this.BTN_CrawlTest.Location = new System.Drawing.Point(1061, 379);
            this.BTN_CrawlTest.Name = "BTN_CrawlTest";
            this.BTN_CrawlTest.Size = new System.Drawing.Size(299, 28);
            this.BTN_CrawlTest.TabIndex = 35;
            this.BTN_CrawlTest.Text = "Start Extraction Test";
            this.BTN_CrawlTest.UseVisualStyleBackColor = true;
            this.BTN_CrawlTest.Click += new System.EventHandler(this.BTN_CrawlTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 685);
            this.Controls.Add(this.BTN_CrawlTest);
            this.Controls.Add(this.LBL_Rep);
            this.Controls.Add(this.CB_Repetition);
            this.Controls.Add(this.LBL_IT);
            this.Controls.Add(this.CB_ITC);
            this.Controls.Add(this.LBL_Pos);
            this.Controls.Add(this.CB_PosLearn);
            this.Controls.Add(this.LBL_Searching);
            this.Controls.Add(this.BTN_Search2);
            this.Controls.Add(this.Btn_Statistics2);
            this.Controls.Add(this.BTN_Statistics);
            this.Controls.Add(this.BTN_FindRules);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_ContainStr);
            this.Controls.Add(this.BTN_Crawl);
            this.Controls.Add(this.CB_Alg);
            this.Controls.Add(this.LBL_Hata);
            this.Controls.Add(this.BTN_Download);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TXT_Url);
            this.Controls.Add(this.LBL_Url);
            this.Controls.Add(this.TXT_DirectoryName);
            this.Controls.Add(this.LBL_DirectoryName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Dataset Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_DirectoryName;
        private System.Windows.Forms.TextBox TXT_DirectoryName;
        private System.Windows.Forms.TextBox TXT_Url;
        private System.Windows.Forms.Label LBL_Url;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox TXT_Source;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser WB1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BTN_LoadRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_SaveRules;
        private System.Windows.Forms.TextBox TXT_Rules;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox TXT_Res;
        private System.Windows.Forms.Label LBL_Test;
        private System.Windows.Forms.Label LBL_Tag;
        private System.Windows.Forms.Button BTN_Download;
        private System.Windows.Forms.Label LBL_Hata;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.ComboBox CB_Alg;
        private System.Windows.Forms.ComboBox CB_SearchText;
        private System.Windows.Forms.Button BTN_Crawl;
        private System.Windows.Forms.TextBox TXT_ContainStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_FindRules;
        private System.Windows.Forms.Button BTN_Statistics;
        private System.Windows.Forms.Button Btn_Statistics2;
        private System.Windows.Forms.Button BTN_Search2;
        private System.Windows.Forms.Label LBL_Searching;
        private System.Windows.Forms.Label LBL_Pos;
        private System.Windows.Forms.ComboBox CB_PosLearn;
        private System.Windows.Forms.Label LBL_IT;
        private System.Windows.Forms.ComboBox CB_ITC;
        private System.Windows.Forms.Label LBL_Rep;
        private System.Windows.Forms.ComboBox CB_Repetition;
        private System.Windows.Forms.Button BTN_CrawlTest;
    }
}

