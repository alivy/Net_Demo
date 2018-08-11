using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Utils工具
{
    /// <summary>
    /// DES加密/解密类。
    /// </summary>
    public class DESEncrypt
    {
        /// <summary>
        /// 自定义值
        /// </summary>
        //static string UL = System.Configuration.ConfigurationManager.AppSettings["EncryptString"];
        static string UL = "hao123cz";



        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string EncryptEncoding(string Text,string sKey=null)
        {
            if (sKey == null)
            {
                return Encrypt(Text, UL);
            }
            else
            {
                return Encrypt(Text, sKey);
            }
        }


        /// <summary>
        /// 对字符串进行DES加密(IOS通用，安卓用法)
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <returns>加密后的BASE64编码的字符串</returns>
        public static string Encrypt(string sourceString, string sKey)
        {
            byte[] btKey = Encoding.UTF8.GetBytes(sKey);
            byte[] btIV = Encoding.UTF8.GetBytes(sKey);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Encoding.UTF8.GetBytes(sourceString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    throw;
                }
            }
        }


        #endregion



        #region ========解密========


        /// <summary>
        /// 解密(IOS通用，安卓用法)
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位</param>
        /// <returns>已解密的字符串</returns>

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            //转义特殊字符
            pToDecrypt = pToDecrypt.Replace("-", "+");
            pToDecrypt = pToDecrypt.Replace("_", "/");
            pToDecrypt = pToDecrypt.Replace("~", "=");
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string DecryptDecoding(string Text, string sKey = null)
        {
            if (sKey == null)
            {
                return Decrypt(Text, UL);
            }
            else
            {
                return Decrypt(Text, sKey);
            }
        }


        #endregion
    }
}
