namespace LogReader
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView_log = new System.Windows.Forms.ListView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_equipInfo = new System.Windows.Forms.GroupBox();
            this.label_SN_Value = new System.Windows.Forms.Label();
            this.label_softwarVer_Value = new System.Windows.Forms.Label();
            this.label_equipType_Value = new System.Windows.Forms.Label();
            this.label_SN = new System.Windows.Forms.Label();
            this.label_softwarVer = new System.Windows.Forms.Label();
            this.label_equipType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_listview_jumpto = new System.Windows.Forms.Label();
            this.textBox_jumpto = new System.Windows.Forms.TextBox();
            this.textBox_listview_currentpage = new System.Windows.Forms.TextBox();
            this.button_next_page = new System.Windows.Forms.Button();
            this.button_pre_page = new System.Windows.Forms.Button();
            this.button_end_page = new System.Windows.Forms.Button();
            this.button_top_page = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox_equipInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1401, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.importDataToolStripMenuItem});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(42, 24);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.chineseToolStripMenuItem.Text = "Chinese";
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.importDataToolStripMenuItem.Text = "ImportData";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listView_log
            // 
            this.listView_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_log.HideSelection = false;
            this.listView_log.Location = new System.Drawing.Point(6, 105);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(1377, 359);
            this.listView_log.TabIndex = 1;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox_equipInfo
            // 
            this.groupBox_equipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_equipInfo.Controls.Add(this.label_SN_Value);
            this.groupBox_equipInfo.Controls.Add(this.label_softwarVer_Value);
            this.groupBox_equipInfo.Controls.Add(this.label_equipType_Value);
            this.groupBox_equipInfo.Controls.Add(this.label_SN);
            this.groupBox_equipInfo.Controls.Add(this.label_softwarVer);
            this.groupBox_equipInfo.Controls.Add(this.label_equipType);
            this.groupBox_equipInfo.Location = new System.Drawing.Point(13, 49);
            this.groupBox_equipInfo.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_equipInfo.Name = "groupBox_equipInfo";
            this.groupBox_equipInfo.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_equipInfo.Size = new System.Drawing.Size(1382, 82);
            this.groupBox_equipInfo.TabIndex = 2;
            this.groupBox_equipInfo.TabStop = false;
            this.groupBox_equipInfo.Text = "Equipment Info";
            // 
            // label_SN_Value
            // 
            this.label_SN_Value.AutoSize = true;
            this.label_SN_Value.Location = new System.Drawing.Point(329, 39);
            this.label_SN_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SN_Value.Name = "label_SN_Value";
            this.label_SN_Value.Size = new System.Drawing.Size(23, 15);
            this.label_SN_Value.TabIndex = 5;
            this.label_SN_Value.Text = "NA";
            // 
            // label_softwarVer_Value
            // 
            this.label_softwarVer_Value.AutoSize = true;
            this.label_softwarVer_Value.Location = new System.Drawing.Point(643, 39);
            this.label_softwarVer_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_softwarVer_Value.Name = "label_softwarVer_Value";
            this.label_softwarVer_Value.Size = new System.Drawing.Size(23, 15);
            this.label_softwarVer_Value.TabIndex = 4;
            this.label_softwarVer_Value.Text = "NA";
            // 
            // label_equipType_Value
            // 
            this.label_equipType_Value.AutoSize = true;
            this.label_equipType_Value.Location = new System.Drawing.Point(78, 39);
            this.label_equipType_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_equipType_Value.Name = "label_equipType_Value";
            this.label_equipType_Value.Size = new System.Drawing.Size(23, 15);
            this.label_equipType_Value.TabIndex = 3;
            this.label_equipType_Value.Text = "NA";
            // 
            // label_SN
            // 
            this.label_SN.AutoSize = true;
            this.label_SN.Location = new System.Drawing.Point(283, 39);
            this.label_SN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SN.Name = "label_SN";
            this.label_SN.Size = new System.Drawing.Size(38, 15);
            this.label_SN.TabIndex = 2;
            this.label_SN.Text = "SN：";
            // 
            // label_softwarVer
            // 
            this.label_softwarVer.AutoSize = true;
            this.label_softwarVer.Location = new System.Drawing.Point(502, 39);
            this.label_softwarVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_softwarVer.Name = "label_softwarVer";
            this.label_softwarVer.Size = new System.Drawing.Size(118, 15);
            this.label_softwarVer.TabIndex = 1;
            this.label_softwarVer.Text = "Software Ver：";
            // 
            // label_equipType
            // 
            this.label_equipType.AutoSize = true;
            this.label_equipType.Location = new System.Drawing.Point(8, 39);
            this.label_equipType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_equipType.Name = "label_equipType";
            this.label_equipType.Size = new System.Drawing.Size(62, 15);
            this.label_equipType.TabIndex = 0;
            this.label_equipType.Text = "Model：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label_listview_jumpto);
            this.groupBox1.Controls.Add(this.textBox_jumpto);
            this.groupBox1.Controls.Add(this.textBox_listview_currentpage);
            this.groupBox1.Controls.Add(this.button_next_page);
            this.groupBox1.Controls.Add(this.button_pre_page);
            this.groupBox1.Controls.Add(this.button_end_page);
            this.groupBox1.Controls.Add(this.button_top_page);
            this.groupBox1.Controls.Add(this.listView_log);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1389, 470);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label_listview_jumpto
            // 
            this.label_listview_jumpto.AutoSize = true;
            this.label_listview_jumpto.Location = new System.Drawing.Point(623, 55);
            this.label_listview_jumpto.Name = "label_listview_jumpto";
            this.label_listview_jumpto.Size = new System.Drawing.Size(71, 15);
            this.label_listview_jumpto.TabIndex = 8;
            this.label_listview_jumpto.Text = "Jump To:";
            // 
            // textBox_jumpto
            // 
            this.textBox_jumpto.Location = new System.Drawing.Point(727, 52);
            this.textBox_jumpto.Name = "textBox_jumpto";
            this.textBox_jumpto.Size = new System.Drawing.Size(81, 25);
            this.textBox_jumpto.TabIndex = 7;
            this.textBox_jumpto.TextChanged += new System.EventHandler(this.textBox_jumpto_TextChanged);
            // 
            // textBox_listview_currentpage
            // 
            this.textBox_listview_currentpage.Location = new System.Drawing.Point(473, 52);
            this.textBox_listview_currentpage.Name = "textBox_listview_currentpage";
            this.textBox_listview_currentpage.ReadOnly = true;
            this.textBox_listview_currentpage.Size = new System.Drawing.Size(81, 25);
            this.textBox_listview_currentpage.TabIndex = 6;
            // 
            // button_next_page
            // 
            this.button_next_page.Location = new System.Drawing.Point(315, 41);
            this.button_next_page.Name = "button_next_page";
            this.button_next_page.Size = new System.Drawing.Size(98, 42);
            this.button_next_page.TabIndex = 5;
            this.button_next_page.Text = "Next Page";
            this.button_next_page.UseVisualStyleBackColor = true;
            this.button_next_page.Click += new System.EventHandler(this.button_next_page_Click);
            // 
            // button_pre_page
            // 
            this.button_pre_page.Location = new System.Drawing.Point(181, 41);
            this.button_pre_page.Name = "button_pre_page";
            this.button_pre_page.Size = new System.Drawing.Size(88, 42);
            this.button_pre_page.TabIndex = 4;
            this.button_pre_page.Text = "Pre Page";
            this.button_pre_page.UseVisualStyleBackColor = true;
            this.button_pre_page.Click += new System.EventHandler(this.button_pre_page_Click);
            // 
            // button_end_page
            // 
            this.button_end_page.Location = new System.Drawing.Point(940, 41);
            this.button_end_page.Name = "button_end_page";
            this.button_end_page.Size = new System.Drawing.Size(88, 42);
            this.button_end_page.TabIndex = 3;
            this.button_end_page.Text = "End Page";
            this.button_end_page.UseVisualStyleBackColor = true;
            this.button_end_page.Click += new System.EventHandler(this.button_end_page_Click);
            // 
            // button_top_page
            // 
            this.button_top_page.Location = new System.Drawing.Point(33, 41);
            this.button_top_page.Name = "button_top_page";
            this.button_top_page.Size = new System.Drawing.Size(88, 42);
            this.button_top_page.TabIndex = 2;
            this.button_top_page.Text = "Top Page";
            this.button_top_page.UseVisualStyleBackColor = true;
            this.button_top_page.Click += new System.EventHandler(this.button_top_page_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1401, 620);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_equipInfo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LogReader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_equipInfo.ResumeLayout(false);
            this.groupBox_equipInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ListView listView_log;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox_equipInfo;
        private System.Windows.Forms.Label label_SN_Value;
        private System.Windows.Forms.Label label_softwarVer_Value;
        private System.Windows.Forms.Label label_equipType_Value;
        private System.Windows.Forms.Label label_SN;
        private System.Windows.Forms.Label label_softwarVer;
        private System.Windows.Forms.Label label_equipType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_listview_jumpto;
        private System.Windows.Forms.TextBox textBox_jumpto;
        private System.Windows.Forms.TextBox textBox_listview_currentpage;
        private System.Windows.Forms.Button button_next_page;
        private System.Windows.Forms.Button button_pre_page;
        private System.Windows.Forms.Button button_end_page;
        private System.Windows.Forms.Button button_top_page;
    }
}

