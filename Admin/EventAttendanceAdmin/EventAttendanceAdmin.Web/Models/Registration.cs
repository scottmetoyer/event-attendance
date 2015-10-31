using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        public int EventId { get; set; }
  
        public string StudentIdentifier { get; set; }

        public DateTime CreateDate { get; set; }
    }
}