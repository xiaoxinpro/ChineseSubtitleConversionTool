using OpenCCNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitComboBoxMode(ComboBoxMode);
            ZhConverter.Initialize();
        }

        private void InitComboBoxMode(ComboBox comboBox)
        {
            EnumHelper.InitComboBox(comboBox, EnumConverterModel.cht2chs);
        }

        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            RichTextBoxTarget.Clear();
            RichTextBoxTarget.Text = ChineseConverter(RichTextBoxSource.Text, EnumHelper.GetComboBoxSelected<EnumConverterModel>(ComboBoxMode), CheckBoxIdiomConvert.Checked);
        }

        private string ChineseConverter(string source, EnumConverterModel model, bool idiom = false)
        {
            string target;
            try
            {
                switch (model)
                {
                    case EnumConverterModel.cht2chs:
                        target = ZhConverter.HantToHans(source);
                        break;
                    case EnumConverterModel.cht2chtw:
                        target = ZhConverter.HantToTW(source, idiom);
                        break;
                    case EnumConverterModel.cht2chk:
                        target = ZhConverter.HantToHK(source);
                        break;
                    case EnumConverterModel.chtw2chs:
                        target = ZhConverter.TWToHans(source, idiom);
                        break;
                    case EnumConverterModel.chtw2chk:
                        target = ZhConverter.TWToHant(source, idiom);
                        break;
                    case EnumConverterModel.chk2chs:
                        target = ZhConverter.HKToHans(source);
                        break;
                    case EnumConverterModel.chk2cht:
                        target = ZhConverter.HKToHant(source);
                        break;
                    case EnumConverterModel.chs2cht:
                        target = ZhConverter.HansToHant(source);
                        break;
                    case EnumConverterModel.chs2chtw:
                        target = ZhConverter.HansToTW(source, idiom);
                        break;
                    case EnumConverterModel.chs2chk:
                        target = ZhConverter.HansToHK(source);
                        break;
                    default:
                        target = "无效的转换模型。";
                        break;
                }
            }
            catch (Exception err)
            {
                target = err.Message;
            }
            return target;
        }
    }

    public enum EnumConverterModel
    {
        [Description("繁体中文（标准）→ 简体中文（标准）")]
        cht2chs,
        [Description("繁体中文（标准）→ 繁体中文（台湾）")]
        cht2chtw,
        [Description("繁体中文（标准）→ 繁体中文（香港）")]
        cht2chk,
        [Description("繁体中文（台湾）→ 简体中文")]
        chtw2chs,
        [Description("繁体中文（台湾）→ 繁体中文（标准）")]
        chtw2chk,
        [Description("繁体中文（香港）→ 简体中文")]
        chk2chs,
        [Description("繁体中文（香港）→ 繁体中文（标准）")]
        chk2cht,
        [Description("简体中文 → 繁体中文（标准）")]
        chs2cht,
        [Description("简体中文 → 繁体中文（台湾）")]
        chs2chtw,
        [Description("简体中文 → 繁体中文（香港）")]
        chs2chk,
    }
}
