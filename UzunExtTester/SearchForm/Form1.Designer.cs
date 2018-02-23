namespace SearchForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TXT_TagName = new System.Windows.Forms.TextBox();
            this.LBL_TagName = new System.Windows.Forms.Label();
            this.BTN_Extract = new System.Windows.Forms.Button();
            this.TXT_Result = new System.Windows.Forms.TextBox();
            this.LBL_Result = new System.Windows.Forms.Label();
            this.TXT_Pos = new System.Windows.Forms.TextBox();
            this.LBL_Pos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Process = new System.Windows.Forms.ComboBox();
            this.LBL_Url = new System.Windows.Forms.Label();
            this.TXT_Url = new System.Windows.Forms.TextBox();
            this.BTN_LoadURL = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TXT_Source = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WB1 = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TXT_SourceResult = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.WB2 = new System.Windows.Forms.WebBrowser();
            this.LBL_EndTag = new System.Windows.Forms.Label();
            this.TXT_EndTag = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXT_TagName
            // 
            this.TXT_TagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_TagName.Location = new System.Drawing.Point(159, 49);
            this.TXT_TagName.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_TagName.Name = "TXT_TagName";
            this.TXT_TagName.Size = new System.Drawing.Size(416, 28);
            this.TXT_TagName.TabIndex = 0;
            this.TXT_TagName.Text = "<div class=\"entry-content\">";
            // 
            // LBL_TagName
            // 
            this.LBL_TagName.AutoSize = true;
            this.LBL_TagName.Location = new System.Drawing.Point(13, 52);
            this.LBL_TagName.Name = "LBL_TagName";
            this.LBL_TagName.Size = new System.Drawing.Size(107, 24);
            this.LBL_TagName.TabIndex = 2;
            this.LBL_TagName.Text = "Tag Name";
            // 
            // BTN_Extract
            // 
            this.BTN_Extract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BTN_Extract.Location = new System.Drawing.Point(586, 9);
            this.BTN_Extract.Name = "BTN_Extract";
            this.BTN_Extract.Size = new System.Drawing.Size(195, 29);
            this.BTN_Extract.TabIndex = 4;
            this.BTN_Extract.Text = "Run";
            this.BTN_Extract.UseVisualStyleBackColor = true;
            this.BTN_Extract.Click += new System.EventHandler(this.BTN_Extract_Click);
            // 
            // TXT_Result
            // 
            this.TXT_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_Result.Location = new System.Drawing.Point(789, 49);
            this.TXT_Result.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Result.Multiline = true;
            this.TXT_Result.Name = "TXT_Result";
            this.TXT_Result.Size = new System.Drawing.Size(677, 678);
            this.TXT_Result.TabIndex = 5;
            // 
            // LBL_Result
            // 
            this.LBL_Result.AutoSize = true;
            this.LBL_Result.Location = new System.Drawing.Point(788, 21);
            this.LBL_Result.Name = "LBL_Result";
            this.LBL_Result.Size = new System.Drawing.Size(68, 24);
            this.LBL_Result.TabIndex = 6;
            this.LBL_Result.Text = "Result";
            // 
            // TXT_Pos
            // 
            this.TXT_Pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_Pos.Location = new System.Drawing.Point(159, 84);
            this.TXT_Pos.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Pos.Name = "TXT_Pos";
            this.TXT_Pos.Size = new System.Drawing.Size(119, 28);
            this.TXT_Pos.TabIndex = 7;
            this.TXT_Pos.Text = "8000";
            this.TXT_Pos.Visible = false;
            // 
            // LBL_Pos
            // 
            this.LBL_Pos.AutoSize = true;
            this.LBL_Pos.Location = new System.Drawing.Point(15, 88);
            this.LBL_Pos.Name = "LBL_Pos";
            this.LBL_Pos.Size = new System.Drawing.Size(100, 24);
            this.LBL_Pos.TabIndex = 8;
            this.LBL_Pos.Text = "startIndex";
            this.LBL_Pos.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Process";
            // 
            // CB_Process
            // 
            this.CB_Process.FormattingEnabled = true;
            this.CB_Process.Items.AddRange(new object[] {
            "Search All",
            "Search by Position (Find First and break)",
            "Extract by Pos=0 (One content)",
            "Extract by Position (One content)",
            "Extract by Pos=0 (All contents)",
            "Extract by Position (All contents)",
            "Extract by Pos=0 & End Tag (One content)",
            "Extract by Position & End Tag (One content)",
            "Extract by Pos=0 & End Tag (All contents)",
            "Extract by Position & End Tag (All contents)",
            "Extract by DOM Algoritms",
            "Extract by SetParser"});
            this.CB_Process.Location = new System.Drawing.Point(159, 11);
            this.CB_Process.Name = "CB_Process";
            this.CB_Process.Size = new System.Drawing.Size(416, 30);
            this.CB_Process.TabIndex = 16;
            this.CB_Process.Text = "Search All";
            this.CB_Process.SelectedIndexChanged += new System.EventHandler(this.CB_Process_SelectedIndexChanged);
            // 
            // LBL_Url
            // 
            this.LBL_Url.AutoSize = true;
            this.LBL_Url.Location = new System.Drawing.Point(17, 123);
            this.LBL_Url.Name = "LBL_Url";
            this.LBL_Url.Size = new System.Drawing.Size(49, 24);
            this.LBL_Url.TabIndex = 18;
            this.LBL_Url.Text = "URL";
            // 
            // TXT_Url
            // 
            this.TXT_Url.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_Url.Location = new System.Drawing.Point(159, 120);
            this.TXT_Url.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Url.Name = "TXT_Url";
            this.TXT_Url.Size = new System.Drawing.Size(416, 28);
            this.TXT_Url.TabIndex = 17;
            // 
            // BTN_LoadURL
            // 
            this.BTN_LoadURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BTN_LoadURL.Location = new System.Drawing.Point(586, 118);
            this.BTN_LoadURL.Name = "BTN_LoadURL";
            this.BTN_LoadURL.Size = new System.Drawing.Size(195, 29);
            this.BTN_LoadURL.TabIndex = 19;
            this.BTN_LoadURL.Text = "Download";
            this.BTN_LoadURL.UseVisualStyleBackColor = true;
            this.BTN_LoadURL.Click += new System.EventHandler(this.BTN_LoadURL_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(17, 155);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 572);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TXT_Source);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 537);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TXT_Source
            // 
            this.TXT_Source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TXT_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_Source.Location = new System.Drawing.Point(3, 3);
            this.TXT_Source.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_Source.MaxLength = 327670;
            this.TXT_Source.Multiline = true;
            this.TXT_Source.Name = "TXT_Source";
            this.TXT_Source.Size = new System.Drawing.Size(751, 531);
            this.TXT_Source.TabIndex = 2;
            this.TXT_Source.Text = resources.GetString("TXT_Source.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WB1);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Web Page";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WB1
            // 
            this.WB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB1.Location = new System.Drawing.Point(3, 3);
            this.WB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB1.Name = "WB1";
            this.WB1.ScriptErrorsSuppressed = true;
            this.WB1.Size = new System.Drawing.Size(751, 531);
            this.WB1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TXT_SourceResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(757, 537);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source Result";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TXT_SourceResult
            // 
            this.TXT_SourceResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TXT_SourceResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_SourceResult.Location = new System.Drawing.Point(3, 3);
            this.TXT_SourceResult.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_SourceResult.Multiline = true;
            this.TXT_SourceResult.Name = "TXT_SourceResult";
            this.TXT_SourceResult.Size = new System.Drawing.Size(751, 531);
            this.TXT_SourceResult.TabIndex = 3;
            this.TXT_SourceResult.Text = "\r\n";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.WB2);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(757, 537);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Web Results";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // WB2
            // 
            this.WB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB2.Location = new System.Drawing.Point(0, 0);
            this.WB2.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB2.Name = "WB2";
            this.WB2.ScriptErrorsSuppressed = true;
            this.WB2.Size = new System.Drawing.Size(757, 537);
            this.WB2.TabIndex = 0;
            // 
            // LBL_EndTag
            // 
            this.LBL_EndTag.AutoSize = true;
            this.LBL_EndTag.Location = new System.Drawing.Point(285, 84);
            this.LBL_EndTag.Name = "LBL_EndTag";
            this.LBL_EndTag.Size = new System.Drawing.Size(164, 24);
            this.LBL_EndTag.TabIndex = 22;
            this.LBL_EndTag.Text = "Count of end tag";
            this.LBL_EndTag.Visible = false;
            // 
            // TXT_EndTag
            // 
            this.TXT_EndTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TXT_EndTag.Location = new System.Drawing.Point(456, 83);
            this.TXT_EndTag.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_EndTag.Name = "TXT_EndTag";
            this.TXT_EndTag.Size = new System.Drawing.Size(119, 28);
            this.TXT_EndTag.TabIndex = 21;
            this.TXT_EndTag.Text = "127";
            this.TXT_EndTag.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 740);
            this.Controls.Add(this.LBL_EndTag);
            this.Controls.Add(this.TXT_EndTag);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BTN_LoadURL);
            this.Controls.Add(this.LBL_Url);
            this.Controls.Add(this.TXT_Url);
            this.Controls.Add(this.CB_Process);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_Pos);
            this.Controls.Add(this.TXT_Pos);
            this.Controls.Add(this.LBL_Result);
            this.Controls.Add(this.TXT_Result);
            this.Controls.Add(this.BTN_Extract);
            this.Controls.Add(this.LBL_TagName);
            this.Controls.Add(this.TXT_TagName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Search-Based and DOM-Based Extraction";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_TagName;
        private System.Windows.Forms.Label LBL_TagName;
        private System.Windows.Forms.Button BTN_Extract;
        private System.Windows.Forms.TextBox TXT_Result;
        private System.Windows.Forms.Label LBL_Result;
        private System.Windows.Forms.TextBox TXT_Pos;
        private System.Windows.Forms.Label LBL_Pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Process;
        private System.Windows.Forms.Label LBL_Url;
        private System.Windows.Forms.TextBox TXT_Url;
        private System.Windows.Forms.Button BTN_LoadURL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox TXT_Source;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser WB1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox TXT_SourceResult;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser WB2;
        private System.Windows.Forms.Label LBL_EndTag;
        private System.Windows.Forms.TextBox TXT_EndTag;
    }
}

