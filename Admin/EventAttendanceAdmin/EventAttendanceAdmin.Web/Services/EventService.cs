using EventAttendanceAdmin.Web.DAL;
using EventAttendanceAdmin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Services
{
    public class EventService
    {
        private EventContext _context;

        public EventService(EventContext context)
        {
            _context = context;
        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event evt)
        {
            throw new NotImplementedException();
        }

        public Event GetEvent(int id) {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(Event evt)
        {
            throw new NotImplementedException();
        }
    }
}