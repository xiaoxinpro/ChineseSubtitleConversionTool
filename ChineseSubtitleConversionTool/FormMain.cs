using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    public partial class FormMain : Form
    {
        private ToolTip TipObject;
        private string OpenFileDefineExt = "";
        private string OpenFileDefineName = "";

        #region 初始化相关
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text += @" V" + Application.ProductVersion.ToString();

            InitFileListView(listViewFile);

            cbFormat.SelectedIndex = 0;

            TipObject = new ToolTip();
            TipObject.AutoPopDelay = 10000;    //工具提示保持可见的时间期限
            TipObject.InitialDelay = 200;     //鼠标放上，自动打开提示的时间
            TipObject.ReshowDelay = 1000;       //鼠标离开，自动关闭提示的时间
            TipObject.ShowAlways = true;     //总是显示，即便空间非活动
            TipObject.UseAnimation = true;   //动画效果
            TipObject.UseFading = true;      //淡入淡出效果
            TipObject.IsBalloon = true;      //气球状外观
            TipObject.SetToolTip(this.txtFileName, "替换符说明：{name}原文件名称，{exten}文件扩展名，{num}文件序号");
            TipObject.SetToolTip(this.chkChineseConvert, "如果不勾选可能在文本中出现的古文字转换后出现??\r\n如果勾选将大大降低转换速度\r\n请根据使用情况酌情勾选，全局有效！");
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        /// <param name="listView"></param>
        private void InitFileListView(ListView listView)
        {
            //基本属性设置
            listView.Clear();
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.View = View.Details;

            //创建列表头
            listView.Columns.Add("序号", 60, HorizontalAlignment.Center);
            listView.Columns.Add("文件名称", 100, HorizontalAlignment.Left);
            listView.Columns.Add("文件路径", 300, HorizontalAlignment.Left);

            //自动列宽
            listView.Columns[2].Width = -2;//根据标题设置宽度
        }

        #endregion

        #region 控件相关
        /// <summary>
        /// 获取拖拽信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 解析拖拽信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(path))
            {
                if(tabControlMain.SelectedIndex == 0)
                {
                    txtShow.Text = ReadFile(path);
                }
            }
            else if (Directory.Exists(path))
            {
                tabControlMain.SelectedIndex = 1;
                txtPath.Text = path.Trim();
                LoadDirectoryFile(txtPath.Text.Trim(), listViewFile);
                UpdataListViewFileName(listViewFile, txtFileName.Text.Trim());
            }
        }

        /// <summary>
        /// 转为简体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToSimplified_Click(object sender, EventArgs e)
        {
            TabPageControlEnable(tabPageCommon, false);
            string strText = txtShow.Text;
            bool useChineseConvert = chkChineseConvert.Checked;
            Task.Factory.StartNew(() =>
            {
                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                strText = StringToSimlified(strText, useChineseConvert);
                Invoke(new Action(() =>
                {
                    Watch.Stop();
                    txtShow.Text = strText;
                    TabPageControlEnable(tabPageCommon, true);
                }));
            });
        }

        /// <summary>
        /// 转为繁体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToTraditional_Click(object sender, EventArgs e)
        {
            TabPageControlEnable(tabPageCommon, false);
            string strText = txtShow.Text;
            bool useChineseConvert = chkChineseConvert.Checked;
            Task.Factory.StartNew(() =>
            {
                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                strText = StringToTraditional(strText, useChineseConvert);
                Invoke(new Action(() =>
                {
                    Watch.Stop();
                    txtShow.Text = strText;
                    TabPageControlEnable(tabPageCommon, true);
                }));
            });
        }

        /// <summary>
        /// 清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShow.Clear();
        }

        /// <summary>
        /// 保存文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtShow.Text.Trim() != "")
            {
                if(SaveFile(GetSaveFilePath(OpenFileDefineName, OpenFileDefineExt), txtShow.Text))
                {
                    MessageBox.Show("您的字幕文件已保存完毕。", "保存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Console.WriteLine("触发保存但没有保存成功。");
                }
            }
            else
            {
                MessageBox.Show("缓存数据为空。", "无法保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 浏览按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            string path = OpenFolder();
            if (Directory.Exists(path))
            {
                txtPath.Text = path;
                LoadDirectoryFile(txtPath.Text.Trim(), listViewFile);
                UpdataListViewFileName(listViewFile, txtFileName.Text.Trim());
            }
        }

        /// <summary>
        /// 清空列表按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearList_Click(object sender, EventArgs e)
        {
            listViewFile.Items.Clear();
            txtPath.Clear();
        }

        /// <summary>
        /// 文件名称风格改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (CheckFileStyle(textBox.Text, out string msg))
            {
                textBox.BackColor = Color.White;
                UpdataListViewFileName(listViewFile, textBox.Text);
            }
            else
            {
                textBox.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// 开始转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartConvert_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();
            string format = cbFormat.Text.Trim();
            string nameStyle = txtFileName.Text.Trim();
            bool useChineseConvert = chkChineseConvert.Checked;
            int fileLength = listViewFile.Items.Count;
            if (fileLength <= 0)
            {
                MessageBox.Show("无可转换的文件不存在，请先打开字幕文件夹。", "无法转换", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (CheckFileStyle(nameStyle, out string err) == false)
            {
                MessageBox.Show(err, "文件名样式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Dictionary<string, string> dicFile = new Dictionary<string, string>();
                foreach (ListViewItem item in listViewFile.Items)
                {
                    dicFile.Add(item.SubItems[1].Text, item.SubItems[2].Text);
                }
                pbConvert.Value = 0;
                pbConvert.Maximum = dicFile.Count;
                btnStartConvert.Hide();
                int cnt = 0;
                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                foreach (KeyValuePair<string,string> file in dicFile)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine(format + "\t" + MakeFileName(file.Value, nameStyle));
                        if (format == "转为简体")
                        {
                            SaveFile(MakeFileName(file.Value, nameStyle), StringToSimlified(ReadFile(file.Value), useChineseConvert));
                        }
                        else
                        {
                            SaveFile(MakeFileName(file.Value, nameStyle), StringToTraditional(ReadFile(file.Value), useChineseConvert));
                        }
                        this.Invoke(new Action(() =>
                        {
                            cnt = cnt + 1;
                            pbConvert.Value = cnt;
                            if (cnt >= fileLength)
                            {
                                Watch.Stop();
                                MessageBox.Show("转换完成，共输出" + pbConvert.Value + "个字幕文件，耗时" + string.Format("{0:0.###}", Watch.Elapsed.TotalSeconds)  + "秒。", "转换完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pbConvert.Value = 0;
                                btnStartConvert.Show();
                                listViewFile.Items.Clear();
                                txtPath.Clear();
                            }
                        }));
                    });
                }

            }
        }
        #endregion

        #region 列表相关
        /// <summary>
        /// 添加数据到列表
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="filePath"></param>
        private void AddFileListView(ListView listView, params FileInfo[] arrPath)
        {
            listView.BeginUpdate();
            foreach (FileInfo file in arrPath)
            {
                switch (file.Extension.ToLower())
                {
                    case ".ass":
                    case ".ssa":
                    case ".srt":
                    case ".lrc":
                    case ".txt":
                        try
                        {
                            ListViewItem listViewItem = listView.Items.Cast<ListViewItem>().First(x => x.SubItems[2].Text == file.FullName);
                        }
                        catch (Exception)
                        {
                            ListViewItem listViewItem = new ListViewItem();
                            listViewItem.Text = (listView.Items.Count + 1).ToString();
                            listViewItem.SubItems.Add("");
                            listViewItem.SubItems.Add(file.FullName);
                            listView.Items.Add(listViewItem);
                        }
                        break;
                    default:
                        break;
                }
            }
            listView.EndUpdate();
        }

        /// <summary>
        /// 加载文件夹中的文件到列表中
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listView"></param>
        public void LoadDirectoryFile(string path, ListView listView)
        {
            if (Directory.Exists(path))
            {
                listView.Items.Clear();
                DirectoryInfo folder = new DirectoryInfo(path);
                AddFileListView(listView, folder.GetFiles());
            }
        }

        /// <summary>
        /// 升级列表中的文件名
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="nameStyle"></param>
        public void UpdataListViewFileName(ListView listView, string nameStyle)
        {
            if (CheckFileStyle(nameStyle, out string msg)) 
            {
                listView.BeginUpdate();
                foreach (ListViewItem item in listView.Items)
                {
                    string filePath = item.SubItems[2].Text;
                    if (File.Exists(filePath))
                    {
                        item.SubItems[1].Text = Path.GetFileName(MakeFileName(filePath, nameStyle));
                    }
                }
                listView.EndUpdate();
            }
        }
        #endregion

        #region 转换相关
        /// <summary>
        /// 字符串转为简体中文
        /// </summary>
        /// <param name="str">简体中文字符串</param>
        /// <returns>繁体中文字符串</returns>
        public string StringToSimlified(string str, bool useChineseConverClass = true)
        {
            try
            {
                if (useChineseConverClass)
                {
                    return ChineseConvert.ToSimplified(str);
                }
                else
                {
                    return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
                }
            }
            catch (Exception)
            {
                return "";
            } 
        }

        /// <summary>
        /// 字符串转为繁体字
        /// </summary>
        /// <param name="str">简体中文字符串</param>
        /// <returns>繁体中文字符串</returns>
        public string StringToTraditional(string str, bool useChineseConverClass = true)
        {
            try
            {
                if (useChineseConverClass)
                {
                    return ChineseConvert.ToTraditional(str);
                }
                else
                {
                    return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// TabPage页面内的控件是否使能
        /// </summary>
        /// <param name="tabPage"></param>
        /// <param name="isEnable"></param>
        public void TabPageControlEnable(TabPage tabPage, bool isEnable = true)
        {
            foreach (Control item in tabPage.Controls)
            {
                if (item is Button)
                {
                    ((Button)item).Enabled = isEnable;
                }
                else if (item is TextBox)
                {
                    ((TextBox)item).Enabled = isEnable;
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)item).Enabled = isEnable;
                }
            }
        }

        #endregion

        #region 读写文件相关
        /// <summary>
        /// 检查文件名样式是否合法
        /// </summary>
        /// <param name="fileStyle">文件名样式</param>
        /// <param name="msg">输出错误</param>
        /// <returns>返回是否合法</returns>
        public bool CheckFileStyle(string fileStyle, out string msg)
        {
            msg = "";
            if (fileStyle.IndexOf("{name}") == -1)
            {
                msg = "文件名中必须包含{name}，请检查后修改再试。";
                return false;
            }
            if (fileStyle.IndexOf("{exten}") == -1)
            {
                msg = "文件名中必须包含{exten}，请检查后修改再试。";
                return false;
            }
            if (fileStyle.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                msg = "文件名中包含非法字符，请删除非法字符再试。";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 创建文件名称
        /// </summary>
        /// <param name="sourceName">源名称</param>
        /// <param name="styleName">目标名称样式</param>
        /// <returns></returns>
        public string MakeFileName(string sourceName, string styleName)
        {
            string path = Path.GetDirectoryName(sourceName) + "\\";
            string fileName = Path.GetFileNameWithoutExtension(sourceName);
            string fileExt = Path.GetExtension(sourceName);
            return path + styleName.Replace("{name}", fileName).Replace("{exten}", fileExt);
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="path">读取路径</param>
        /// <returns>返回文件内容</returns>
        public string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    OpenFileDefineExt = Path.GetExtension(path);
                    OpenFileDefineName = Path.GetFileNameWithoutExtension(path);
                    // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(path))
                    {
                        StringBuilder sbText = new StringBuilder();
                        // 从文件读取并显示行，直到文件的末尾 
                        while (!sr.EndOfStream)
                        {
                            sbText.AppendLine(sr.ReadLine());
                        }
                        return sbText.ToString();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    return err.Message;
                }
            }
            else
            {
                return "";
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
            folder.Description = "选择读取目录";  //定义在对话框上显示的文本
            if (folder.ShowDialog() == DialogResult.OK)
            {
                sPath = folder.SelectedPath;
            }
            return sPath;
        }

        /// <summary>
        /// 获取保存路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public string GetSaveFilePath(string fileName = "", string fileExt = "", string filePath = "")
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存字幕文件";
            sfd.FileName = fileName;
            sfd.DefaultExt = fileExt;
            sfd.InitialDirectory = filePath;
            sfd.Filter = "ASS文件 (*.ass)|*.ass|SSA文件 (*.ssa)|*.ssa|SRT文件 (*.srt)|*.srt|LRC文件 (*.lrc)|*.lrc|文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return "";
            }
            else
            {
                return sfd.FileName.Trim();
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path">保存完整路径</param>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public bool SaveFile(string path, string text)
        {
            if (path.Trim() == "")
            {
                return false;
            }
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path); //如果文件存在则删除文件
                }
                using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(text); // Encoding.Default.GetBytes(text);
                    fsWrite.Write(buffer, 0, buffer.Length);
                    return true;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show(err.Message, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

    }
}
