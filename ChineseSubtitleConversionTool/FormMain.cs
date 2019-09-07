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
            try
            {
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
