using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tools.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RuneScape()
        {
            return View();
        }
    }
}