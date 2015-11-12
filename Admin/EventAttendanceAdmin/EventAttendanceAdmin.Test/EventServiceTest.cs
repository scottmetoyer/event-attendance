using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventAttendanceAdmin.Web.Controllers;
using System.Web.Mvc;
using EventAttendanceAdmin.Web.Models;
using Moq;
using System.Data.Entity;
using EventAttendanceAdmin.Web.DAL;
using EventAttendanceAdmin.Web.Services;

namespace EventAttendanceAdmin.Test
{
    [TestClass]
    public class EventServiceTest
    {
        [TestMethod]
        public void CreateEvent_saves_event_via_context()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Event>>();
            var mockContext = new Mock<EventContext>();
            mockContext.Setup(m => m.Events).Returns(mockSet.Object);

            // Act
            var service = new EventService(mockContext.Object);
            service.CreateEvent(new Event { Name = "Test", Pin = 1234 });

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}