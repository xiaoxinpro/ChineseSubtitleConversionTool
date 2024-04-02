using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChineseSubtitleConversionTool
{
    [Serializable]
    public class MainConfig
    {
        [System.Xml.Serialization.XmlElement]
        public enumConvertOption ConvertOption { get; set; } = enumConvertOption.Null;
        public int ControlTabIndex { get; set; } = 0;
        public int FormatIndex { get; set; } = 0;
        public int OutputEncodeIndex { get; set; } = 0;
        public int InputEncodeIndex { get; set; } = 0;
        public string FileName { get; set; } = "{name}.chs{exten}";

        public MainConfig() 
        { 
        
        } 

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="path">配置文件路径</param>
        /// <returns></returns>
        public static MainConfig Load(string path)
        {
            MainConfig config = null;
            try
            {
                config = (MainConfig)Serialize.XmlDeserailize(path, typeof(MainConfig));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return config;
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public static MainConfig Load()
        {
            MainConfig config = Load(Global.MainConfigPath);
            if (config == null)
            {
                config = new MainConfig();
            }
            return config;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="path"></param>
        public static void Save(MainConfig config, string path)
        {
            try
            {
                Serialize.XmlSerialize(path, config, typeof(MainConfig));
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="config"></param>
        public static void Save(MainConfig config)
        {
            Save(config, Global.MainConfigPath);
        }
    }
}
