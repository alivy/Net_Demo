using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    public class BaseParam
    {
        /// <summary>
        /// 是否为Post请求
        /// </summary>
        public bool _IsPost { get; set; }

        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public string _IP { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string _MerchantNo { get; set; }

        /// <summary>
        /// #商户类型(1:PC端 2:移动端 3:后台)
        /// </summary>
        public int _MerchantType { get; set; }

        /// <summary>
        /// 服务端私钥
        /// </summary>
        public string PrivateKey { get; set; }
        /// <summary>
        /// 服务端公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 数据包内容
        /// </summary>
        public string _DataContent { get; set; }

        /// <summary>
        /// 异步回调方法名称
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// 异步回调Id
        /// </summary>
        public int Id { get; set; }

    }

    public class R_MerchantInfo
    {
        /// <summary>
        /// #自动编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// #商户号
        /// </summary>
        public string MerchantNo { get; set; }
        /// <summary>
        /// #商户类型(1:PC端 2:移动端 3:后台)
        /// </summary>
        public int MerchantType { get; set; }
        /// <summary>
        /// #客户端私钥
        /// </summary>
        public string ClientPrivateKey { get; set; }
        /// <summary>
        /// #客户端公钥
        /// </summary>
        public string ClientPublicKey { get; set; }
        /// <summary>
        /// #服务端私钥
        /// </summary>
        public string ServerPrivateKey { get; set; }
        /// <summary>
        /// #服务端公钥
        /// </summary>
        public string ServerPublicKey { get; set; }
        /// <summary>
        /// #支出金额
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// #添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// #备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// #异步通知地址
        /// </summary>
        public string AsynAddress { get; set; }
    }
}
