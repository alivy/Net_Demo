using MyCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils工具;

namespace Web.Controllers
{
    public class UserServiceController : BaseServiceController
    {
        // GET: UserService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserService()
        {
            var strRel = string.Empty;
            try
            {
                InvokeInfo vkInfo = ReflectionHelper.GetActionInvokeInfo(_FunctionName);
                if (vkInfo == null)
                {
                    strRel = error("请求的方法错误！", "X0008");
                }
                else
                {
                    strRel = (string)ActionExecutor.ExecuteAction(param, vkInfo);
                }
            }
            catch (Exception e)
            {
                strRel = error(_FunctionName, e.Message);
            }
            _Log.AppendLine("返回信息：" + strRel);
            Logger.WirteMessageLog(_Log.ToString());

            var strRel2 = RSAHelper.RSAEncrypt(strRel, param.PublicKey);
            return Content(strRel2);
        }
    }
}