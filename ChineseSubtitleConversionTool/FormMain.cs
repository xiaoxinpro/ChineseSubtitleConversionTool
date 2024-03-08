using OpenCCNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    public partial class FormMain : Form
    {

        #region 初始化
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text += @" V" + Application.ProductVersion.ToString();

            #region 文本转换界面初始化
            InitComboBoxMode(ComboBoxMode);
            InitSyncTextBox(TextBoxInput, TextBoxOutput);
            #endregion

            #region 批量转换界面初始化
            InitComboBoxMode(ComboBoxFileMode);
            InitComboBoxFormat(ComboBoxFileFormart);
            InitListViewFile(ListViewFile);
            #endregion

            ZhConverter.Initialize();
        }

        /// <summary>
        /// 初始化同步滚动文本框
        /// </summary>
        /// <param name="syncedCtrls"></param>
        private void InitSyncTextBox(params Control[] syncedCtrls)
        {
            foreach (SyncTextBox ctr in syncedCtrls)
            {
                ctr.Buddies = syncedCtrls;
            }
        }

        /// <summary>
        /// 初始化转换模型下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxMode(ComboBox comboBox)
        {
            EnumHelper.InitComboBox(comboBox, EnumConverterModel.cht2chs);
        }

        /// <summary>
        /// 初始化输出文件编码下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxFormat(ComboBox comboBox)
        {
            EnumHelper.InitComboBox(comboBox, EnumConverterFileEncode.utf8);
        }

        /// <summary>
        /// 初始化文件列表
        /// </summary>
        /// <param name="listView"></param>
        private void InitListViewFile(ListView listView)
        {
            //基本属性设置
            listView.Clear();
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.View = View.Details;
            listView.CheckBoxes = false;
            listView.MultiSelect = false;

            //创建列表头
            listView.Columns.Add("ID", "序号", 45);
            listView.Columns.Add("Name", "文件名称", 160, HorizontalAlignment.Left, "");
            listView.Columns.Add("Type", "文件路径", -2, HorizontalAlignment.Left, "");
            
        }
        #endregion


        /// <summary>
        /// 转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            TextBoxOutput.Clear();
            TextBoxOutput.Text = ChineseConverter(TextBoxInput.Text, EnumHelper.GetComboBoxSelected<EnumConverterModel>(ComboBoxMode), CheckBoxIdiomConvert.Checked);
            TextBoxOutput.SelectionStart = 0;
            TextBoxInput.SelectionStart = 0;
            TextBoxOutput.ScrollToCaret();
            TextBoxInput.ScrollToCaret();
        }

        /// <summary>
        /// 中文转换函数
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="model">转换模型</param>
        /// <param name="idiom">是否使用常用词</param>
        /// <returns>转换后的结果</returns>
        private string ChineseConverter(string source, EnumConverterModel model, bool idiom = false)
        {
            string target;
            try
            {
                switch (model)
                {
                    case EnumConverterModel.cht2chs:
                        target = ZhConverter.HantToHans(source);
                        break;
                    case EnumConverterModel.cht2chtw:
                        target = ZhConverter.HantToTW(source, idiom);
                        break;
                    case EnumConverterModel.cht2chk:
                        target = ZhConverter.HantToHK(source);
                        break;
                    case EnumConverterModel.chtw2chs:
                        target = ZhConverter.TWToHans(source, idiom);
                        break;
                    case EnumConverterModel.chtw2chk:
                        target = ZhConverter.TWToHant(source, idiom);
                        break;
                    case EnumConverterModel.chk2chs:
                        target = ZhConverter.HKToHans(source);
                        break;
                    case EnumConverterModel.chk2cht:
                        target = ZhConverter.HKToHant(source);
                        break;
                    case EnumConverterModel.chs2cht:
                        target = ZhConverter.HansToHant(source);
                        break;
                    case EnumConverterModel.chs2chtw:
                        target = ZhConverter.HansToTW(source, idiom);
                        break;
                    case EnumConverterModel.chs2chk:
                        target = ZhConverter.HansToHK(source);
                        break;
                    default:
                        target = "无效的转换模型。";
                        break;
                }
            }
            catch (Exception err)
            {
                target = err.Message;
            }
            return target;
        }

    }

    /// <summary>
    /// 转换模式枚举
    /// </summary>
    public enum EnumConverterModel
    {
        [Description("繁体中文（标准）→ 简体中文（标准）")]
        cht2chs,
        [Description("繁体中文（标准）→ 繁体中文（台湾）")]
        cht2chtw,
        [Description("繁体中文（标准）→ 繁体中文（香港）")]
        cht2chk,
        [Description("繁体中文（台湾）→ 简体中文")]
        chtw2chs,
        [Description("繁体中文（台湾）→ 繁体中文（标准）")]
        chtw2chk,
        [Description("繁体中文（香港）→ 简体中文")]
        chk2chs,
        [Description("繁体中文（香港）→ 繁体中文（标准）")]
        chk2cht,
        [Description("简体中文 → 繁体中文（标准）")]
        chs2cht,
        [Description("简体中文 → 繁体中文（台湾）")]
        chs2chtw,
        [Description("简体中文 → 繁体中文（香港）")]
        chs2chk,
    }

    /// <summary>
    /// 转换输出文件编码格式
    /// </summary>
    public enum EnumConverterFileEncode
    {
        [Description("UTF-8")]
        utf8,
        [Description("UTF-16")]
        utf16,
        [Description("UTF-32")]
        utf32,
        [Description("ASCII")]
        ascii,
        [Description("Unicode")]
        unicode,
    }
}
