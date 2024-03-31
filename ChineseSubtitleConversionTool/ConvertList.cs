using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ChineseSubtitleConversionTool
{
    /// <summary>
    /// 转换任务列表类
    /// </summary>
    public class ConvertList
    {
        public List<ConvertListItem> Items { get; set; } = new List<ConvertListItem>();

        /// <summary>
        /// 转换并输出全部
        /// </summary>
        /// <param name="model">转换模型</param>
        /// <param name="idiom">是否启用常用词</param>
        /// <param name="encoding">输出文件编码</param>
        /// <param name="outputDir">输出文件夹</param>
        /// <param name="outputSuffix">输出文件后缀</param>
        /// <returns></returns>
        public long ConvertOutputAll(EnumConverterModel model, bool idiom = false, Encoding encoding = null, string outputDir = null, string outputSuffix = "")
        {
            long cnt = 0;
            bool isOutputSourceDir = false;
            if (string.IsNullOrWhiteSpace(outputDir))
            {
                isOutputSourceDir = true;
            }
            else if (Directory.Exists(outputDir) == false)
            {
                Directory.CreateDirectory(outputDir);
            }
            foreach (ConvertListItem item in Items)
            {
                if (isOutputSourceDir)
                {
                    outputDir = Path.GetDirectoryName(item.SourceFile);
                }
                item.TargetFile = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(item.SourceFile) + outputSuffix + Path.GetExtension(item.SourceFile));
                cnt += item.ConvertOutput(model, idiom, encoding);
            }
            return cnt;
        }
    }

    /// <summary>
    /// 转换任务类
    /// </summary>
    public class ConvertListItem
    { 
        public string SourceFile { get; set; }
        public string TargetFile { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ConvertListItem()
        {
            SourceFile = TargetFile = string.Empty;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sourceFile">输入文件路径</param>
        /// <param name="targetFile">输出文件路径</param>
        public ConvertListItem(string sourceFile, string targetFile = "")
        {
            SourceFile = sourceFile;
            TargetFile = targetFile;
        }

        /// <summary>
        /// 转换并输出到文件
        /// </summary>
        /// <param name="model">转换模型</param>
        /// <param name="idiom">是否启用常用词</param>
        /// <param name="encoding">输出文件编码</param>
        /// <returns>转换的行数</returns>
        /// <exception cref="Exception">文件不存在异常</exception>
        public long ConvertOutput(EnumConverterModel model, bool idiom = false, Encoding encoding = null)
        {
            string filePath = SourceFile;
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            if (File.Exists(SourceFile) == false)
            {
                throw new Exception($"输入的源文件 {SourceFile} 不存在");
            }
            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile); //如果文件存在则删除文件
            }
            using (FileStream fsWrite = new FileStream(TargetFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                long cnt = ReadTextLines(SourceFile, text =>
                {
                    string output = ChineseConverter.Convert(text, model, idiom);
                    byte[] buffer = encoding.GetBytes(output);
                    fsWrite.Write(buffer, 0, buffer.Length);
                });
                return cnt;
            }
        }

        /// <summary>
        /// 读取指定行数的文本
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="funcLine">文本回调函数</param>
        /// <param name="maxLine">最大读取的行数</param>
        /// <returns>整个文件的行数</returns>
        private long ReadTextLines(string filePath, Action<string> funcLine, int maxLine = 1024)
        {
            long count = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                try
                {
                    long cntLine = 0;
                    StringBuilder sbText = new StringBuilder();
                    // 从文件读取并显示行，直到文件的末尾 
                    while (!sr.EndOfStream)
                    {
                        cntLine++;
                        count++;
                        sbText.AppendLine(sr.ReadLine());
                        if (cntLine >= maxLine)
                        {
                            funcLine(sbText.ToString());
                            sbText.Clear();
                            cntLine = 0;
                        }
                    }
                    funcLine(sbText.ToString());
                    sbText.Clear();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    funcLine(err.Message);
                }
                return count;
            }
        }

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
