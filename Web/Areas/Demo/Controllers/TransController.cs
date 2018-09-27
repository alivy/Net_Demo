using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils工具;

namespace Web.Areas.Demo.Controllers
{
    public class TransController : Controller
    {
        // GET: Demo/Trans
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        private static Md5Algorithm instance;

        public static Md5Algorithm getInstance()
        {
            if (null == instance)
                return new Md5Algorithm();
            return instance;
        }
    }
}