using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChineseSubtitleConversionTool
{
    public class EnumHelper
    {
        /// <summary>
        /// 通过枚举变量获取描述
        /// </summary>
        /// <param name="enumValue">枚举变量</param>
        /// <returns>枚举描述</returns>
        public static string GetDescriptionByEnum(Enum enumValue)
        {
            string value = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)    //当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// 通过描述获取对应的枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举变量</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
                if (objs.Length > 0 && (objs[0] as DescriptionAttribute).Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }

        /// <summary>
        /// 获取枚举全部值的List
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns>枚举List</returns>
        public static List<T> ToList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        /// <summary>
        /// 获取全部枚举描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns>枚举描述List</returns>
        public static List<string> ToListDescription<T>() where T : Enum
        {
            List<string> list = new List<string>();
            System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs.Length > 0)
                {
                    list.Add((objs[0] as DescriptionAttribute).Description);
                }
            }
            return list;
        }

        /// <summary>
        /// 使用枚举初始化ComboBox的Items数据
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="comboBox">ComboBox控件</param>
        public static void InitComboBox<T>(ComboBox comboBox) where T : Enum
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(ToListDescription<T>().ToArray());
        }

        /// <summary>
        /// 使用枚举初始化ComboBox的Items数据
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="comboBox">ComboBox控件</param>
        /// <param name="value">默认选中枚举变量</param>
        public static void InitComboBox<T>(ComboBox comboBox, T value) where T : Enum
        {
            InitComboBox<T>(comboBox);
            SetComboBoxSelected(comboBox, value);
        }

        /// <summary>
        /// 获取ComboBox选中元素的枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="comboBox">ComboBox控件</param>
        /// <returns>枚举变量</returns>
        public static T GetComboBoxSelected<T>(ComboBox comboBox) where T : Enum
        {
            return GetEnumByDescription<T>(comboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// 使用枚举设置ComboBox选中值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="comboBox">ComboBox控件</param>
        /// <param name="value">枚举变量</param>
        public static void SetComboBoxSelected<T>(ComboBox comboBox, T value) where T : Enum
        {
            comboBox.SelectedItem = GetDescriptionByEnum(value);
        }

    }
}
