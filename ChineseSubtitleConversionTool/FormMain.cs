using OpenCCNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            listView.Columns.Add("Name", "文件编码", 80, HorizontalAlignment.Left, "");
            listView.Columns.Add("Type", "文件路径", -2, HorizontalAlignment.Left, "");

            listView.Items.Clear();
            
        }
        #endregion

        #region 文本转换功能
        /// <summary>
        /// 转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Enabled = false;
            TextBoxInput.Enabled = false;
            TextBoxOutput.Clear();
            TextBoxOutput.Text = ChineseConverter.Convert(TextBoxInput.Text, EnumHelper.GetComboBoxSelected<EnumConverterModel>(ComboBoxMode), CheckBoxIdiomConvert.Checked);
            TextBoxOutput.SelectionStart = 0;
            TextBoxInput.SelectionStart = 0;
            TextBoxOutput.ScrollToCaret();
            TextBoxInput.ScrollToCaret();
            TextBoxInput.Enabled = true;
            button.Enabled = true;
        }
        #endregion

        #region 转换列表功能

        /// <summary>
        /// 更新转换文件列表
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="convertList"></param>
        private void UpdateListViewFile(ListView listView, ConvertList convertList)
        {
            InitListViewFile(listView);
            if (convertList != null)
            {
                listView.BeginUpdate();
                for (int i = 0; i < convertList.Items.Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem((i + 1).ToString());
                    listViewItem.SubItems.Add(Path.GetFileName(convertList.Items[i].SourceFile));
                    listViewItem.SubItems.Add(convertList.Items[i].SourceFileEncoding.WebName.ToUpper());
                    listViewItem.SubItems.Add(convertList.Items[i].SourceFile);
                    listView.Items.Add(listViewItem);
                }
                listView.EndUpdate();
            }
        }

        /// <summary>
        /// 添加转换列表
        /// </summary>
        /// <param name="paths"></param>
        private void AddConvertList(params string[] paths)
        {
            foreach (string path in paths)
            {
                MainConvertList.Items.Add(new ConvertListItem(path));
            }
            UpdateListViewFile(ListViewFile, MainConvertList);
        }

        /// <summary>
        /// 删除转换列表元素
        /// </summary>
        /// <param name="index"></param>
        private void DeleteConvertList(int index)
        {
            if (index < MainConvertList.Items.Count)
            {
                MainConvertList.Items.RemoveAt(index);
            }
            UpdateListViewFile(ListViewFile, MainConvertList);
        }

        /// <summary>
        /// 清空转换列表
        /// </summary>
        private void ClearConvertList()
        {
            MainConvertList.Items.Clear();
            UpdateListViewFile(ListViewFile, MainConvertList);
        }
        #endregion

        #region 转换文件列表按钮事件

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <returns></returns>
        public string[] OpenFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "字幕文件|*.ass;*.ssa;*.srt;*.lrc;*.txt;*.yaml|所有文件|*.*";
            openFileDialog.Title = "添加文件";
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileNames;
            }
            return new string[] { };
        }

        /// <summary>
        /// 添加文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            string[] arrPath = OpenFiles();
            if (arrPath.Length > 0)
            {
                AddConvertList(arrPath);
            }
        }

        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <returns></returns>
        public string OpenFolder()
        {
            string sPath = "";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "添加文件夹";  //定义在对话框上显示的文本
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            folder.ShowNewFolderButton = false;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                sPath = folder.SelectedPath;
            }
            return sPath;
        }

        /// <summary>
        /// 添加文件夹按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddFiles_Click(object sender, EventArgs e)
        {
            string sPath = OpenFolder();
            if (string.IsNullOrEmpty(sPath))
            {
                return;
            }
            if (Directory.Exists(sPath))
            {
                List<string> fileList = new List<string>();
                DirectoryInfo folder = new DirectoryInfo(sPath);
                foreach (FileInfo itemFile in folder.GetFiles())
                {
                    fileList.Add(itemFile.FullName);
                }
                AddConvertList(fileList.ToArray());
            }
        }

        /// <summary>
        /// 删除文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteFile_Click(object sender, EventArgs e)
        {
            if (ListViewFile.SelectedIndices.Count > 0)
            {
                int index = ListViewFile.SelectedIndices[0];
                DeleteConvertList(index);
                if (ListViewFile.Items.Count > 0)
                {
                    if (index < ListViewFile.Items.Count)
                    {
                        ListViewFile.Items[index].Selected = true;
                        ListViewFile.EnsureVisible(index);
                    }
                    else
                    {
                        ListViewFile.Items[ListViewFile.Items.Count - 1].Selected = true;
                        ListViewFile.EnsureVisible(ListViewFile.Items.Count - 1);
                    }
                    ListViewFile.Focus();
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的文件。", "未选中文件", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 清空文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClearList_Click(object sender, EventArgs e)
        {
            ClearConvertList();
        }

        /// <summary>
        /// 双击文件列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            ListView listView =  sender as ListView;
            if (listView.SelectedIndices.Count == 1)
            {
                int index = listView.SelectedIndices[0];
                TextBoxOutput.Clear();
                TextBoxInput.Text = "加载中...";
                TextBoxInput.Enabled = false;
                ButtonConverter.Enabled = false;
                TabControlMain.SelectedIndex = 0;
                ComboBoxMode.DroppedDown = true;
                Task.Run(() =>
                {
                    string content;
                    ConvertListItem item = MainConvertList.Items[index];
                    Thread.Sleep(100);
                    using (StreamReader sr = new StreamReader(item.SourceFile, item.SourceFileEncoding))
                    {
                        content = sr.ReadToEnd();
                    }
                    this.Invoke(new Action(() =>
                    {
                        TextBoxInput.Text = content;
                        TextBoxInput.Enabled = true;
                        ButtonConverter.Enabled = true;
                    }));
                });
            }
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

        /// <summary>
        /// 打开输出文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenFileOutput_Click(object sender, EventArgs e)
        {
            string path = GetFileOutputDriectory();
            if (path == null)
            {
                MessageBox.Show("没有找到输入文件，请先添加文件。", "打开输出文件夹", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Directory.Exists(path))
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            else if (File.Exists(path))
            {
                System.Diagnostics.Process.Start("Explorer.exe", "/select," + path);
            }
        }

        /// <summary>
        /// 获取输出文件夹
        /// </summary>
        /// <param name="index">指定索引，-1表示根据UI选择索引</param>
        /// <returns>返回路径，null表示无对应输入文件</returns>
        private string GetFileOutputDriectory(int index = -1)
        {
            string path = ComboBoxFileOutput.SelectedItem.ToString();
            if (path == STR_OUTPUT_TO_SOURCE_FILE_DIRECTORY)
            {
                if (ListViewFile.Items.Count > 0 && MainConvertList.Items.Count > 0)
                {
                    if (index >= 0 && index < MainConvertList.Items.Count)
                    {
                        path = MainConvertList.Items[index].SourceFile;
                    }
                    else if (ListViewFile.SelectedIndices.Count > 0)
                    {
                        path = MainConvertList.Items[ListViewFile.SelectedIndices[0]].SourceFile;
                    }
                    else
                    {
                        path = MainConvertList.Items[0].SourceFile;
                    }
                    path = Path.GetDirectoryName(path);
                }
                else
                {
                    return null;
                }
            }
            return path;
        }
        #endregion

        #region 文件转换功能
        /// <summary>
        /// 转换按钮（文件/批量）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFileConverter_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string outPath = ComboBoxFileOutput.SelectedItem.ToString();
            if (string.IsNullOrEmpty(outPath) || outPath == STR_OUTPUT_TO_SOURCE_FILE_DIRECTORY)
            {
                outPath = null;
            }
            button.Enabled = false;
            long cnt = MainConvertList.ConvertOutputAll(EnumHelper.GetComboBoxSelected<EnumConverterModel>(ComboBoxFileMode), CheckBoxFileIdiomConvert.Checked, Encoding.GetEncoding(EnumHelper.GetDescriptionByEnum(EnumHelper.GetComboBoxSelected<EnumConverterFileEncode>(ComboBoxFileFormart))), outPath, TextBoxFileSuffix.Text);
            button.Enabled = true;
            MessageBox.Show("转换完成，共转换" + cnt.ToString() + "个段落。", "转换完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


    }

}
