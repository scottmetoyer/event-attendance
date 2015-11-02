using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class CheckIn
    {
        public int CheckInId { get; set; }

        public int EventId { get; set; }
  
        public string StudentIdentifier { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual Event Event { get; set; }
    }
}