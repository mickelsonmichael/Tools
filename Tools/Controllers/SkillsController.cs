using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tools.Models;

namespace Tools.Controllers
{
    public class SkillsController : Controller
    {
        public ActionResult Index()
        {
            return View(Skills.GetSkills("rens0n"));
            // TODO: Return the skills of the logged in user or redirect to a join page
        }

        public ActionResult Lookup(string username)
        {
            return View();
        }

        public PartialViewResult GetSkills(string username)
        {
            return PartialView(Skills.GetSkills(username));
        }
    }
}