using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebAppCore.Models;

namespace WebAppCore.Controllers
{
    public class HomeController : Controller
    {
        [Route("home/About")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// 获取广告/banner/公告
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// <see cref="AdvertisingModel" langword="true"/>
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAd(AdLocation type)
        {
            var adv = new AdvertisingModel();
            if (type.Equals(AdLocation.Home)) {
                adv.AdName = "测试";
            }
            return Json(type);
        }
    }
}
