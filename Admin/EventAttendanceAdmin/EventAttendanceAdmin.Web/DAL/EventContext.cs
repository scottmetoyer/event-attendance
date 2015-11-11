using EventAttendanceAdmin.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventAttendanceAdmin.Web.DAL
{
    public class EventContext : DbContext
    {
        public EventContext() : base("EventContext") { }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<CheckIn> CheckIns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}