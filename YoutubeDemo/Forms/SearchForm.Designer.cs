namespace YoutubeDemo
{
    partial class SearchForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.videoCardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.search = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加至撥放清單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(842, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜尋";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // videoCardContainer
            // 
            this.videoCardContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoCardContainer.AutoScroll = true;
            this.videoCardContainer.Location = new System.Drawing.Point(53, 94);
            this.videoCardContainer.Name = "videoCardContainer";
            this.videoCardContainer.Size = new System.Drawing.Size(1160, 494);
            this.videoCardContainer.TabIndex = 1;
            this.videoCardContainer.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(226, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(341, 22);
            this.search.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(664, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(43, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "全部";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.CategoryChange);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(162, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "音樂";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.CategoryChange);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(291, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "運動";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.CategoryChange);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(458, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "3";
            this.radioButton4.Text = "遊戲";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.CategoryChange);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(615, 19);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(83, 16);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.TabStop = true;
            this.radioButton5.Tag = "4";
            this.radioButton5.Text = "新聞與政治";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.CategoryChange);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(85, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 49);
            this.panel1.TabIndex = 8;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(53, 622);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1114, 78);
            this.elementHost1.TabIndex = 9;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "登出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加至撥放清單ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(159, 26);
            // 
            // 添加至撥放清單ToolStripMenuItem
            // 
            this.添加至撥放清單ToolStripMenuItem.Name = "添加至撥放清單ToolStripMenuItem";
            this.添加至撥放清單ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.添加至撥放清單ToolStripMenuItem.Text = "添加至撥放清單";
            this.添加至撥放清單ToolStripMenuItem.DropDownOpening += new System.EventHandler(this.addToPlaylistMenuItem_DropDownOpening);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1013, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 50);
            this.button3.TabIndex = 11;
            this.button3.Text = "播放清單";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1124, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 48);
            this.button4.TabIndex = 12;
            this.button4.Text = "上傳影片";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 728);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.videoCardContainer);
            this.Controls.Add(this.button1);
            this.Name = "SearchForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel videoCardContainer;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 添加至撥放清單ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

