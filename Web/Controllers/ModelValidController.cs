using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils工具.Model验证;
using Web.Models;

namespace Web.Controllers
{
    public class ModelValidController : Controller
    {
        // GET: ModelValid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToModelValid(PeopleModel people)
        {
            var valid = people.GetModelValid();
            if (valid.IsValid)
                return Json("验证成功");
            else
                return Json(valid.ErrorMessage);
        }

        private ActionResult ModelStateCheck()
        {
            string msg = string.Empty;
            var iValid = ModelState.IsValid;
            if (!iValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var modelstate = ModelState[key];
                    if (modelstate.Errors.Any())
                    {
                        var modelFrist = modelstate.Errors.FirstOrDefault();
                        msg = modelFrist == null ? "" : modelFrist.ErrorMessage;
                    }
                }
            }
            return Json(msg);
        }

    }

}