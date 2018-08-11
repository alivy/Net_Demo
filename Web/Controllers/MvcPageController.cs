using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Webdiyer.WebControls.Mvc;

namespace Web.Controllers
{
    public class MvcPageController : Controller
    {
        MiaoEntities miao = new MiaoEntities();
        // GET: MvcPage
        public ActionResult Index()
        {
            return View();
        }
        // GET: MvcPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public ActionResult MvcPageList(int id = 1, int pageSize = 5)
        {
            return View(miao.User_info.OrderByDescending(s => s.UserID).ToPagedList(id, pageSize));
        }
        /// mvcPageList 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Mvc_PageList()
        {
            var t1 = miao.User_info.Where(t => t.Id > 5);



            return View();
        } 
        
    }
}