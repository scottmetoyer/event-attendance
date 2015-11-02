using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventAttendanceAdmin.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Events";

            return View();
        }

        public ActionResult CheckIns()
        {
            ViewBag.Message = "Student Check-Ins";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}