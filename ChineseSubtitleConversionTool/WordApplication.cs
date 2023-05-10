using Microsoft.Office.Interop.Word;
using System;
using System.Reflection;

namespace ChineseSubtitleConversionTool
{
    public class WordApplication
    {
        private _Application appWord;
        private Document doc;
        public static Object CreatingWordApplicationLock = new Object();
        public WordApplication()
        {
            lock (CreatingWordApplicationLock)
            {
                appWord = new Application();
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object docType = Missing.Value;
                object visible = true;
                doc = appWord.Documents.Add(ref template, ref newTemplate, ref docType, ref visible);
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~WordApplication()
        {
            Dispose();
        }
        public void Dispose()
        {
            appWord.Selection.Delete();
            object saveChange = 0;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            if (appWord != null)
            {
                appWord.Quit(ref saveChange, ref originalFormat, ref routeDocument);
            }
            doc = null;
            appWord = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 简体转繁体函数
        /// </summary>
        /// <param name="src">简体字符串</param>
        /// <returns>繁体字符串</returns>
        public string chs_to_cht(string src)
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
        public string cht_to_chs(string src)
        {
            appWord.Selection.Delete();
            appWord.Selection.TypeText(src);
            /*UseVariants
                Boolean
            Optional Boolean. True if Word uses Taiwan, Hong Kong SAR, and Macao SAR character variants. Can only be used if translating from Simplified Chinese to Traditional Chinese*/
            appWord.Selection.Range.TCSCConverter(WdTCSCConverterDirection.wdTCSCConverterDirectionTCSC, true, false);
            appWord.ActiveDocument.Select();
            return appWord.Selection.Text;
        }
    }
}
