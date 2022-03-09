using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChineseSubtitleConversionTool
{
    public class OfficeWordConvert
    {
        private _Application appWord;
        private Document doc;

        /// <summary>
        /// 转换进度
        /// </summary>
        /// <param name="sender">转换对象</param>
        /// <param name="percentage">进度百分比</param>
        public delegate void DelegateConvertEvent(object sender, double percentage);
        public event DelegateConvertEvent EventConvert;
        public void BindConvertEvent(DelegateConvertEvent e)
        {
            EventConvert += e;
        }
        private void EventConvertCallback(double p)
        {
            if (EventConvert != null)
            {
                EventConvert(this, p);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public OfficeWordConvert()
        {
            appWord = new Application();
            object template = Missing.Value;
            object newTemplate = Missing.Value;
            object docType = Missing.Value;
            object visible = true;
            doc = appWord.Documents.Add(ref template, ref newTemplate, ref docType, ref visible);
        }

        /// <summary>
        /// 简体转繁体函数
        /// </summary>
        /// <param name="src">简体字符串</param>
        /// <returns>繁体字符串</returns>
        public string Chs2Cht(string src)
        {
            double p = 0;
            StringBuilder sb = new StringBuilder();
            string[] lines = src.Split(new string[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(chs_to_cht(lines[i].Replace("\r", "")));
                if ((100 * i / lines.Length) - p > 1)
                {
                    p = 100 * i / lines.Length;
                    EventConvertCallback(p);
                }
            }
            EventConvertCallback(100);
            return sb.ToString();
        }

        /// <summary>
        /// 繁体转简体函数
        /// </summary>
        /// <param name="src">繁体字符串</param>
        /// <returns>简体字符串</returns>
        public string Cht2Chs(string src)
        {
            double p = 0;
            StringBuilder sb = new StringBuilder();
            string[] lines = src.Split(new string[] { "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(cht_to_chs(lines[i].Replace("\r", "")));
                if ((100 * i / lines.Length) - p > 1)
                {
                    p = 100 * i / lines.Length;
                    EventConvertCallback(p);
                }
            }
            EventConvertCallback(100);
            return sb.ToString();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~OfficeWordConvert()
        {
            Dispose();
        }

        private void Dispose()
        {
            object saveChange = 0;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            appWord.Quit(ref saveChange, ref originalFormat, ref routeDocument);
            doc = null;
            appWord = null;
            GC.Collect();
        }

        /// <summary>
        /// 简体转繁体函数
        /// </summary>
        /// <param name="src">简体字符串</param>
        /// <returns>繁体字符串</returns>
        private string chs_to_cht(string src)
        {
            appWord.Selection.Delete();
            appWord.Selection.TypeText(src);
            appWord.Selection.Range.TCSCConverter(WdTCSCConverterDirection.wdTCSCConverterDirectionSCTC, true, true);
            appWord.ActiveDocument.Select();
            return appWord.Selection.Text;
        }

        /// <summary>
        /// 繁体转简体函数
        /// </summary>
        /// <param name="src">繁体字符串</param>
        /// <returns>简体字符串</returns>
        private string cht_to_chs(string src)
        {
            appWord.Selection.Delete();
            appWord.Selection.TypeText(src);
            appWord.Selection.Range.TCSCConverter(WdTCSCConverterDirection.wdTCSCConverterDirectionTCSC, true, true);
            appWord.ActiveDocument.Select();
            return appWord.Selection.Text;
        }
    }
}
