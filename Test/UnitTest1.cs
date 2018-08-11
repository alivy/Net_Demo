using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using Utils工具;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        #region 初始化属性
        /// <summary>
        /// 方法名称
        /// </summary>
        public string FunctionName = "";
        /// <summary>
        /// 成功地址
        /// </summary>
        public string success_url = "";
        /// <summary>
        /// 失败地址
        /// </summary>
        public string fail_url = "";
        /// <summary>
        /// 忘记密码
        /// </summary>
        public string forget_pwd_url = "";
        /// <summary>
        /// 请求端口
        /// </summary>
        public int client = 1;
        //标的号
        public int id = 0;
        /// <summary>
        /// 数据包
        /// </summary>
        public string json = string.Empty;
        /// <summary>
        /// 用户id
        /// </summary>
        public int userId = 0;
        /// <summary>
        /// 签约金额
        /// </summary>
        public decimal signAmount = 0;


        #endregion
        public object obj = null;

        [TestInitialize]
        public void Initialization()
        {
            {
                #region 投标参数
                //FunctionName = "bid_apply";
                //client = 1;
                //id = 39286;
                //if (client == 1)
                //{
                //    success_url = ConstValue.PCIP + "/Product/ProductDetail?id=" + id;
                //    fail_url = ConstValue.PCIP + "/Product/ProductDetail?id=" + id;
                //    forget_pwd_url = ConstValue.PCIP + "/Account/SecureAuth";
                //}
                //else if (client == 2)
                //{
                //    success_url = ConstValue.AppIP + "/SRBank/CommonJump?url=1-" + ConstValue.AppIP + "/Member/MyInvest"; //ConstValue.AppIP + "/FinanceCenter/Index/";           //失败跳转地址
                //    fail_url = ConstValue.AppIP + "/SRBank/CommonJump?url=2-" + ConstValue.AppIP + "/FinanceCenter/Index";   //成功跳转地址
                //    forget_pwd_url = ConstValue.AppIP + "/SRBank/UpdateSetPwd";//忘记密码跳转链接
                //}

                //obj = new
                //{
                //    m_userId = 204455,
                //    inputNum = 4900.00M,
                //    redId = 0,
                //    lvBondId = 0,
                //    client = client,
                //    Id = id,
                //    success_url = success_url,
                //    fail_url = fail_url,
                //    forget_pwd_url = forget_pwd_url,
                //};
                //json ="{\"out_serial_no\":\"QST800002044550725201868475\",\"card_no\":\"86666882002001582893\",\"name\":\"\u90b1\u4e30\u751f\",\"asset_no\":\"39286\",\"bid_amount\":\"4900.00\",\"forcast_income\":\"0.00\",\"buy_date\":\"2018-07-25\",\"state\":\"1\",\"frozen_no\":\"18201807250000000656\",\"auth_code\":\"1532513120539093\",\"code\":\"RD000000\",\"third_custom\":\"\",\"msg\":\"\u4ea4\u6613\u6210\u529f\",\"service\":\"bid_apply_p\",\"version\":\"2.0.0\",\"uuid\":\"2018072518050050190\",\"sequence_id\":\"f558f7fb1d1e303db3a04f07df06da88\",\"custom\":\"\",\"encode\":\"UTF-8\",\"sign_type\":\"MD5\",\"timestamp\":\"1532513100\",\"client\":\"000001\",\"sign\":\"74108e33a218be98ed1158b4d919c6c1\"}";
                #endregion

            }
            {
                #region 放款
                //放款参数
                // json = "{\"payId\":\"39283\",\"service\":\"batch_payment\"}";
                //投标回调参数
                // json = "{\"out_serial_no\":\"QST800002044550723201868455\",\"card_no\":\"86666882002001582893\",\"name\":\"\u90b1\u4e30\u751f\",\"asset_no\":\"39283\",\"bid_amount\":\"2800.00\",\"forcast_income\":\"0.00\",\"buy_date\":\"2018-07-23\",\"state\":\"1\",\"frozen_no\":\"18201807230000000489\",\"auth_code\":\"1532344298612444\",\"code\":\"RD000000\",\"third_custom\":\"\",\"msg\":\"\u4ea4\u6613\u6210\u529f\",\"service\":\"bid_apply_p\",\"version\":\"2.0.0\",\"uuid\":\"201807231910211021194\",\"sequence_id\":\"bf5c38fc9cc45790f5d76e864b9b3bfa\",\"custom\":\"\",\"encode\":\"UTF-8\",\"sign_type\":\"MD5\",\"timestamp\":\"1532344221\",\"client\":\"000001\",\"sign\":\"b5a36ba0e7a17f0cd5bf3d0d5058c7a1\"}";
                //放款回调参数
                //json = "{\"code\":\"RD000000\",\"msg\":\"\u4ea4\u6613\u6210\u529f\",\"timestamp\":1532521562,\"encode\":\"UTF-8\",\"version\":\"2.0.0\",\"service\":\"batch_payment_b\",\"sign_type\":\"MD5\",\"sign\":\"81f4b29be9c5b8b0ce9004acd58b89df\",\"client\":\"000002\",\"sequence_id\":\"524ad76055b1f621f377c08a1bfcb0e6\",\"batch_no\":\"\",\"batch_count\":\"2\",\"batch_type\":\"001\",\"batch_date\":\"20180725\",\"items\":[{\"out_card_no\":\"86666882002001582893\",\"in_card_no\":\"86666882002001582992\",\"amount\":\"100.00\",\"assets_no\":\"39286\",\"serial_no\":\"QST800002044550725201868473\",\"auth_code\":\"1532513022709707\",\"reserved\":\"\",\"third_reserved\":\"QLD800002044550725201868473\",\"out_fee_mode\":\"0.00\",\"out_fee_amount\":\"0.00\",\"in_fee_mode\":\"0\",\"in_fee_amount\":\"0.00\",\"result\":\"00\",\"message\":\"\u6210\u529f\"},{\"out_card_no\":\"86666882002001582893\",\"in_card_no\":\"86666882002001582992\",\"amount\":\"4900.00\",\"assets_no\":\"39286\",\"serial_no\":\"QST800002044550725201868475\",\"auth_code\":\"1532513120539093\",\"reserved\":\"\",\"third_reserved\":\"QLD800002044550725201868475\",\"out_fee_mode\":\"0.00\",\"out_fee_amount\":\"0.00\",\"in_fee_mode\":\"0\",\"in_fee_amount\":\"0.00\",\"result\":\"00\",\"message\":\"\u6210\u529f\"}],\"uuid\":\"20180725202105215174\",\"custom\":\"\"}";
                #endregion
            }
            {
                #region 担保人还款投资人签约
                //FunctionName = "signWarrantor";
                //obj = new
                //{
                //    userId = 204454,
                //    client = 1,
                //    signAmount = 100000
                //};
                //json = "{\"card_no\":\"86666882002001583073\",\"out_serial_no\":\"20180724170959\",\"sign_flag\":\"having\",\"start_time\":\"1532361600\",\"end_time\":\"1690300799\",\"amount\":\"110000.00\",\"sign_date\":\"2018-07-24\",\"sign_time\":\"17:12:05\",\"code\":\"RD000000\",\"msg\":\"\u4ea4\u6613\u6210\u529f\",\"service\":\"sign_again_p\",\"version\":\"2.0.0\",\"uuid\":\"2018072417095995932\",\"sequence_id\":\"b554482b81682676671c05563dba1320\",\"custom\":\"204454\",\"encode\":\"UTF-8\",\"sign_type\":\"MD5\",\"timestamp\":\"1532423399\",\"client\":\"000001\",\"sign\":\"0de8b261073776e72a4c442c5527693e\"}";
                #endregion

                #region 担保人还款
                //FunctionName = "SecurityRepayment";
                //obj = new
                //{
                //    userId = 204454,
                //    loanId = 29591,
                //};
                
                #endregion


                #region 借款人还款投资人签约
                FunctionName = "signBorrower";
                obj = new
                {
                    userId = 204454,
                    client = 1
                };
                #endregion

                #region 借款人还款

                #endregion
            }
        }
        [TestMethod]
        ///投标测试
        public void TestMethod()
        {
            StreamWriter sw = new StreamWriter("", false, new UTF8Encoding(false));

            string value = DesEncrypt(FunctionName, obj);
            var result = Post("http://localhost:12784/Service/WebService", value);
            Logger.WirteLocalMessageLog(result);
            Assert.AreEqual(true, result.Contains("X000000"));
        }

        [TestMethod]
        public void TestMethodAnsyc()
        {
            var result = Post("http://localhost:12784/Home/AsyncBackService", json);
            Logger.WirteLocalMessageLog(result);
            Assert.AreEqual(true, result.Contains("success"));
        }




        #region 工具项
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DesEncrypt<T>(string FunctionName, T t,string UToken ="")
        {
            ReqParam data = new ReqParam
            {
                FunctionName = FunctionName,
                TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss"),
                MenKey = "57d99d89caab482aa0e9a0a803eed3ba",
                UUId = GenerateOrderNumber(),
                UToken = UToken,//"/4EBFkILB5KW6Fj4nnqhj8NdB8CPJ9j3Yjn+ke6iEacUZbeHeWdeEkqwI3du5rleALEhaM4Xp/e1VVee8yvgGuJB5M/bZSUrAfG4Cg6cM/Ry/e5xvxdPnkiIKl4oK8ropVwWGJ8/m2xqCv2wuvenT/zi+URi4t5/YivDSMRkWNQ=",
                CType = "2",
                DataContent = JsonHelper.Serialize(t)
            };
            return DESEncrypt.EncryptEncoding(JsonHelper.Serialize(data));
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DesDecrypt(string data)
        {
            return DESEncrypt.DecryptDecoding(data);
        }


        private static readonly object Locker = new object();
        /// <summary>
        /// 唯一Uuid号生成
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNumber()
        {
            //待优化。。异步多线程情况，但目前不会出现重复编号
            lock (Locker)
            {
                Thread.Sleep(50);
                string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssms");
                string strRandomResult = NextRandom(1000, 1).ToString();
                return strDateTimeNumber + strRandomResult;
            }
        }
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="numSeeds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int NextRandom(int numSeeds, int length)
        {

            byte[] randomNumber = new byte[length];

            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();

            rng.GetBytes(randomNumber);

            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }
            return (int)(randomResult % numSeeds) + 1;
        }


        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="iTimeoutSeconds"></param>
        /// <returns></returns>
        public string Post(string url, string json, int iTimeoutSeconds = 60)
        {
            WebResponse wResponse = null;
            Stream stream = null;
            StreamReader reader = null;
            string result = string.Empty;
            try
            {
                Uri uri = new Uri(url);
                byte[] byteArray = Encoding.UTF8.GetBytes(json); //转化
                HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(uri);
                wRequest.Method = "POST";
                wRequest.ContentType = "application/json;charset=UTF-8";
                wRequest.Accept = "application/json";
                wRequest.ContentLength = byteArray.Length;
                wRequest.Timeout = 1000 * iTimeoutSeconds;
                var reqTimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string MerchantNo = "Q201712231110351246589";
                wRequest.Headers.Add("MemberId", MerchantNo);
                stream = wRequest.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);//写入参数
                wResponse = (HttpWebResponse)wRequest.GetResponse();
                reader = new StreamReader(wResponse.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (wResponse != null)
                {
                    wResponse.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return result;
        }

        #endregion
    }
}
