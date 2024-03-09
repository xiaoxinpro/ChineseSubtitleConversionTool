using OpenCCNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    public partial class FormMain : Form
    {
        #region 字符串常量
        private const string STR_OUTPUT_TO_SOURCE_FILE_DIRECTORY = "输出至源文件目录";
        private const string STR_CLEAR_LIST = "清空列表";
        private const string STR_SELECT_OUTPUT_DIRECTORY = "选择输出目录...";
        #endregion

        #region 全局属性
        public ConvertList MainConvertList { get; set; }
        #endregion

        #region 初始化
        public FormMain()
        {
            InitializeComponent();
            MainConvertList = new ConvertList();
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
            InitComboBoxFileOutput(ComboBoxFileOutput);
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
        /// 初始化输出文件夹下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxFileOutput(ComboBox comboBox, string[] paths = null)
        {
            comboBox.Items.Clear();
            if (paths != null && paths.Length > 0)
            {
                //在此添加文件夹列表
                foreach (string item in paths)
                {
                    comboBox.Items.Add(item);
                }
            }
            comboBox.Items.Add(STR_OUTPUT_TO_SOURCE_FILE_DIRECTORY);
            comboBox.Items.Add(STR_CLEAR_LIST);
            comboBox.Items.Add(STR_SELECT_OUTPUT_DIRECTORY);
            comboBox.SelectedIndex = 0;
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

        #region 基础转换功能
        /// <summary>
        /// 转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            TextBoxOutput.Clear();
            TextBoxOutput.Text = ChineseConverter.Convert(TextBoxInput.Text, EnumHelper.GetComboBoxSelected<EnumConverterModel>(ComboBoxMode), CheckBoxIdiomConvert.Checked);
            TextBoxOutput.SelectionStart = 0;
            TextBoxInput.SelectionStart = 0;
            TextBoxOutput.ScrollToCaret();
            TextBoxInput.ScrollToCaret();
        }
        #endregion

        #region 输出文件夹功能
        /// <summary>
        /// 输出文件夹下拉框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFileOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string path = comboBox.SelectedItem.ToString();
            Task.Run(() =>
            {
                Thread.Sleep(20);
                this.Invoke(new Action(() =>
                {
                    if (path == STR_SELECT_OUTPUT_DIRECTORY)
                    {
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        dialog.Description = "请选择输出文件夹";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedPath = dialog.SelectedPath;
                            if (string.IsNullOrEmpty(selectedPath))
                            {
                                comboBox.SelectedIndex = 0;
                            }
                            else
                            {
                                //添加到列表 selectedPath
                                InitComboBoxFileOutput(comboBox, new string[] { selectedPath });
                            }
                        }
                        else
                        {
                            comboBox.SelectedIndex = 0;
                        }
                    }
                    else if (path == STR_CLEAR_LIST)
                    {
                        DialogResult result = MessageBox.Show("是否要清除全部输出文件夹列表，清除后将无法恢复。", "清除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            InitComboBoxFileOutput(comboBox);
                        }
                        else
                        {
                            comboBox.SelectedIndex = 0;
                        }
                    }
                    else if (path == STR_OUTPUT_TO_SOURCE_FILE_DIRECTORY)
                    {
                        //忽略操作
                    }
                    else
                    {
                        //指定文件夹
                    }
                }));
            });
        }

        #endregion


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
