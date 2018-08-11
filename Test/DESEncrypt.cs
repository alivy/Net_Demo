using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Test
{
    /// <summary>
    /// DES����/�����ࡣ
    /// </summary>
    public class DESEncrypt
    {
        /// <summary>
        /// �Զ���ֵ
        /// </summary>
        //static string UL = System.Configuration.ConfigurationManager.AppSettings["EncryptString"];
        static string UL = "q*f+@t(.";

        #region ========����========

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="Text">Ҫ���ܵ��ַ���</param>
        /// <returns>���ؼ��ܺ���ַ���</returns>
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
        /// ���ַ�������DES����(IOSͨ�ã���׿�÷�)
        /// </summary>
        /// <param name="sourceString">�����ܵ��ַ���</param>
        /// <returns>���ܺ��BASE64������ַ���</returns>
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

        ///// <summary> 
        ///// ��������  ����C#
        ///// </summary> 
        ///// <param name="Text"></param> 
        ///// <param name="sKey"></param> 
        ///// <returns></returns> 
        //public static string Encrypt(string Text, string sKey)
        //{
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //    byte[] inputByteArray;
        //    inputByteArray = Encoding.Default.GetBytes(Text);


        //    des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey,"md5").Substring(0, 8));
        //    des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
        //    cs.Write(inputByteArray, 0, inputByteArray.Length);
        //    cs.FlushFinalBlock();
        //    StringBuilder ret = new StringBuilder();
        //    foreach (byte b in ms.ToArray())
        //    {
        //        ret.AppendFormat("{0:X2}", b);
        //    }
        //    return ret.ToString();
        //}
        #endregion

        #region ========����========


        /// <summary>
        /// ����(IOSͨ�ã���׿�÷�)
        /// </summary>
        /// <param name="pToDecrypt">Ҫ���ܵ���Base64</param>
        /// <param name="sKey">��Կ���ұ���Ϊ8λ</param>
        /// <returns>�ѽ��ܵ��ַ���</returns>

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                //ת�������ַ�
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
            catch (Exception ex)
            {
                return "";
            }
        }


        /// <summary>
        /// ����
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

        ///// <summary> 
        ///// ��������  ����C#
        ///// </summary> 
        ///// <param name="Text"></param> 
        ///// <param name="sKey"></param> 
        ///// <returns></returns> 
        //public static string Decrypt(string Text, string sKey)
        //{
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //    int len;
        //    len = Text.Length / 2;
        //    byte[] inputByteArray = new byte[len];
        //    int x, i;
        //    for (x = 0; x < len; x++)
        //    {
        //        i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
        //        inputByteArray[x] = (byte)i;
        //    }
        //    des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        //    des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        //    cs.Write(inputByteArray, 0, inputByteArray.Length);
        //    cs.FlushFinalBlock();
        //    return Encoding.Default.GetString(ms.ToArray());
        //}
        #endregion
    }
}
