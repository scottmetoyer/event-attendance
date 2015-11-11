using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventAttendanceAdmin.Web.Controllers;
using System.Web.Mvc;
using EventAttendanceAdmin.Web.Models;

namespace EventAttendanceAdmin.Test
{
    [TestClass]
    public class EventControllerTest
    {
        [TestMethod]
        public void TestIndexView()
        {
        }

        public void TestDetailView()
        {
        }

        public void TestCreateView() { }

        public void TestEditView()
        {

        }

        public void TestDeleteView() { }

        [TestMethod]
        public void TestPrintView()
        {
            var controller = new EventController();
            var result = controller.Print(2) as ViewResult;
            var evt = (Event)result.ViewData.Model;
            Assert.AreEqual("Zumba", evt.Name);
        }
    }
}