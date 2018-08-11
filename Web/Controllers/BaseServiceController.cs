using MyCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Utils工具;

namespace Web.Controllers
{
    public class BaseServiceController : Controller
    {
        public BaseParam param;

        /// <summary>
        /// 日志信息 
        /// </summary>
        public StringBuilder _Log = new StringBuilder();

        public R_MerchantInfo merchantInfo { get; set; }

        ///// <summary>
        ///// 客户端私钥
        ///// </summary>
        //public static string C_PrivateKey = "<RSAKeyValue><Modulus>suCVyly+MpH+ijswoe7nQDASNdE5G/9TMqeNH1bIhQ1JxPAuNAg0hk3HSYE0aCchSCqwZpyQrgdqqLakW/O0l/80gCpt+hqGqfVKeP/WTg+PI5GadUbZqNobsyVhjf2wUs+vIANt0Fw9DusY5KwlGfzCq2f+IkL+cK/Z3S/DwGU=</Modulus><Exponent>AQAB</Exponent><P>7QZJnxOPwqigESxuLtJYO6+zdqEw1jakXrwhB7aDVbn3yBdUnsDdWVoDFNQu9h9iBIxyhYsMVU6HOdQrt18tGw==</P><Q>wTKYWf3XuYgypsljPT2RlrKmATmnxP1Xv5EMOOwAPtfm96G73hCErgAy+HfvfOmL+d6qtb+Buj3+VWi2AUsgfw==</Q><DP>P6y+vnN83Wh7h+GNwBpWBcLPzYDEI+gOBD06Cl5nrfIFtMU/wF5DmKtrxH60Fv6bUGmCoomWSJyOC2UKUXrKHQ==</DP><DQ>fY7ENLgkWw+I25xGQqag16+C84jk38FGJdm+d7/o6O6nzIfv8IILuImolpJbsnKV5e4wQ64SQVfI0vkaT/zjQQ==</DQ><InverseQ>Wu/WeSX5OtiGKgkYimDw4KRdL1Ly/y/2mXEuV/g7L7Gmv4dBT3xzHyc8EzAkEnxt4jZz4dlnNdpdtdehiB7NsA==</InverseQ><D>scp9t5Q0y2jGubgZH2qoWOkuwGUDQWum0vssTlDgnzZU8zTSh478Pd1CzjFo2HjEIMmlaWgGeaMPhT9735U8EgfOAC8J1wUfRv9DjAhaMTmIshujkuIcmrJUlEqHA5710OAobsgZ5aPjkS/rn74V3ThA6CRQHWaAvPY+ccav+aU=</D></RSAKeyValue>";
        ///// <summary>
        ///// 客户端公钥
        ///// </summary>
        //public static string C_PublicKey = "<RSAKeyValue><Modulus>3e63d2nR8DdlLYBr6RMH4QlC75w4hJXPyU7dfINZu4etIZRcH1kWJUpMFZ+4HZdj71BuvAq9WxtJpLa6LcrNsNce6EgAEBW3Re0+xGWgOC27Gx1yNXULI7rvPlzoQw6x41CFei57qFcFf5hR02HYT8ggiw6BVHjvEJ4Ma1VceWE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        ///// <summary>
        ///// 服务端私钥
        ///// </summary>
        //public static string S_PrivateKey = "<RSAKeyValue><Modulus>3e63d2nR8DdlLYBr6RMH4QlC75w4hJXPyU7dfINZu4etIZRcH1kWJUpMFZ+4HZdj71BuvAq9WxtJpLa6LcrNsNce6EgAEBW3Re0+xGWgOC27Gx1yNXULI7rvPlzoQw6x41CFei57qFcFf5hR02HYT8ggiw6BVHjvEJ4Ma1VceWE=</Modulus><Exponent>AQAB</Exponent><P>8alhXnG0Hd+ptLbAodhEXe6QRvLmMCGS98ewpC8cK2t+etdPUSX4NhEejWmjsZEmN2jtNTRO2NEYEMzmBsHG7Q==</P><Q>6xmrIOkP98e7+cHQFNpAl1sq9QuMNIVgfQwZpbdSO0WiqaE2V9yWfru59xMwwHgjEz2Lk+9WxZ8Ojx72665ZxQ==</Q><DP>Rhj9t2l/95JjJZpFMi0LV7vVed8HSjrS6LCx2k4X+7hIjdVamo1K/FPm6toTs3QJA9WZyO8NV/L+6hClQJyA2Q==</DP><DQ>Fi8N3sUfJJpMOnz3TYBqp92KaCT2zd3oBOSnZuOtdrpTZv43SoMeEEdWfOHqr76mUKJ2ETd8UJl5njelxQdmoQ==</DQ><InverseQ>3WINh7LY9Td8g3PfcB18C1j2vb6VoIX0pYKXeTMe0Td5VwY4aEfC1tGbewtccssSVTcXalIrI875+dEhpSTcKQ==</InverseQ><D>NJ4OXX93SM65bEpQS1g5u/7oIcsWE0k5lG7gUE8MDUwjnhyAouYKPBkbZN0TV+C2ztxxBKA/OMSFd0njZkv47A1rjfZKSnSRTwdTEpncvWsaZjMbsRnHxzI3/BMtke+rDl5HTAoBJjSx3drz2uWcXduN/5r2lSg0guG/ckK96mE=</D></RSAKeyValue>";
        ///// <summary>
        ///// 服务端公钥
        ///// </summary>
        //public static string S_PublicKey = "<RSAKeyValue><Modulus>tlldJPL+5pvqmSOzzAlBQ9mck/RgS67SZkQKNAvVJWFnia6OAlrT1nfx6S0HlwoDzLeRkf+DQL3Js+Wm/rkvD3HNiVQSbifegqPf6WnIWxLazBN96hymQbYuf/7Pqqw5fD5xBnLatfhT72Wf1BWeGJee3sawpgcKnUZMxGP4Oo8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        /// <summary>
        /// 客户端私钥
        /// </summary>
        public static string C_PrivateKey = "";
        /// <summary>
        /// 客户端公钥
        /// </summary>
        public static string C_PublicKey = "";

        /// <summary>
        /// 服务端私钥
        /// </summary>
        public static string S_PrivateKey = "";
        /// <summary>
        /// 服务端公钥
        /// </summary>
        public static string S_PublicKey = "";

        /// <summary>
        /// 方法名称
        /// </summary>
        public string _FunctionName = string.Empty;

        /// <summary>
        /// 数据内容
        /// </summary>
        public string _DataContent = string.Empty;


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            param = new BaseParam();
            param._IP = WebHelper.GetIP();
            param._IsPost = WebHelper.IsPost();
            param._MerchantNo = requestContext.HttpContext.Request.Headers.Get("MerchantNo");
        }


        /// <summary>
        /// 重写权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //不能应用在子方法上
            if (filterContext.IsChildAction)
                return;

            //测试去掉home/Index
            var controller = RouteData.Values["controller"].ToString().ToLower();
            var action = RouteData.Values["action"].ToString().ToLower();
            if (action == "uploadimage")
                return;

            if (!param._IsPost)
            {
                //请求方式非"POST"
                filterContext.Result = Content(error("无效请求！", "X0001"));
                return;
            }

            if (string.IsNullOrWhiteSpace(param._MerchantNo))
            {
                //商户号信息错误
                filterContext.Result = Content(error("无效请求！", "X0002"));
                return;
            }

            if (string.IsNullOrWhiteSpace(param._MerchantNo))
            {
                //商户号信息错误
                filterContext.Result = Content(error("无效请求！", "X0003"));
                return;
            }

            param._MerchantNo = param._MerchantNo.ToUpper();
            //merchantInfo = new BLL.R_MerchantInfoBll().FirstOrDefault(m => m.MerchantNo == param._MerchantNo, m => m.Id, false);
            //if (merchantInfo == null)
            //{
            //    //商户号信息错误
            //    filterContext.Result = Content(error("无效请求！", "X0004"));
            //    return;
            //}

            param._MerchantType = merchantInfo.MerchantType;

            C_PrivateKey = merchantInfo.ClientPrivateKey;
            C_PublicKey = merchantInfo.ClientPublicKey;

            S_PrivateKey = merchantInfo.ServerPrivateKey;
            S_PublicKey = merchantInfo.ServerPublicKey;

            param.PrivateKey = merchantInfo.ServerPrivateKey;
            param.PublicKey = merchantInfo.ServerPublicKey;

            _DataContent = GetInputParamStream();
            //#if DEBUG
            //            //_DataContent = Convert.ToBase64String(SRBank.Base.Communication.RSAEncrypt(_DataContent, C_PublicKey));
            //#endif
            //判断密文是否为空
            if (string.IsNullOrWhiteSpace(_DataContent))
            {
                //密文为空
                filterContext.Result = Content(error("请求的内容错误！", "X0002"));
                return;
            }

            param._DataContent = Rsa.RSADecrypt(Convert.FromBase64String(_DataContent), S_PrivateKey);
            if (string.IsNullOrWhiteSpace(param._DataContent))
            {
                //请求密文错误
                filterContext.Result = Content(error("请求的内容错误！", "X0002"));
                return;
            }

            object requestData = JsonConvert.DeserializeObject<object>(param._DataContent);


            //if (requestData == null || string.IsNullOrWhiteSpace(requestData.service))
            //{

            //}

            //_FunctionName = requestData.service;

            if (_FunctionName == "error")
            {
                //请求方法名错误
                filterContext.Result = Content(error("请求的方法错误！", "X0003"));
                return;
            }
            if (string.IsNullOrWhiteSpace(param._DataContent))
            {
                //请求数据内容不允许为空
                filterContext.Result = Content(error("请求的数据包为空！", "X0004"));
                return;
            }

            //判断是否为用户登录过程
            if (action == "userservice")
            {

            }
            else
            {
#if DEBUG
                param._DataContent = DESEncrypt.EncryptEncoding(param._DataContent);
#endif
                param._DataContent = GetDecrypt(param._DataContent);
            }
            if (param._DataContent == "error")
            {
                filterContext.Result = Content(error("请求的内容包，解析失败！", "X0009"));
                return;
            }
        }


        /// <summary>
        /// 异常返回
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Logger.WriteException(filterContext.Exception);
        }

        /// <summary>
        /// 错误请求结果
        /// </summary>
        /// <param name="state">返回的描述</param>
        /// <param name="content">返回的代码</param>
        /// <returns></returns>
        protected string error(string msg, string code = "X9999")
        {
            var res = new 
            {
                service = _FunctionName,
                code = code,
                msg = msg
            };

            var backJson = JsonHelper.Serialize(res);

            _Log.AppendLine("返回信息：" + backJson);
            Logger.WirteMessageLog(_Log.ToString());
            return backJson;
        }

        /// <summary>
        /// 成功请求结果
        /// </summary>
        /// <param name="mode">成功后返回的数据</param>
        /// <param name="msg">返回的描述</param>
        /// <param name="code">返回的代码</param>
        /// <returns></returns>
        protected string Success(object mode, string msg = "请求成功！", string code = "X0000")
        {
            var res = new 
            {
                code = code,
                msg = msg
            };
            var backJson = JsonHelper.Serialize(res.ToString());
            _Log.AppendLine("返回信息：" + backJson);
            Logger.WirteMessageLog(_Log.ToString());
            return backJson;
        }


        /// 字符串解密
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        protected string GetDecrypt(string strContent, string sKey = null)
        {
            string strRel = string.Empty;
            try
            {
                if (sKey == null)
                {
                    strRel = DESEncrypt.DecryptDecoding(strContent);
                }
                else
                {
                    strRel = DESEncrypt.DecryptDecoding(strContent, sKey);
                }
            }
            catch
            {
                return "error";
            }
            return strRel;
        }

        /// <summary>
        /// 获取传入参数
        /// </summary>
        /// <returns></returns>
        protected string GetInputParamStream()
        {
            System.IO.Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            string json = Encoding.UTF8.GetString(b);
            StringBuilder strLog = new StringBuilder();
            strLog.AppendLine("**********获取外部json***************");
            strLog.AppendLine("接收json数据为" + json);
            strLog.AppendLine("**********获取外部json***************");
            Logger.WirteMessageLog(strLog.ToString());
            return json;
        }

        /// <summary>
        /// 接收参数方式
        /// </summary>
        /// <returns></returns>
        public string InputStream()
        {
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            Logger.AddLog("通过input Stream中读取byte数据" + Encoding.UTF8.GetString(b).ToString());

            var para = System.Web.HttpContext.Current.Request.Form;
            Logger.AddLog("读取提交表单数据:" + para);

            var para_s = System.Web.HttpContext.Current.Request.Params;
            Logger.AddLog("读取提交字符:" + para_s);

            var result = string.Empty;
            var res_s = string.Empty;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                result = reader.ReadToEnd();
                Logger.AddLog("流的方式接收数据:" + result);

                string Url_res = System.Web.HttpUtility.UrlDecode(result); //解码
                Logger.AddLog("解码:" + Url_res);
                reader.Close();
                //转JSON
                if (Url_res != null && Url_res != "")
                {
                    string result_json = Url_res.Substring(Url_res.IndexOf('{'));
                    Logger.AddLog("取json数据:" + result_json);
                    Object res = JsonConvert.DeserializeObject<Object>(result_json);
                    //string retCode = res.retCode == null ? "" : res.retCode.ToString();
                    Logger.AddLog("编码前:" + res);
                }
                Logger.AddLine(2);
                //string retCode = System.Web.HttpContext.Current.Request.Params["retCode"] == null ? "" : System.Web.HttpContext.Current.Request.Params["retCode"].ToString();
                //string retCode_S = System.Web.HttpContext.Current.Request.Params["retCode"] == null ? "" : System.Web.HttpContext.Current.Request.Params["retCode"].ToString();

                //AddLog("retcode表单数据" + retCode_S);
                //AddLog(para.ToString());
                //AddLine(2);    
            }
           
            return result;
        }



    }
}