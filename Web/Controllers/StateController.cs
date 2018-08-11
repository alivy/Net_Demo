using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            //BatchExtensions batch = new BatchExtensions();
            ////batch.Insert();
            //batch.Delete();
          return View();
        }
    }
}