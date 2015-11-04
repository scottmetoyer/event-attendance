using EventAttendanceAdmin.Web.DAL;
using EventAttendanceAdmin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventAttendanceAdmin.Web.Controllers
{
    public class HomeController : Controller
    {
        private EventContext db = new EventContext();

        public ActionResult Index()
        {
            var activeEvents = db.Events.Take(5).ToList();
            var upcomingEvents = db.Events.Take(5).ToList();
            var model = new HomeViewModel { ActiveEvents = activeEvents, UpcomingEvents = upcomingEvents };

            return View(model);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}