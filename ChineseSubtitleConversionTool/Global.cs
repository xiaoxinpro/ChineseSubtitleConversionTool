using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    /// <summary>
    /// 全局静态类
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// 用户文件夹
        /// </summary>
        public static readonly string UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ChineseSubtitleConversionTool";

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static readonly string MainConfigPath = UserDirectory + "\\Config.xml";


        /// <summary>
        /// 初始化全局类
        /// </summary>
        public static void Init()
        {
            // 检查目录是否存在
            if (Directory.Exists(UserDirectory) == false)
            {
                Directory.CreateDirectory(UserDirectory);
            }
        }

        /// <summary>
        /// 禁用/启用 GrouBox内全部控件
        /// </summary>
        /// <param name="group">Group控件</param>
        /// <param name="isEnable"></param>
        public static void GroupBoxEnable(GroupBox group, bool isEnable = true)
        {
            try
            {
                foreach (Control c in group.Controls)
                {
                    c.Enabled = isEnable;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        /// <summary>
        /// 模拟点击ButtonBox按钮
        /// </summary>
        /// <param name="button">按钮控件</param>
        public static void ButtonOnClick(Button button)
        {
            Type t = typeof(Button);
            object[] p = new object[1];
            MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            p[0] = EventArgs.Empty;
            m.Invoke(button, p);
            return;
        }
    }
}
