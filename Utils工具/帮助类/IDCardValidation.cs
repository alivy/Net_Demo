using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils工具
{
    /// <summary>  
    /// 验证身份证号码类  
    /// 
    public class IDCardValidation
    {
        /// 

        /// 验证身份证合理性  
        /// </summary>  

        /// <param name="Id"></param>  
        /// 
        public static bool CheckIDCard(string idNumber)
        {
            if (idNumber.Length == 18)
            {
                bool check = CheckIDCard18(idNumber);

                return check;
            }
            else if (idNumber.Length == 15)
            {
                bool check = CheckIDCard15(idNumber);
                return check;
            }

            else
            {
                return false;

            }
        }
        /// <summary>  

        /// 18位身份证号码验证  
        /// </summary>  
        private static bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false
                || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证  
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");

            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {

                return false;//生日验证  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');

            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());

            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证  

            }
            return true;//符合GB11643-1999标准  
        }


        /// <summary>  
        /// 16位身份证号码验证  

        /// </summary>  
        private static bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证  
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");

            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            return true;
        }

        /// <summary>
        /// 转换15位身份证号码为18位
        /// </summary>
        /// <param name="oldIDCard">15位的身份证</param>
        /// <returns>返回18位的身份证</returns>
        private static string IDCardShortToLong(string oldIDCard)
        {
            int iS = 0;

            //加权因子常数
            int[] iW = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            //校验码常数
            string LastCode = "10X98765432";
            //新身份证号
            string newIDCard;

            newIDCard = oldIDCard.Substring(0, 6);
            //填在第6位及第7位上填上‘1’，‘9’两个数字
            newIDCard += "19";

            newIDCard += oldIDCard.Substring(6, 9);

            //进行加权求和
            for (int i = 0; i < 17; i++)
            {
                iS += int.Parse(newIDCard.Substring(i, 1)) * iW[i];
            }

            //取模运算，得到模值
            int iY = iS % 11;
            //从LastCode中取得以模为索引号的值，加到身份证的最后一位，即为新身份证号。
            newIDCard += LastCode.Substring(iY, 1);
            return newIDCard;
        }

        /// <summary>
        /// 获取身份证的生日
        /// </summary>
        /// <param name="idCard">身份证</param>
        /// <returns></returns>
        public static string GetBirthDay(string idCard)
        {
            if (idCard.Length < 18)
            {
                idCard = IDCardShortToLong(idCard);
            }
            string birthday = idCard.Substring(6, 8);
            birthday = String.Format("{0}-{1}-{2}", birthday.Substring(0, 4), birthday.Substring(4, 2), birthday.Substring(6, 2));
            return birthday;
        }

        /// <summary>
        /// 获取身份证的性别
        /// </summary>
        /// <param name="idCard">身份证号码</param>
        ///  0:女
        ///  1:男
        ///  其他错误返回值错误
        /// <returns></returns>
        public static int GetSex(string idCard)
        {
            if (String.IsNullOrEmpty(idCard))
            {
                return 2;
            }
            if (idCard.Length < 18)
            {
                idCard = IDCardShortToLong(idCard);
            }
            int sex = Int32.Parse(idCard.Substring(16, 1));
            return sex % 2;
        }
    }
}
