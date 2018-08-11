using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Utils工具
{
    /// <summary>
    /// Xml操作类
    /// </summary>
    public class XmlHelper
    {
        #region 序列化XML文件
        /// <summary>  
        /// 序列化XML字符串 
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="srcObject">对象</param>  
        /// <returns></returns>  
        public static string SerializeToXml(Type type, object srcObject)
        {
            type = type != null ? type : srcObject.GetType();
            XmlSerializer xs = new XmlSerializer(type);
            StringBuilder stb = new StringBuilder();
            string result = "";
            XmlWriter xw = XmlWriter.Create(stb, new XmlWriterSettings() { Encoding = UTF8Encoding.UTF8 });
            xs.Serialize(xw, srcObject);
            result = stb.ToString();

            result = StringHelper.ReplaceFirst(result, "encoding=\"utf-16\"", "encoding=\"utf-8\"");

            return result;

        }
        #endregion  


        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static object Deserialize<T>(Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(T));
            return xmldes.Deserialize(stream);
        }

        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static object Deserialize<T>(string str)
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(T));
         
            byte[] array = Encoding.ASCII.GetBytes(str);
            MemoryStream stream = new MemoryStream(array);             //convert stream 2 string      
            
            return xmldes.Deserialize(stream);
        }  
    }
}
