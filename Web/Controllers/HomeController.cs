using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            var a = Request["asc"];
            About();
            Request_A req = new Request_A();
            return View();
        }

        public ActionResult About()
        {
            var a = Request["asc"];
            ViewBag.Message = "Your application description page.";

            return Content("");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}