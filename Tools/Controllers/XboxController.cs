using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tools.Controllers
{
    public class XboxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Games()
        {
            return View();
        }

        public ActionResult Games360()
        {
            return View();
        }

        public ActionResult Achievements(string id)
        {
            return View("Achievements", (object)id);
        }

        public ActionResult Achievements360(string id)
        {
            return View("Achievements360", (object)id);
        }

        public ActionResult DeadRising()
        {
            return View();
        }

        public ActionResult Halo()
        {
            return View();
        }

    }
}