using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LayUIController : Controller
    {
        // GET: LayUI
        /// <summary>
        /// 父级弹窗
        /// </summary>
        /// <returns></returns>
        public ActionResult ParentPopup()
        {
            return View();
        }

        /// 子级弹窗
        /// </summary>
        /// <returns></returns>
        public ActionResult SonPopup()
        {
            return View();
        }
    }
}