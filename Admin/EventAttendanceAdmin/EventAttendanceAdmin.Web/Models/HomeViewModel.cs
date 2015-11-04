using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class HomeViewModel
    {
        public List<Event> ActiveEvents { get; set; }

        public List<Event> UpcomingEvents { get; set; }
    }
}