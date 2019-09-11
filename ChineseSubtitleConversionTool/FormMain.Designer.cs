namespace ChineseSubtitleConversionTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btnToSimplified = new System.Windows.Forms.Button();
            this.btnToTraditional = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.btnStartConvert = new System.Windows.Forms.Button();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.tabPageBatch = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.pbConvert = new System.Windows.Forms.ProgressBar();
            this.tabControlMain.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtShow
            // 
            this.txtShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShow.Location = new System.Drawing.Point(6, 35);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(534, 270);
            this.txtShow.TabIndex = 0;
            // 
            // btnToSimplified
            // 
            this.btnToSimplified.Location = new System.Drawing.Point(6, 6);
            this.btnToSimplified.Name = "btnToSimplified";
            this.btnToSimplified.Size = new System.Drawing.Size(75, 23);
            this.btnToSimplified.TabIndex = 1;
            this.btnToSimplified.Text = "转为简体";
            this.btnToSimplified.UseVisualStyleBackColor = true;
            this.btnToSimplified.Click += new System.EventHandler(this.btnToSimplified_Click);
            // 
            // btnToTraditional
            // 
            this.btnToTraditional.Location = new System.Drawing.Point(87, 6);
            this.btnToTraditional.Name = "btnToTraditional";
            this.btnToTraditional.Size = new System.Drawing.Size(75, 23);
            this.btnToTraditional.TabIndex = 1;
            this.btnToTraditional.Text = "转为繁体";
            this.btnToTraditional.UseVisualStyleBackColor = true;
            this.btnToTraditional.Click += new System.EventHandler(this.btnToTraditional_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(465, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(384, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "转为简体",
            "转为繁体"});
            this.cbFormat.Location = new System.Drawing.Point(48, 284);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(81, 20);
            this.cbFormat.TabIndex = 3;
            // 
            // btnStartConvert
            // 
            this.btnStartConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartConvert.Location = new System.Drawing.Point(458, 282);
            this.btnStartConvert.Name = "btnStartConvert";
            this.btnStartConvert.Size = new System.Drawing.Size(75, 23);
            this.btnStartConvert.TabIndex = 2;
            this.btnStartConvert.Text = "开始转换";
            this.btnStartConvert.UseVisualStyleBackColor = true;
            this.btnStartConvert.Click += new System.EventHandler(this.btnStartConvert_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPath.Location = new System.Drawing.Point(458, 6);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPath.TabIndex = 2;
            this.btnOpenPath.Text = "浏览";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(216, 284);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(236, 21);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "{name}.cs{exten}";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(48, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(404, 21);
            this.txtPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件名样式：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "格式：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目录：";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCommon);
            this.tabControlMain.Controls.Add(this.tabPageBatch);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(560, 337);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.btnToSimplified);
            this.tabPageCommon.Controls.Add(this.txtShow);
            this.tabPageCommon.Controls.Add(this.btnClear);
            this.tabPageCommon.Controls.Add(this.btnToTraditional);
            this.tabPageCommon.Controls.Add(this.btnSave);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(552, 311);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "普通转换";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // tabPageBatch
            // 
            this.tabPageBatch.Controls.Add(this.listView1);
            this.tabPageBatch.Controls.Add(this.cbFormat);
            this.tabPageBatch.Controls.Add(this.btnOpenPath);
            this.tabPageBatch.Controls.Add(this.btnStartConvert);
            this.tabPageBatch.Controls.Add(this.txtFileName);
            this.tabPageBatch.Controls.Add(this.txtPath);
            this.tabPageBatch.Controls.Add(this.label2);
            this.tabPageBatch.Controls.Add(this.label4);
            this.tabPageBatch.Controls.Add(this.label1);
            this.tabPageBatch.Controls.Add(this.label3);
            this.tabPageBatch.Controls.Add(this.pbConvert);
            this.tabPageBatch.Location = new System.Drawing.Point(4, 22);
            this.tabPageBatch.Name = "tabPageBatch";
            this.tabPageBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBatch.Size = new System.Drawing.Size(552, 311);
            this.tabPageBatch.TabIndex = 1;
            this.tabPageBatch.Text = "批量转换";
            this.tabPageBatch.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(48, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(485, 241);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "列表：";
            // 
            // pbConvert
            // 
            this.pbConvert.Location = new System.Drawing.Point(458, 282);
            this.pbConvert.Name = "pbConvert";
            this.pbConvert.Size = new System.Drawing.Size(75, 22);
            this.pbConvert.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "繁体简体字幕转换工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.tabPageBatch.ResumeLayout(false);
            this.tabPageBatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btnToSimplified;
        private System.Windows.Forms.Button btnToTraditional;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Button btnStartConvert;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageBatch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbConvert;
    }
}

