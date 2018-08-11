using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utils工具
{
    /// <summary>
    /// 单例获取key值
    /// </summary>
    public class SingtonKey
    {
        public SingtonKey()
        {

            CreateID createID = CreateID.GetInstance();
            string strUniqueNum = createID.CreateUniqueID();
        }

    }

    /// <summary>
    /// 单例模式实现
    /// 唯一值由[0-9a-z]组合而成，且生成的每个ID不能重复
    /// </summary>
    public class CreateID
    {
        private static CreateID _instance;
        private static readonly object syncRoot = new object();
        private EHashtable hashtable = new EHashtable();
        private string _strXMLURL = string.Empty;

        private CreateID()
        {
            hashtable.Add("0", "0");
            hashtable.Add("1", "1");
            hashtable.Add("2", "2");
            hashtable.Add("3", "3");
            hashtable.Add("4", "4");
            hashtable.Add("5", "5");
            hashtable.Add("6", "6");
            hashtable.Add("7", "7");
            hashtable.Add("8", "8");
            hashtable.Add("9", "9");
            hashtable.Add("10", "a");
            hashtable.Add("11", "b");
            hashtable.Add("12", "c");
            hashtable.Add("13", "d");
            hashtable.Add("14", "e");
            hashtable.Add("15", "f");
            hashtable.Add("16", "g");
            hashtable.Add("17", "h");
            hashtable.Add("18", "i");
            hashtable.Add("19", "j");
            hashtable.Add("20", "k");
            hashtable.Add("21", "l");
            hashtable.Add("22", "m");
            hashtable.Add("23", "n");
            hashtable.Add("24", "o");
            hashtable.Add("25", "p");
            hashtable.Add("26", "q");
            hashtable.Add("27", "r");
            hashtable.Add("28", "s");
            hashtable.Add("29", "t");
            hashtable.Add("30", "u");
            hashtable.Add("31", "v");
            hashtable.Add("32", "w");
            hashtable.Add("33", "x");
            hashtable.Add("34", "y");
            hashtable.Add("35", "z");
            _strXMLURL = System.IO.Path.GetFullPath(@"..\..\") + "XMLs\\record.xml";

        }

        public static CreateID GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new CreateID();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// 创建UniqueID
        /// </summary>
        /// <returns>UniqueID</returns>
        public string CreateUniqueID()
        {
            long _uniqueid = GetGuidFromXml();

            return Convert10To36(_uniqueid);
        }

        /// <summary>
        /// 获取UniqueID总记录，即获取得到的这个ID是第几个ID
        /// 更新UniqueID使用的个数，用于下次使用
        /// </summary>
        /// <returns></returns>
        private long GetGuidFromXml()
        {
            long record = 0;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(_strXMLURL);
            XmlElement rootNode = xmldoc.DocumentElement;
            //此次的个数值
            record = Convert.ToInt64(rootNode["record"].InnerText);
            //此次的个数值+1 == 下次的个数值
            rootNode["record"].InnerText = Convert.ToString(record + 1);
            xmldoc.Save(_strXMLURL);

            return record;
        }

        /// <summary>
        /// 10进制转36进制
        /// </summary>
        /// <param name="intNum10">10进制数</param>
        /// <returns></returns>
        private string Convert10To36(long intNum10)
        {
            string strNum36 = string.Empty;
            long result = intNum10 / 36;
            long remain = intNum10 % 36;
            if (hashtable.ContainsKey(remain.ToString()))
                strNum36 = hashtable[remain.ToString()].ToString() + strNum36;
            intNum10 = result;
            while (intNum10 / 36 != 0)
            {
                result = intNum10 / 36;
                remain = intNum10 % 36;
                if (hashtable.ContainsKey(remain.ToString()))
                    strNum36 = hashtable[remain.ToString()].ToString() + strNum36;
                intNum10 = result;
            }
            if (intNum10 > 0 && intNum10 < 36)
            {
                if (hashtable.ContainsKey(intNum10.ToString()))
                    strNum36 = hashtable[intNum10.ToString()].ToString() + strNum36;
            }

            return strNum36;
        }

    }

    /// <summary>
    /// Summary description for EHashTable
    /// </summary>
    public class EHashtable : Hashtable
    {
        private ArrayList list = new ArrayList();
        public override void Add(object key, object value)
        {
            base.Add(key, value);
            list.Add(key);
        }
        public override void Clear()
        {
            base.Clear();
            list.Clear();
        }
        public override void Remove(object key)
        {
            base.Remove(key);
            list.Remove(key);
        }
        public override ICollection Keys
        {
            get
            {
                return list;
            }
        }
    }


}
