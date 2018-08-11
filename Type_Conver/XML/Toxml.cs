using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Type_Conver
{
    public  class Toxml
    {

         #region DataTable和XML字符串互转
        /**/
        /// <summary>
        /// 将DataTable对象转换成XML字符串
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <returns>XML字符串</returns>
        public static string ConvertDataTableToXML(DataTable dt)
        {
            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    //根据ms实例化XmlWt
                    XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
                    //获取ds中的数据
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    //返回Unicode编码的文本
                    UnicodeEncoding ucode = new UnicodeEncoding();
                    string returnValue = ucode.GetString(temp).Trim();
                    return returnValue;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //释放资源
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

         #region xml字符和LIST互转
        /// <summary>

        /// 将简单的xml字符串转换成为LIST

        /// </summary>

        /// <typeparam name="T">类型，仅仅支持int/long/datetime/string/double/decimal/object</typeparam>

        /// <param name="xml"></param>

        /// <returns></returns>

        /// <remarks></remarks>

        public static List<T> XmlToList<T>(string xml)
        {

            Type tp = typeof(T);

            List<T> list = new List<T>();

            if (xml == null || string.IsNullOrEmpty(xml))
            {

                return list;

            }

            try
            {

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

                doc.LoadXml(xml);

                if (tp == typeof(string) | tp == typeof(int) | tp == typeof(long) | tp == typeof(DateTime) | tp == typeof(double) | tp == typeof(decimal))
                {

                    System.Xml.XmlNodeList nl = doc.SelectNodes("/root/item");

                    if (nl.Count == 0)
                    {

                        return list;

                    }

                    else
                    {

                        foreach (System.Xml.XmlNode node in nl)
                        {

                            if (tp == typeof(string)) { list.Add((T)(object)Convert.ToString(node.InnerText)); }

                            else if (tp == typeof(int)) { list.Add((T)(object)Convert.ToInt32(node.InnerText)); }

                            else if (tp == typeof(long)) { list.Add((T)(object)Convert.ToInt64(node.InnerText)); }

                            else if (tp == typeof(DateTime)) { list.Add((T)(object)Convert.ToDateTime(node.InnerText)); }

                            else if (tp == typeof(double)) { list.Add((T)(object)Convert.ToDouble(node.InnerText)); }

                            else if (tp == typeof(decimal)) { list.Add((T)(object)Convert.ToDecimal(node.InnerText)); }

                            else { list.Add((T)(object)node.InnerText); }

                        }

                        return list;

                    }

                }

                else
                {

                    //如果是自定义类型就需要反序列化了

                    System.Xml.XmlNodeList nl = doc.SelectNodes("/root/items/" + typeof(T).Name);

                    if (nl.Count == 0)
                    {

                        return list;

                    }

                    else
                    {

                        foreach (System.Xml.XmlNode node in nl)
                        {

                            list.Add(XMLToObject<T>(node.OuterXml));

                        }

                        return list;

                    }

                }

            }

            catch (XmlException)
            {

                throw new ArgumentException("不是有效的XML字符串", "xml");

            }

            catch (InvalidCastException)
            {

                throw new ArgumentException("指定的数据类型不匹配", "T");

            }

            catch (Exception exx)
            {

                throw exx;

            }

        }

        /// <summary>

        /// 将List转化为xml字符串

        /// </summary>

        /// <typeparam name="T">类型，仅仅支持int/long/datetime/string/double/decimal/object</typeparam>

        /// <param name="list"></param>

        /// <returns></returns>

        /// <remarks></remarks>

        public static string ListToXml<T>(List<T> list)
        {

            Type tp = typeof(T);

            string xml = "<root>";

            if (tp == typeof(string) | tp == typeof(int) | tp == typeof(long) | tp == typeof(DateTime) | tp == typeof(double) | tp == typeof(decimal))
            {
                foreach (T obj in list)
                {

                    xml = xml + "<item>" + obj.ToString() + "</item>";
                }
            }
            else
            {
                xml = xml + "<items>";
                foreach (T obj in list)
                {
                    xml = xml + ObjectToXML<T>(obj);
                }
                xml = xml + "</items>";
            }
            xml = xml + "</root>";
            return xml;
        }


         /// <summary>
         /// 写入xml文件
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="list"></param>
         public static void FileToXml<T>(List<T> list){
             using (System.IO.StringWriter stringWriter = new StringWriter(new StringBuilder()))
             {
                 XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                 xmlSerializer.Serialize(stringWriter, list);
                 FileStream fs = new FileStream("list_userModel.xml", FileMode.OpenOrCreate);
                 StreamWriter sw = new StreamWriter(fs);
                 sw.Write(stringWriter.ToString());
                 sw.Close();
                 fs.Close();
                 Console.WriteLine("写入文件成功！");
             }
         }

        #endregion

         #region 序列化xml/反序列化

         /// <summary>

        /// 对象序列化为XML

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <param name="obj"></param>

        /// <param name="encoding"></param>

        /// <returns></returns>

        /// <remarks></remarks>

        public static string ObjectToXML<T>(T obj, System.Text.Encoding encoding)
        {

            XmlSerializer ser = new XmlSerializer(obj.GetType());

            Encoding utf8EncodingWithNoByteOrderMark = new UTF8Encoding(false);

            using (MemoryStream mem = new MemoryStream())
            {

                XmlWriterSettings settings = new XmlWriterSettings

                {

                    OmitXmlDeclaration = true,

                    Encoding = utf8EncodingWithNoByteOrderMark

                };

                using (XmlWriter XmlWriter = XmlWriter.Create(mem, settings))
                {

                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                    ns.Add("", "");

                    ser.Serialize(XmlWriter, obj, ns);

                    return encoding.GetString(mem.ToArray());

                }

            }

        }

        /// <summary>

        /// 对象序列化为xml

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <param name="obj"></param>

        /// <returns></returns>

        /// <remarks></remarks>

        public static string ObjectToXML<T>(T obj)
        {

            return ObjectToXML<T>(obj, Encoding.UTF8);

        }

        /// <summary>

        /// xml反序列化为对象

        /// </summary>

        /// <typeparam name="T"></typeparam>

        /// <param name="source"></param>

        /// <param name="encoding"></param>

        /// <returns></returns>

        /// <remarks></remarks>

        public static T XMLToObject<T>(string source, Encoding encoding)
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));

            using (MemoryStream Stream = new MemoryStream(encoding.GetBytes(source)))
            {

                return (T)mySerializer.Deserialize(Stream);

            }

        }

        public static T XMLToObject<T>(string source)
        {

            return XMLToObject<T>(source, Encoding.UTF8);

        }

        #endregion
    }


    /**/
    /// <summary>
    /// XML形式的字符串、XML文江转换成DataSet、DataTable格式
    /// </summary>
    public class XmlToData
    {
        /**/
        /// <summary>
        /// 将Xml内容字符串转换成DataSet对象
        /// </summary>
        /// <param name="xmlStr">Xml内容字符串</param>
        /// <returns>DataSet对象</returns>
        public static DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        /**/
        /// <summary>
        /// 将Xml字符串转换成DataTable对象
        /// </summary>
        /// <param name="xmlStr">Xml字符串</param>
        /// <param name="tableIndex">Table表索引</param>
        /// <returns>DataTable对象</returns>
        public static DataTable CXmlToDatatTable(string xmlStr, int tableIndex)
        {
            return CXmlToDataSet(xmlStr).Tables[tableIndex];
        }
        /**/
        /// <summary>
        /// 将Xml字符串转换成DataTable对象
        /// </summary>
        /// <param name="xmlStr">Xml字符串</param>
        /// <returns>DataTable对象</returns>
        public static DataTable CXmlToDatatTable(string xmlStr)
        {
            return CXmlToDataSet(xmlStr).Tables[0];
        }
        /**/
        /// <summary>
        /// 读取Xml文件信息,并转换成DataSet对象
        /// </summary>
        /// <remarks>
        /// DataSet ds = new DataSet();
        /// ds = CXmlFileToDataSet("/XML/upload.xml");
        /// </remarks>
        /// <param name="xmlFilePath">Xml文件地址</param>
        /// <returns>DataSet对象</returns>
        public static DataSet CXmlFileToDataSet(string xmlFilePath)
        {
            if (!string.IsNullOrEmpty(xmlFilePath))
            {
                string path = HttpContext.Current.Server.MapPath(xmlFilePath);
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    XmlDocument xmldoc = new XmlDocument();
                    //根据地址加载Xml文件
                    xmldoc.Load(path);

                    DataSet ds = new DataSet();
                    //读取文件中的字符流
                    StrStream = new StringReader(xmldoc.InnerXml);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        /**/
        /// <summary>
        /// 读取Xml文件信息,并转换成DataTable对象
        /// </summary>
        /// <param name="xmlFilePath">xml文江路径</param>
        /// <param name="tableIndex">Table索引</param>
        /// <returns>DataTable对象</returns>
        public static DataTable CXmlToDataTable(string xmlFilePath, int tableIndex)
        {
            return CXmlFileToDataSet(xmlFilePath).Tables[tableIndex];
        }
        /**/
        /// <summary>
        /// 读取Xml文件信息,并转换成DataTable对象
        /// </summary>
        /// <param name="xmlFilePath">xml文江路径</param>
        /// <returns>DataTable对象</returns>
        public static DataTable CXmlToDataTable(string xmlFilePath)
        {
            return CXmlFileToDataSet(xmlFilePath).Tables[0];
        }
    }
}
