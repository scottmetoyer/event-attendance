using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        [Display(Name = "Event Start")]
        public DateTime Start { get; set; }

        [Display(Name = "Event End")]
        public DateTime End { get; set; }

        public int?  Pin { get; set; }

        public bool ValidateStudentId { get; set; }

        [JsonIgnore]
        public virtual ICollection<CheckIn> CheckIns { get; set; }
    }
}