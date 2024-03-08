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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageText = new System.Windows.Forms.TabPage();
            this.GroupBoxTextConfig = new System.Windows.Forms.GroupBox();
            this.CheckBoxIdiomConvert = new System.Windows.Forms.CheckBox();
            this.ButtonConverter = new System.Windows.Forms.Button();
            this.ComboBoxMode = new System.Windows.Forms.ComboBox();
            this.SplitContainerText = new System.Windows.Forms.SplitContainer();
            this.TabPageFile = new System.Windows.Forms.TabPage();
            this.GroupBoxFlieList = new System.Windows.Forms.GroupBox();
            this.TextBoxFileSuffix = new System.Windows.Forms.TextBox();
            this.ComboBoxFileFormart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxFileOutput = new System.Windows.Forms.ComboBox();
            this.ButtonDeleteFile = new System.Windows.Forms.Button();
            this.ButtonClearList = new System.Windows.Forms.Button();
            this.ButtonOpenFileOutput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListViewFile = new System.Windows.Forms.ListView();
            this.ButtonAddFiles = new System.Windows.Forms.Button();
            this.ButtonAddFile = new System.Windows.Forms.Button();
            this.GroupBoxFileConfig = new System.Windows.Forms.GroupBox();
            this.CheckBoxFileIdiomConvert = new System.Windows.Forms.CheckBox();
            this.ButtonFileConverter = new System.Windows.Forms.Button();
            this.ComboBoxFileMode = new System.Windows.Forms.ComboBox();
            this.TextBoxInput = new ChineseSubtitleConversionTool.SyncTextBox();
            this.TextBoxOutput = new ChineseSubtitleConversionTool.SyncTextBox();
            this.TabControlMain.SuspendLayout();
            this.TabPageText.SuspendLayout();
            this.GroupBoxTextConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerText)).BeginInit();
            this.SplitContainerText.Panel1.SuspendLayout();
            this.SplitContainerText.Panel2.SuspendLayout();
            this.SplitContainerText.SuspendLayout();
            this.TabPageFile.SuspendLayout();
            this.GroupBoxFlieList.SuspendLayout();
            this.GroupBoxFileConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Controls.Add(this.TabPageText);
            this.TabControlMain.Controls.Add(this.TabPageFile);
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(0, 0);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(784, 461);
            this.TabControlMain.TabIndex = 0;
            // 
            // TabPageText
            // 
            this.TabPageText.Controls.Add(this.GroupBoxTextConfig);
            this.TabPageText.Controls.Add(this.SplitContainerText);
            this.TabPageText.Location = new System.Drawing.Point(4, 22);
            this.TabPageText.Name = "TabPageText";
            this.TabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageText.Size = new System.Drawing.Size(776, 435);
            this.TabPageText.TabIndex = 0;
            this.TabPageText.Text = "文本转换";
            this.TabPageText.UseVisualStyleBackColor = true;
            // 
            // GroupBoxTextConfig
            // 
            this.GroupBoxTextConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxTextConfig.Controls.Add(this.CheckBoxIdiomConvert);
            this.GroupBoxTextConfig.Controls.Add(this.ButtonConverter);
            this.GroupBoxTextConfig.Controls.Add(this.ComboBoxMode);
            this.GroupBoxTextConfig.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxTextConfig.Name = "GroupBoxTextConfig";
            this.GroupBoxTextConfig.Size = new System.Drawing.Size(764, 54);
            this.GroupBoxTextConfig.TabIndex = 1;
            this.GroupBoxTextConfig.TabStop = false;
            this.GroupBoxTextConfig.Text = "转换选项";
            // 
            // CheckBoxIdiomConvert
            // 
            this.CheckBoxIdiomConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxIdiomConvert.AutoSize = true;
            this.CheckBoxIdiomConvert.Checked = true;
            this.CheckBoxIdiomConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxIdiomConvert.Location = new System.Drawing.Point(596, 22);
            this.CheckBoxIdiomConvert.Name = "CheckBoxIdiomConvert";
            this.CheckBoxIdiomConvert.Size = new System.Drawing.Size(72, 16);
            this.CheckBoxIdiomConvert.TabIndex = 6;
            this.CheckBoxIdiomConvert.Text = "常用词汇";
            this.CheckBoxIdiomConvert.UseVisualStyleBackColor = true;
            // 
            // ButtonConverter
            // 
            this.ButtonConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConverter.Location = new System.Drawing.Point(674, 18);
            this.ButtonConverter.Name = "ButtonConverter";
            this.ButtonConverter.Size = new System.Drawing.Size(73, 23);
            this.ButtonConverter.TabIndex = 5;
            this.ButtonConverter.Text = "转换";
            this.ButtonConverter.UseVisualStyleBackColor = true;
            this.ButtonConverter.Click += new System.EventHandler(this.ButtonConverter_Click);
            // 
            // ComboBoxMode
            // 
            this.ComboBoxMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMode.FormattingEnabled = true;
            this.ComboBoxMode.Location = new System.Drawing.Point(15, 20);
            this.ComboBoxMode.Name = "ComboBoxMode";
            this.ComboBoxMode.Size = new System.Drawing.Size(575, 20);
            this.ComboBoxMode.TabIndex = 4;
            // 
            // SplitContainerText
            // 
            this.SplitContainerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainerText.Location = new System.Drawing.Point(8, 66);
            this.SplitContainerText.Name = "SplitContainerText";
            // 
            // SplitContainerText.Panel1
            // 
            this.SplitContainerText.Panel1.Controls.Add(this.TextBoxInput);
            // 
            // SplitContainerText.Panel2
            // 
            this.SplitContainerText.Panel2.Controls.Add(this.TextBoxOutput);
            this.SplitContainerText.Size = new System.Drawing.Size(760, 366);
            this.SplitContainerText.SplitterDistance = 380;
            this.SplitContainerText.TabIndex = 0;
            // 
            // TabPageFile
            // 
            this.TabPageFile.Controls.Add(this.GroupBoxFlieList);
            this.TabPageFile.Controls.Add(this.GroupBoxFileConfig);
            this.TabPageFile.Location = new System.Drawing.Point(4, 22);
            this.TabPageFile.Name = "TabPageFile";
            this.TabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFile.Size = new System.Drawing.Size(776, 435);
            this.TabPageFile.TabIndex = 1;
            this.TabPageFile.Text = "批量转换";
            this.TabPageFile.UseVisualStyleBackColor = true;
            // 
            // GroupBoxFlieList
            // 
            this.GroupBoxFlieList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxFlieList.Controls.Add(this.TextBoxFileSuffix);
            this.GroupBoxFlieList.Controls.Add(this.ComboBoxFileFormart);
            this.GroupBoxFlieList.Controls.Add(this.label3);
            this.GroupBoxFlieList.Controls.Add(this.label2);
            this.GroupBoxFlieList.Controls.Add(this.ComboBoxFileOutput);
            this.GroupBoxFlieList.Controls.Add(this.ButtonDeleteFile);
            this.GroupBoxFlieList.Controls.Add(this.ButtonClearList);
            this.GroupBoxFlieList.Controls.Add(this.ButtonOpenFileOutput);
            this.GroupBoxFlieList.Controls.Add(this.label1);
            this.GroupBoxFlieList.Controls.Add(this.ListViewFile);
            this.GroupBoxFlieList.Controls.Add(this.ButtonAddFiles);
            this.GroupBoxFlieList.Controls.Add(this.ButtonAddFile);
            this.GroupBoxFlieList.Location = new System.Drawing.Point(6, 66);
            this.GroupBoxFlieList.Name = "GroupBoxFlieList";
            this.GroupBoxFlieList.Size = new System.Drawing.Size(764, 363);
            this.GroupBoxFlieList.TabIndex = 3;
            this.GroupBoxFlieList.TabStop = false;
            this.GroupBoxFlieList.Text = "转换列表";
            // 
            // TextBoxFileSuffix
            // 
            this.TextBoxFileSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxFileSuffix.Location = new System.Drawing.Point(71, 336);
            this.TextBoxFileSuffix.Name = "TextBoxFileSuffix";
            this.TextBoxFileSuffix.Size = new System.Drawing.Size(74, 21);
            this.TextBoxFileSuffix.TabIndex = 10;
            this.TextBoxFileSuffix.Text = ".chs";
            // 
            // ComboBoxFileFormart
            // 
            this.ComboBoxFileFormart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxFileFormart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFileFormart.FormattingEnabled = true;
            this.ComboBoxFileFormart.Location = new System.Drawing.Point(210, 337);
            this.ComboBoxFileFormart.Name = "ComboBoxFileFormart";
            this.ComboBoxFileFormart.Size = new System.Drawing.Size(77, 20);
            this.ComboBoxFileFormart.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(13, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "输出后缀：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(151, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "输出格式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxFileOutput
            // 
            this.ComboBoxFileOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxFileOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFileOutput.FormattingEnabled = true;
            this.ComboBoxFileOutput.Items.AddRange(new object[] {
            "输出至源文件目录",
            "清空列表",
            "选择输出目录..."});
            this.ComboBoxFileOutput.Location = new System.Drawing.Point(365, 337);
            this.ComboBoxFileOutput.Name = "ComboBoxFileOutput";
            this.ComboBoxFileOutput.Size = new System.Drawing.Size(319, 20);
            this.ComboBoxFileOutput.TabIndex = 7;
            // 
            // ButtonDeleteFile
            // 
            this.ButtonDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteFile.Location = new System.Drawing.Point(627, 20);
            this.ButtonDeleteFile.Name = "ButtonDeleteFile";
            this.ButtonDeleteFile.Size = new System.Drawing.Size(57, 23);
            this.ButtonDeleteFile.TabIndex = 6;
            this.ButtonDeleteFile.Text = "删除";
            this.ButtonDeleteFile.UseVisualStyleBackColor = true;
            // 
            // ButtonClearList
            // 
            this.ButtonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClearList.Location = new System.Drawing.Point(690, 20);
            this.ButtonClearList.Name = "ButtonClearList";
            this.ButtonClearList.Size = new System.Drawing.Size(57, 23);
            this.ButtonClearList.TabIndex = 6;
            this.ButtonClearList.Text = "清空";
            this.ButtonClearList.UseVisualStyleBackColor = true;
            // 
            // ButtonOpenFileOutput
            // 
            this.ButtonOpenFileOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOpenFileOutput.Location = new System.Drawing.Point(690, 335);
            this.ButtonOpenFileOutput.Name = "ButtonOpenFileOutput";
            this.ButtonOpenFileOutput.Size = new System.Drawing.Size(57, 23);
            this.ButtonOpenFileOutput.TabIndex = 6;
            this.ButtonOpenFileOutput.Text = "打开";
            this.ButtonOpenFileOutput.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(293, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "输出文件夹：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListViewFile
            // 
            this.ListViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewFile.HideSelection = false;
            this.ListViewFile.Location = new System.Drawing.Point(6, 49);
            this.ListViewFile.Name = "ListViewFile";
            this.ListViewFile.Size = new System.Drawing.Size(752, 282);
            this.ListViewFile.TabIndex = 1;
            this.ListViewFile.UseCompatibleStateImageBehavior = false;
            // 
            // ButtonAddFiles
            // 
            this.ButtonAddFiles.Location = new System.Drawing.Point(94, 20);
            this.ButtonAddFiles.Name = "ButtonAddFiles";
            this.ButtonAddFiles.Size = new System.Drawing.Size(92, 23);
            this.ButtonAddFiles.TabIndex = 0;
            this.ButtonAddFiles.Text = "添加文件夹";
            this.ButtonAddFiles.UseVisualStyleBackColor = true;
            // 
            // ButtonAddFile
            // 
            this.ButtonAddFile.Location = new System.Drawing.Point(15, 20);
            this.ButtonAddFile.Name = "ButtonAddFile";
            this.ButtonAddFile.Size = new System.Drawing.Size(73, 23);
            this.ButtonAddFile.TabIndex = 0;
            this.ButtonAddFile.Text = "添加文件";
            this.ButtonAddFile.UseVisualStyleBackColor = true;
            // 
            // GroupBoxFileConfig
            // 
            this.GroupBoxFileConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxFileConfig.Controls.Add(this.CheckBoxFileIdiomConvert);
            this.GroupBoxFileConfig.Controls.Add(this.ButtonFileConverter);
            this.GroupBoxFileConfig.Controls.Add(this.ComboBoxFileMode);
            this.GroupBoxFileConfig.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxFileConfig.Name = "GroupBoxFileConfig";
            this.GroupBoxFileConfig.Size = new System.Drawing.Size(764, 54);
            this.GroupBoxFileConfig.TabIndex = 2;
            this.GroupBoxFileConfig.TabStop = false;
            this.GroupBoxFileConfig.Text = "转换选项";
            // 
            // CheckBoxFileIdiomConvert
            // 
            this.CheckBoxFileIdiomConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxFileIdiomConvert.AutoSize = true;
            this.CheckBoxFileIdiomConvert.Checked = true;
            this.CheckBoxFileIdiomConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxFileIdiomConvert.Location = new System.Drawing.Point(596, 22);
            this.CheckBoxFileIdiomConvert.Name = "CheckBoxFileIdiomConvert";
            this.CheckBoxFileIdiomConvert.Size = new System.Drawing.Size(72, 16);
            this.CheckBoxFileIdiomConvert.TabIndex = 6;
            this.CheckBoxFileIdiomConvert.Text = "常用词汇";
            this.CheckBoxFileIdiomConvert.UseVisualStyleBackColor = true;
            // 
            // ButtonFileConverter
            // 
            this.ButtonFileConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFileConverter.Location = new System.Drawing.Point(674, 18);
            this.ButtonFileConverter.Name = "ButtonFileConverter";
            this.ButtonFileConverter.Size = new System.Drawing.Size(73, 23);
            this.ButtonFileConverter.TabIndex = 5;
            this.ButtonFileConverter.Text = "转换";
            this.ButtonFileConverter.UseVisualStyleBackColor = true;
            // 
            // ComboBoxFileMode
            // 
            this.ComboBoxFileMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxFileMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFileMode.FormattingEnabled = true;
            this.ComboBoxFileMode.Location = new System.Drawing.Point(15, 20);
            this.ComboBoxFileMode.Name = "ComboBoxFileMode";
            this.ComboBoxFileMode.Size = new System.Drawing.Size(575, 20);
            this.ComboBoxFileMode.TabIndex = 4;
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Buddies = null;
            this.TextBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxInput.Location = new System.Drawing.Point(0, 0);
            this.TextBoxInput.MaxLength = 0;
            this.TextBoxInput.Multiline = true;
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxInput.Size = new System.Drawing.Size(380, 366);
            this.TextBoxInput.TabIndex = 1;
            this.TextBoxInput.Text = resources.GetString("TextBoxInput.Text");
            this.TextBoxInput.WordWrap = false;
            // 
            // TextBoxOutput
            // 
            this.TextBoxOutput.Buddies = null;
            this.TextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.TextBoxOutput.MaxLength = 0;
            this.TextBoxOutput.Multiline = true;
            this.TextBoxOutput.Name = "TextBoxOutput";
            this.TextBoxOutput.ReadOnly = true;
            this.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxOutput.Size = new System.Drawing.Size(376, 366);
            this.TextBoxOutput.TabIndex = 2;
            this.TextBoxOutput.WordWrap = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TabControlMain);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "繁体简体字幕转换工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageText.ResumeLayout(false);
            this.GroupBoxTextConfig.ResumeLayout(false);
            this.GroupBoxTextConfig.PerformLayout();
            this.SplitContainerText.Panel1.ResumeLayout(false);
            this.SplitContainerText.Panel1.PerformLayout();
            this.SplitContainerText.Panel2.ResumeLayout(false);
            this.SplitContainerText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerText)).EndInit();
            this.SplitContainerText.ResumeLayout(false);
            this.TabPageFile.ResumeLayout(false);
            this.GroupBoxFlieList.ResumeLayout(false);
            this.GroupBoxFlieList.PerformLayout();
            this.GroupBoxFileConfig.ResumeLayout(false);
            this.GroupBoxFileConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageText;
        private System.Windows.Forms.SplitContainer SplitContainerText;
        private System.Windows.Forms.TabPage TabPageFile;
        private System.Windows.Forms.GroupBox GroupBoxTextConfig;
        private System.Windows.Forms.CheckBox CheckBoxIdiomConvert;
        private System.Windows.Forms.Button ButtonConverter;
        private System.Windows.Forms.ComboBox ComboBoxMode;
        private SyncTextBox TextBoxInput;
        private SyncTextBox TextBoxOutput;
        private System.Windows.Forms.GroupBox GroupBoxFlieList;
        private System.Windows.Forms.ListView ListViewFile;
        private System.Windows.Forms.Button ButtonAddFiles;
        private System.Windows.Forms.Button ButtonAddFile;
        private System.Windows.Forms.GroupBox GroupBoxFileConfig;
        private System.Windows.Forms.CheckBox CheckBoxFileIdiomConvert;
        private System.Windows.Forms.Button ButtonFileConverter;
        private System.Windows.Forms.ComboBox ComboBoxFileMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOpenFileOutput;
        private System.Windows.Forms.ComboBox ComboBoxFileOutput;
        private System.Windows.Forms.ComboBox ComboBoxFileFormart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonDeleteFile;
        private System.Windows.Forms.Button ButtonClearList;
        private System.Windows.Forms.TextBox TextBoxFileSuffix;
        private System.Windows.Forms.Label label3;
    }
}

