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
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageText = new System.Windows.Forms.TabPage();
            this.TabPageFile = new System.Windows.Forms.TabPage();
            this.SplitContainerText = new System.Windows.Forms.SplitContainer();
            this.GroupBoxTextConfig = new System.Windows.Forms.GroupBox();
            this.RichTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.RichTextBoxTarget = new System.Windows.Forms.RichTextBox();
            this.CheckBoxIdiomConvert = new System.Windows.Forms.CheckBox();
            this.ButtonConverter = new System.Windows.Forms.Button();
            this.ComboBoxMode = new System.Windows.Forms.ComboBox();
            this.TabControlMain.SuspendLayout();
            this.TabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerText)).BeginInit();
            this.SplitContainerText.Panel1.SuspendLayout();
            this.SplitContainerText.Panel2.SuspendLayout();
            this.SplitContainerText.SuspendLayout();
            this.GroupBoxTextConfig.SuspendLayout();
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
            this.TabControlMain.Size = new System.Drawing.Size(464, 361);
            this.TabControlMain.TabIndex = 0;
            // 
            // TabPageText
            // 
            this.TabPageText.Controls.Add(this.GroupBoxTextConfig);
            this.TabPageText.Controls.Add(this.SplitContainerText);
            this.TabPageText.Location = new System.Drawing.Point(4, 22);
            this.TabPageText.Name = "TabPageText";
            this.TabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageText.Size = new System.Drawing.Size(456, 335);
            this.TabPageText.TabIndex = 0;
            this.TabPageText.Text = "文本转换";
            this.TabPageText.UseVisualStyleBackColor = true;
            // 
            // TabPageFile
            // 
            this.TabPageFile.Location = new System.Drawing.Point(4, 22);
            this.TabPageFile.Name = "TabPageFile";
            this.TabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFile.Size = new System.Drawing.Size(456, 335);
            this.TabPageFile.TabIndex = 1;
            this.TabPageFile.Text = "文件转换";
            this.TabPageFile.UseVisualStyleBackColor = true;
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
            this.SplitContainerText.Panel1.Controls.Add(this.RichTextBoxSource);
            // 
            // SplitContainerText.Panel2
            // 
            this.SplitContainerText.Panel2.Controls.Add(this.RichTextBoxTarget);
            this.SplitContainerText.Size = new System.Drawing.Size(440, 266);
            this.SplitContainerText.SplitterDistance = 220;
            this.SplitContainerText.TabIndex = 0;
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
            this.GroupBoxTextConfig.Size = new System.Drawing.Size(444, 54);
            this.GroupBoxTextConfig.TabIndex = 1;
            this.GroupBoxTextConfig.TabStop = false;
            this.GroupBoxTextConfig.Text = "转换选项";
            // 
            // RichTextBoxSource
            // 
            this.RichTextBoxSource.DetectUrls = false;
            this.RichTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxSource.Location = new System.Drawing.Point(0, 0);
            this.RichTextBoxSource.MaxLength = 0;
            this.RichTextBoxSource.Name = "RichTextBoxSource";
            this.RichTextBoxSource.Size = new System.Drawing.Size(220, 266);
            this.RichTextBoxSource.TabIndex = 0;
            this.RichTextBoxSource.Text = "";
            // 
            // RichTextBoxTarget
            // 
            this.RichTextBoxTarget.DetectUrls = false;
            this.RichTextBoxTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxTarget.Location = new System.Drawing.Point(0, 0);
            this.RichTextBoxTarget.MaxLength = 0;
            this.RichTextBoxTarget.Name = "RichTextBoxTarget";
            this.RichTextBoxTarget.ReadOnly = true;
            this.RichTextBoxTarget.Size = new System.Drawing.Size(216, 266);
            this.RichTextBoxTarget.TabIndex = 0;
            this.RichTextBoxTarget.Text = "";
            // 
            // CheckBoxIdiomConvert
            // 
            this.CheckBoxIdiomConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxIdiomConvert.AutoSize = true;
            this.CheckBoxIdiomConvert.Location = new System.Drawing.Point(276, 22);
            this.CheckBoxIdiomConvert.Name = "CheckBoxIdiomConvert";
            this.CheckBoxIdiomConvert.Size = new System.Drawing.Size(72, 16);
            this.CheckBoxIdiomConvert.TabIndex = 6;
            this.CheckBoxIdiomConvert.Text = "常用词汇";
            this.CheckBoxIdiomConvert.UseVisualStyleBackColor = true;
            // 
            // ButtonConverter
            // 
            this.ButtonConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConverter.Location = new System.Drawing.Point(354, 18);
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
            this.ComboBoxMode.Size = new System.Drawing.Size(255, 20);
            this.ComboBoxMode.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.TabControlMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "繁体简体字幕转换工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageText.ResumeLayout(false);
            this.SplitContainerText.Panel1.ResumeLayout(false);
            this.SplitContainerText.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerText)).EndInit();
            this.SplitContainerText.ResumeLayout(false);
            this.GroupBoxTextConfig.ResumeLayout(false);
            this.GroupBoxTextConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageText;
        private System.Windows.Forms.SplitContainer SplitContainerText;
        private System.Windows.Forms.TabPage TabPageFile;
        private System.Windows.Forms.GroupBox GroupBoxTextConfig;
        private System.Windows.Forms.RichTextBox RichTextBoxSource;
        private System.Windows.Forms.RichTextBox RichTextBoxTarget;
        private System.Windows.Forms.CheckBox CheckBoxIdiomConvert;
        private System.Windows.Forms.Button ButtonConverter;
        private System.Windows.Forms.ComboBox ComboBoxMode;
    }
}

