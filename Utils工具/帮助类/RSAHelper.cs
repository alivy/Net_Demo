using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Utils工具
{
    /// <summary>
    /// 类名：RSAHelper
    /// 功能：RSA解密、加密、签名、验签
    /// 说明：
    /// </summary>
    public sealed class RSAHelper
    {
        #region RSA加密

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publickey"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string content, string publickey)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publickey);
                int keySize = rsa.KeySize / 8;
                int bufferSize = keySize - 11;
                byte[] buffer = new byte[bufferSize];

                MemoryStream msInput = new MemoryStream(Encoding.UTF8.GetBytes(content));
                MemoryStream msOuput = new MemoryStream();
                int readLen = msInput.Read(buffer, 0, bufferSize);
                while (readLen > 0)
                {
                    byte[] dataToEnc = new byte[readLen];
                    Array.Copy(buffer, 0, dataToEnc, 0, readLen);
                    byte[] encData = rsa.Encrypt(dataToEnc, false);
                    msOuput.Write(encData, 0, encData.Length);
                    readLen = msInput.Read(buffer, 0, bufferSize);
                }
                msInput.Close();
                byte[] result = msOuput.ToArray();    //得到加密结果
                msOuput.Close();
                rsa.Clear();
                return Convert.ToBase64String(result);
            }
            catch (Exception)
            {
                return "error";
            }
        }
        #endregion

        #region RSA解密
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content">密文</param>
        /// <param name="privatekey">私钥</param>
        /// <returns></returns>
        public static string RSADecrypt(string content, string privatekey)
        {
            byte[] contentByte = Convert.FromBase64String(content);
            return RSADecrypt(contentByte, privatekey);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content">密文</param>
        /// <param name="privatekey">私钥</param>
        /// <returns></returns>
        public static string RSADecrypt(byte[] content, string privatekey)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privatekey);

                int keySize = rsa.KeySize / 8;
                byte[] buffer = new byte[keySize];
                MemoryStream msInput = new MemoryStream(content);
                MemoryStream msOutput = new MemoryStream();
                int readLen = msInput.Read(buffer, 0, keySize);
                while (readLen > 0)
                {
                    byte[] dataToDec = new byte[readLen];
                    Array.Copy(buffer, 0, dataToDec, 0, readLen);
                    byte[] decData = rsa.Decrypt(dataToDec, false);
                    msOutput.Write(decData, 0, decData.Length);
                    readLen = msInput.Read(buffer, 0, keySize);
                }
                msInput.Close();
                byte[] result = msOutput.ToArray();    //得到解密结果
                msOutput.Close();
                rsa.Clear();
                return Encoding.UTF8.GetString(result);
            }
            catch (Exception)
            {
                return "error";
            }
        }

        #endregion

        /// <summary>
        /// 获取sign签名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetSign<T>(T data, string privatekey)
        {
            var strJson = JsonHelper.Serialize(data);
            //私钥签名 
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privatekey);
            byte[] AOutput = rsa.SignData(Encoding.UTF8.GetBytes(strJson), "SHA1");
            return Encoding.UTF8.GetString(AOutput);
        }

        /// <summary>
        /// 验签
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="sign"></param>
        /// <param name="publickey"></param>
        /// <returns></returns>
        public static bool VerifySign<T>(T data, string sign, string publickey)
        {
            var strJson = JsonHelper.Serialize(data);
            //公钥验证
            RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
            oRSA4.FromXmlString(publickey);
            bool bVerify = oRSA4.VerifyData(Encoding.UTF8.GetBytes(strJson), "SHA1", Encoding.UTF8.GetBytes(sign));
            return bVerify;
        }
    }
}
