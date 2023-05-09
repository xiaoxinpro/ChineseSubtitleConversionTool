using System.IO;
using System.Text;

namespace ChineseSubtitleConversionTool
{
    public class OfficeWordConvert
    {

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
        /// 简体转繁体函数
        /// </summary>
        /// <param name="src">简体字符串</param>
        /// <returns>繁体字符串</returns>
        public string Chs2Cht(string src)
        {
            int len = src.Length;
            int cnt = 0;
            double p = 0;
            StringBuilder sb = new StringBuilder();
            using (StringReader sr = new StringReader(src))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    cnt += line.Length;
                    if (isStringChinese(line) == false)
                    {
                        sb.AppendLine(line.TrimEnd());
                    }
                    else
                    {
                        sb.AppendLine(WordApplicationPool.Get().chs_to_cht(line).TrimEnd());
                    }
                    if (100 * cnt / len - p > 1)
                    {
                        p = 100 * cnt / len;
                        EventConvertCallback(p > 100 ? 100 : p);
                    }
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
            int len = src.Length;
            int cnt = 0;
            double p = 0;
            StringBuilder sb = new StringBuilder();
            using (StringReader sr = new StringReader(src))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    cnt += line.Length;
                    if (isStringChinese(line) == false)
                    {
                        sb.AppendLine(line.TrimEnd());
                    }
                    else
                    {
                        sb.AppendLine(WordApplicationPool.Get().cht_to_chs(line).TrimEnd());
                    }
                    if (100 * cnt / len - p > 1)
                    {
                        p = 100 * cnt / len;
                        EventConvertCallback(p > 100 ? 100 : p);
                    }
                }
            }
            EventConvertCallback(100);
            return sb.ToString();
        }


        /// <summary>
        /// 检查字符串中是否包含汉字
        /// </summary>
        /// <param name="src">待检测字符串</param>
        /// <returns>是否包含汉字</returns>
        private bool isStringChinese(string src)
        {
            char[] c = src.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] >= 0x4e00 && c[i] <= 0x9fbb)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
