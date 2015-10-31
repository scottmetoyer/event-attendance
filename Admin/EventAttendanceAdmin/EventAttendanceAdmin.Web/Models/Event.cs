using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public byte[] QRCode { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}