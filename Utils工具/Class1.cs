﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web.Hosting;

namespace Utils工具
{
    public class Class1
    {
    }




    /// <summary>
    /// 身份证号码解析与生成
    /// 作者：宋雷鸣 10522779@qq.com
    /// </summary>
    public class IDCardNumber
    {
        #region 身份证信息属性
        private string _province;
        /// <summary>
        /// 所在省份信息
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        private string _area;
        /// <summary>
        /// 所在地区信息
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        private string _city;
        /// <summary>
        /// 所在区县信息
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private DateTime _age;
        /// <summary>
        /// 年龄
        /// </summary>
        public DateTime Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private int _sex;
        /// <summary>
        /// 性别，0为女，1为男
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _cardnumber;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string CardNumber
        {
            get { return _cardnumber; }
            set { _cardnumber = value; }
        }
        private string _json;
        /// <summary>
        /// 生成Javascript对象；
        /// </summary>
        public string Json
        {
            get { return _json; }
            set { _json = value; }
        }

        #endregion

        #region 静态方法
        private static readonly List<string[]> Areas = new List<string[]>();
        /// <summary>
        /// 获取区域信息
        /// </summary>
        private static void FillAreas()
        {
            //XmlDocument docXml = new XmlDocument();
            //string file = HostingEnvironment.MapPath("~/App_Data/AreaCodeInfo.xml");
            //docXml.Load(file);
            //XmlNodeList nodelist = docXml.GetElementsByTagName("area");
            //foreach (XmlNode node in nodelist)
            //{
            //    string code = node.Attributes["code"].Value;
            //    string name = node.Attributes["name"].Value;
            //    IDCardNumber.Areas.Add(new string[] { code, name });
            //}
        }
        /// <summary>
        /// 解析身份证信息
        /// </summary>
        /// <param name="idCardNumber"></param>
        public static IDCardNumber Get(string idCardNumber)
        {
            if (IDCardNumber.Areas.Count < 1)
                IDCardNumber.FillAreas();
            if (!IDCardNumber.CheckIDCardNumber(idCardNumber))
                throw new Exception("非法的身份证号码");
            //
            IDCardNumber cardInfo = new IDCardNumber(idCardNumber);
            return cardInfo;
        }
        /// <summary>
        /// 校验身份证号码是否合法
        /// </summary>
        /// <param name="idCardNumber"></param>
        /// <returns></returns>
        public static bool CheckIDCardNumber(string idCardNumber)
        {
            //正则验证
            Regex rg = new Regex(@"^\d{17}(\d|X)$");
            Match mc = rg.Match(idCardNumber);
            if (!mc.Success) return false;
            //加权码
            string code = idCardNumber.Substring(17, 1);
            double sum = 0;
            string checkCode = null;
            for (int i = 2; i <= 18; i++)
            {
                sum += int.Parse(idCardNumber[18 - i].ToString(), NumberStyles.HexNumber) * (Math.Pow(2, i - 1) % 11);
            }
            string[] checkCodes = { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };
            checkCode = checkCodes[(int)sum % 11];
            if (checkCode != code) return false;
            //
            return true;
        }
        /// <summary>
        /// 随机生成一个身份证号
        /// </summary>
        /// <returns></returns>
        public static IDCardNumber Radom()
        {
            long tick = DateTime.Now.Ticks;
            return new IDCardNumber(_radomCardNumber((int)tick));
        }
        /// <summary>
        /// 批量生成身份证
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<IDCardNumber> Radom(int count)
        {
            List<IDCardNumber> list = new List<IDCardNumber>();
            string cardNumber;
            bool isExits;
            for (int i = 0; i < count; i++)
            {
                do
                {
                    isExits = false;
                    int tick = (int)DateTime.Now.Ticks;
                    cardNumber = IDCardNumber._radomCardNumber(tick * (i + 1));
                    foreach (IDCardNumber c in list)
                    {
                        if (c.CardNumber == cardNumber)
                        {
                            isExits = true;
                            break;
                        }
                    }

                } while (isExits);
                list.Add(new IDCardNumber(cardNumber));
            }
            return list;
        }
        /// <summary>
        /// 生成随身份证号
        /// </summary>
        /// <param name="seed">随机数种子</param>
        /// <returns></returns>
        private static string _radomCardNumber(int seed)
        {
            if (IDCardNumber.Areas.Count < 1)
                IDCardNumber.FillAreas();
            System.Random rd = new System.Random(seed);
            //随机生成发证地
            string area = "";
            do
            {
                area = IDCardNumber.Areas[rd.Next(0, IDCardNumber.Areas.Count - 1)][0];
            } while (area.Substring(4, 2) == "00");
            //随机出生日期
            DateTime birthday = DateTime.Now;
            birthday = birthday.AddYears(-rd.Next(16, 60));
            birthday = birthday.AddMonths(-rd.Next(0, 12));
            birthday = birthday.AddDays(-rd.Next(0, 31));
            //随机码
            string code = rd.Next(1000, 9999).ToString("####");
            //生成完整身份证号
            string codeNumber = area + birthday.ToString("yyyyMMdd") + code;
            double sum = 0;
            string checkCode = null;
            for (int i = 2; i <= 18; i++)
            {
                sum += int.Parse(codeNumber[18 - i].ToString(), NumberStyles.HexNumber) * (Math.Pow(2, i - 1) % 11);
            }
            string[] checkCodes = { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };
            checkCode = checkCodes[(int)sum % 11];
            codeNumber = codeNumber.Substring(0, 17) + checkCode;
            //
            return codeNumber;
        }
        #endregion

        #region 身份证解析方法

        private IDCardNumber(string idCardNumber)
        {
            this._cardnumber = idCardNumber;
            _analysis();
        }
        /// <summary>
        /// 解析身份证
        /// </summary>
        private void _analysis()
        {
            //取省份，地区，区县
            string provCode = _cardnumber.Substring(0, 2).PadRight(6, '0');
            string areaCode = _cardnumber.Substring(0, 4).PadRight(6, '0');
            string cityCode = _cardnumber.Substring(0, 6).PadRight(6, '0');
            for (int i = 0; i < IDCardNumber.Areas.Count; i++)
            {
                if (provCode == IDCardNumber.Areas[i][0])
                    this._province = IDCardNumber.Areas[i][1];
                if (areaCode == IDCardNumber.Areas[i][0])
                    this._area = IDCardNumber.Areas[i][1];
                if (cityCode == IDCardNumber.Areas[i][0])
                    this._city = IDCardNumber.Areas[i][1];
                if (_province != null && _area != null && _city != null) break;
            }
            //取年龄
            string ageCode = _cardnumber.Substring(6, 8);
            try
            {
                int year = Convert.ToInt16(ageCode.Substring(0, 4));
                int month = Convert.ToInt16(ageCode.Substring(4, 2));
                int day = Convert.ToInt16(ageCode.Substring(6, 2));
                _age = new DateTime(year, month, day);
            }
            catch
            {
                throw new Exception("非法的出生日期");
            }
            //取性别
            string orderCode = _cardnumber.Substring(14, 3);
            this._sex = Convert.ToInt16(orderCode) % 2 == 0 ? 0 : 1;
            //生成Javascript对象
            _json = @"prov:'{0}',area:'{1}',city:'{2}',year:{3},month:{4},day:{5},sex:{6},number:'{7}'";
            _json = string.Format(_json, _province, _area, _city, _age.Year, _age.Month, _age.Day, _sex, _cardnumber);
            _json = "{" + _json + "}";
        }
        #endregion


        public  static string GenPinCode()
        {

            System.Random rnd;
            string[] _crabodistrict = new string[] { "350201", "350202", "350203", "350204", "350205", "350206", "350211", "350205", "350213" };


            rnd = new Random(System.DateTime.Now.Millisecond);

            //PIN = District + Year(50-92) + Month(01-12) + Date(01-30) + Seq(001-600)
            string _pinCode = string.Format("{0}19{1}{2:00}{3:00}{4:000}", _crabodistrict[rnd.Next(0, 8)], rnd.Next(50, 92), rnd.Next(1, 12), rnd.Next(1, 30), rnd.Next(1, 600));
            #region Verify
            char[] _chrPinCode = _pinCode.ToCharArray();
            //校验码字符值
            char[] _chrVerify = new char[] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
            //i----表示号码字符从由至左包括校验码在内的位置序号；
            //ai----表示第i位置上的号码字符值；
            //Wi----示第i位置上的加权因子，其数值依据公式intWeight=2（n-1）(mod 11)计算得出。
            int[] _intWeight = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };
            int _craboWeight = 0;
            for (int i = 0; i < 17; i++)//从1 到 17 位,18为要生成的验证码
            {
                _craboWeight = _craboWeight + Convert.ToUInt16(_chrPinCode[i].ToString()) * _intWeight[i];
            }
            _craboWeight = _craboWeight % 11;
            _pinCode += _chrVerify[_craboWeight];
            #endregion
            return _pinCode;
        }
    }

}

