
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
            WordApplication wordApplication = WordApplicationPool.Get();
            string str = wordApplication.chs_to_cht(src);
            WordApplicationPool.Return(wordApplication);
            EventConvertCallback(100);
            return str.Replace("\r", "\r\n");
        }

        /// <summary>
        /// 繁体转简体函数
        /// </summary>
        /// <param name="src">繁体字符串</param>
        /// <returns>简体字符串</returns>
        public string Cht2Chs(string src)
        {
            WordApplication wordApplication = WordApplicationPool.Get();
            string str = wordApplication.cht_to_chs(src);
            WordApplicationPool.Return(wordApplication);
            EventConvertCallback(100);
            return str.Replace("\r","\r\n");
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
