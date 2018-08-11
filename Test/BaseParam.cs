
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class ReqParam
    {
        /// <summary>
        /// 请求方法名称
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// #时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 商户唯一标识
        /// </summary>
        public string MenKey { get; set; }

        /// <summary>
        /// 请求唯一标识码(有客户端生成)
        /// </summary>
        public string UUId { get; set; }

        /// <summary>
        /// 用户凭证(登录Hash+用户Id+商户唯一标识+生成时间戳)
        /// </summary>
        public string UToken { get; set; }

        /// <summary>
        /// 客户端类型(0:网页 1:APP 2:微信)
        /// </summary>
        public string CType { get; set; }

        /// <summary>
        /// 数据包内容
        /// </summary>
        public string DataContent { get; set; }
    }

    /// <summary>
    /// 用户凭证
    /// </summary>
    public class UserToken
    {
        private string aes_key = "q*f+)t99";
        public UserToken() 
        { 

        }

        /// <summary>
        /// 解析用户凭证
        /// </summary>
        /// <param name="token">用户凭证</param>
        /// <param name="aes_key">商户公钥</param>
        public UserToken(string token)
        {
            if (string.IsNullOrEmpty(token)) { State = false; return; }
            string tokenJson = DESEncrypt.DecryptDecoding(token, aes_key);
            var obj = JsonHelper.Deserialize<UserToken>(tokenJson);

            if (obj != null)
            {
                this.MenKey = obj.MenKey;
                this.UId = obj.UId;
                this.TimeStamp = obj.TimeStamp;
                this.UserHash = obj.UserHash;
                State = true;
            }
            else
            {
                State = false;
            }
        }

        public UserToken(string MenKey, int UId, string TimeStamp, string UserHash)
        {
            this.MenKey = MenKey;
            this.UId = UId;
            this.TimeStamp = TimeStamp;
            this.UserHash = UserHash;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public string ToMD5String()
        {
            string json = JsonHelper.Serialize(this);
            return DESEncrypt.EncryptEncoding(json, aes_key);
        }

        /// <summary>
        /// 商户唯一标识
        /// </summary>
        public string MenKey { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UId { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// 用户登录Hash
        /// </summary>
        public string UserHash { get; set; }

        /// <summary>
        /// 解析状态(成功：true 失败:false)
        /// </summary>
        public bool State { get; private set; }
    }
}
