using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class CheckInDTO
    {
        public int EventId { get; set; }
        public string StudentId { get; set; }
        public int Pin { get; set; }
    }
}