using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    public partial class FormMain : Form
    {
        private ToolTip TipObject;
        private string OpenFileDefineExt = "";
        private string OpenFileDefineName = "";

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
            cbFormat.SelectedIndex = 0;

            TipObject = new ToolTip();
            TipObject.AutoPopDelay = 5000;    //工具提示保持可见的时间期限
            TipObject.InitialDelay = 200;     //鼠标放上，自动打开提示的时间
            TipObject.ReshowDelay = 1000;       //鼠标离开，自动关闭提示的时间
            TipObject.ShowAlways = true;     //总是显示，即便空间非活动
            TipObject.UseAnimation = true;   //动画效果
            TipObject.UseFading = true;      //淡入淡出效果
            TipObject.IsBalloon = true;      //气球状外观
            TipObject.SetToolTip(this.txtFileName, "替换符说明：{name}原文件名称，{exten}文件扩展名，{num}文件序号");
        }

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
                        txtShow.Text = sbText.ToString();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            else if (Directory.Exists(path))
            {
                txtPath.Text = path.Trim();
            }
        }

        /// <summary>
        /// 转为简体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToSimplified_Click(object sender, EventArgs e)
        {
            txtShow.Text = StringToSimlified(txtShow.Text);
        }

        /// <summary>
        /// 转为繁体按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToTraditional_Click(object sender, EventArgs e)
        {
            txtShow.Text = StringToTraditional(txtShow.Text);
        }

        /// <summary>
        /// 字符串转为简体中文
        /// </summary>
        /// <param name="str">简体中文字符串</param>
        /// <returns>繁体中文字符串</returns>
        public string StringToSimlified(string str)
        {
            try
            {
                return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
            }
            catch (Exception)
            {
                return "";
            } 
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
                if(SaveFile(txtShow.Text))
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
            }
        }

        /// <summary>
        /// 开始转换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartConvert_Click(object sender, EventArgs e)
        {

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
        /// 保存文件
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool SaveFile(string text)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存字幕文件";
            sfd.DefaultExt = OpenFileDefineExt;
            sfd.FileName = OpenFileDefineName;
            sfd.Filter = "ASS文件 (*.ass)|*.ass|SSA文件 (*.ssa)|*.ssa|SRT文件 (*.srt)|*.srt|LRC文件 (*.lrc)|*.lrc|文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            string path = sfd.FileName;
            try
            {
                using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.Default.GetBytes(text);
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

        /// <summary>
        /// 字符串转为繁体字
        /// </summary>
        /// <param name="str">简体中文字符串</param>
        /// <returns>繁体中文字符串</returns>
        public string StringToTraditional(string str)
        {
            try
            {
                return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
