using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils工具;

namespace Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://www.nbd.com.cn/zhuanti/yingxiang_tianfu/vote";
            string json = "{\"article_id\":\"1307553\",\"t\":\"ODcxMTAy\"}";
            string date = DateTime.Now.ToString("hh:MM:ss");
            string cookie = string.Format("_nbd_session_id ={0} ; domain =.nbd.com.cn; path =/; expires = Mon, 22 - Apr - 2019 {1} GMT; HttpOnly", Guid.NewGuid().ToString(), date);
            Dictionary<string, string> sHead = new Dictionary<string, string>();
            sHead.Add("ETag", Guid.NewGuid().ToString());
            sHead.Add("Set-Cookie", cookie);
            sHead.Add("X-Request-Id", Guid.NewGuid().ToString());
            sHead.Add("Server", "openresty");
            var result = RawPost(url, json, sHead, 1);
        }


        /// <summary>
        /// http的post请求
        /// </summary>
        /// <param name="sUrl">请求的地址</param>
        /// <param name="json">请求的参数</param>
        /// <param name="sHead">请求头</param>
        /// <param name="postType">请求类型，0：application/x-www-form-urlencoded，1：application/json，2：text/xml</param>
        public static string RawPost(string sUrl, string sBody, Dictionary<string, string> sHead = null, int? postType = 0, int iTimeoutSeconds = 30)
        {

            string sResult = string.Empty;
            string sError = string.Empty;
            string sResponseStatusCode = string.Empty;
            string sResponseStatusDescription = string.Empty;

            HttpWebResponse oHttpWebResponse = null;
            HttpWebRequest oHttpWebRequest = null;
            Stream oStream = null;
            StreamReader oStreamReader = null;

            byte[] bytes = Encoding.UTF8.GetBytes(sBody);


            try
            {
                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                oHttpWebRequest.KeepAlive = false;
                oHttpWebRequest.Method = "POST";
                switch (postType)
                {
                    case 0:
                        oHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        break;
                    case 1:
                        oHttpWebRequest.ContentType = "application/json;charset=utf-8";
                        break;
                    case 2:
                        oHttpWebRequest.ContentType = "text/xml";
                        break;
                    default:
                        oHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        break;
                }
                oHttpWebRequest.ContentLength = bytes.Length;
                //添加请求头
                if (sHead != null && sHead.Count > 0)
                {
                    foreach (var item in sHead)
                    {
                        oHttpWebRequest.Headers.Add(item.Key, item.Value);
                    }
                }

                oHttpWebRequest.Timeout = 1000 * iTimeoutSeconds;

                oStream = oHttpWebRequest.GetRequestStream();
                oStream.Write(bytes, 0, bytes.Length);
                oStream.Close();

                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                sResponseStatusDescription = oHttpWebResponse.StatusDescription;


                sResult = oStreamReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                sError += "!!Error: " + ex.Message + "\r\n";
                sError += "    Message: " + ex.Message + "\r\n";
                sError += "    InnerException: " + ex.InnerException + "\r\n";
                sError += "\r\n";
                sError += "    StackTrace: " + ex.StackTrace + "\r\n";

                Console.WriteLine(sError);
            }
            finally
            {
                oStream = null;
                if (oStream != null)
                {
                    oStream.Close();
                }
                if (oHttpWebRequest != null)
                {
                    oHttpWebRequest.Abort();
                }
                if (oHttpWebResponse != null)
                {
                    oHttpWebResponse.Close();
                }
                if (oStreamReader != null)
                {
                    oStreamReader.Close();
                }
            }
            Console.WriteLine(sError);
            return sResult;

        }
    }
}
