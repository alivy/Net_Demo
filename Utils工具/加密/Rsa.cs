using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具
{
   public class Rsa
    {
        /// <summary>
        /// rsa加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publickey"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(string content, string publickey)
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
            return result;
        }

        /// <summary>
        /// rsa解密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="privatekey"></param>
        /// <returns></returns>
        public static string RSADecrypt(byte[] content, string privatekey)
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
    }
}
