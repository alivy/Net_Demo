using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace Utils工具
{
    public class SignHelper
    {
        /// <summary>
        /// MD5签名函数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetMD5Sign(string data)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(data, "MD5");
        }

        /// <summary>
        /// HMACMD5签名函数
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHMACMD5Sign(string msg, string key)
        {
            if (msg == null || key == null)
            {
                throw new Exception("Invalid arguments!");
            }
            try
            {
                byte[] msg_bytes = Encoding.UTF8.GetBytes(msg);
                byte[] key_bytes = Encoding.UTF8.GetBytes(key);

                HMACMD5 hmac = new HMACMD5(key_bytes);
                byte[] result_bytes = hmac.ComputeHash(msg_bytes);

                string sign = "";
                for (int i = 0; i < result_bytes.Length; i++)
                {
                    // byte转换为16进制格式字符串。如果字符串只有1位，则前面补零。
                    string hex = result_bytes[i].ToString("x");
                    if (hex.Length == 1)
                    {
                        hex = "0" + hex;
                    }
                    sign += hex;
                }
                return sign;
            }
            catch (Exception ex)
            {
                throw new Exception("GenSign failed: " + ex.Message);
            }
        }



        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="content">待签名字符串</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="input_charset">编码格式</param>
        /// <returns>签名后字符串</returns>
        public static string GetRSAFromPkcs8Sign(string content, string privateKey, string input_charset)
        {
            return RSAFromPkcs8.sign(content,privateKey,input_charset);
        }


        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="content">待签名字符串</param>
        /// <returns>签名后字符串</returns>
        public static string GetMd5AlgorithmSign(string content)
        {
            return Md5Algorithm.getInstance().md5Digest(Encoding.UTF8.GetBytes(content));
        }

    }
}
