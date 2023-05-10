using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ChineseSubtitleConversionTool
{
    #region 序列化
    public class Serialize
    {
        /// <summary>
        /// 序列化为对象
        /// </summary>
        /// <param name="objname"></param>
        /// <param name="obj"></param>
        public static void BinarySerialize(string filename, object obj)
        {
            try
            {
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 从二进制文件中反序列化
        /// </summary>
        /// <param name="objname"></param>
        /// <returns></returns>
        public static object BinaryDeserialize(string filename)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            object obj;
            if (!System.IO.File.Exists(filename))
                throw new Exception("在反序列化之前,请先序列化");
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;

        }

        /// <summary>
        /// 序列化对象到文件
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="obj">对象实体</param>
        /// <param name="type">对象类型</param>
        public static void XmlSerialize(string filename, object obj, Type type)
        {

            try
            {
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 序列化为xml
                    XmlSerializer formatter = new XmlSerializer(type);
                    formatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// 从xml文件中反序列化
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        public static object XmlDeserailize(string filename, Type type)
        {
            object obj;
            if (!System.IO.File.Exists(filename))
                throw new Exception("对反序列化之前,请先序列化");
            //Xml格式反序列化
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer formatter = new XmlSerializer(type);
                obj = formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        public static T XmlDeepCopy<T>(T obj, object retval)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = xml.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }
    }
    #endregion
}
