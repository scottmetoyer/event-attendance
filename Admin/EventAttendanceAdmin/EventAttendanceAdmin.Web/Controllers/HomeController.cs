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
            return View();
        }

        public ActionResult Events(string filter)
        {
            ViewBag.Message = "Events";
            IEnumerable<Event> model;

            if (!string.IsNullOrEmpty(filter))
            {

            }

            model = db.Events;

            return View(model);
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        public ActionResult EditEvent(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEvent(string name, DateTime start, DateTime end, int pin)
        {
            return RedirectToAction("Events");
        }   
    }
}