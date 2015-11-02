using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EventAttendanceAdmin.Web.Models;

namespace EventAttendanceAdmin.Web.DAL
{
    public class EventInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            var events = new List<Event>
            {
                new Event { Name = "Coffee Social", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Zumba", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "How to Win Friends and Influence People", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Career Workshop", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Weight Training", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Technology in the Classroom", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Oil Painting 101", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Parent Teacher Conference", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "College Roadmap", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Tour the Botanic Gardens", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
            };

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var checkins = new List<CheckIn> {
                new CheckIn { EventId = 1, StudentIdentifier = "860000001", CreateDate = DateTime.Now },
                new CheckIn { EventId = 2, StudentIdentifier = "860000002", CreateDate = DateTime.Now },
                new CheckIn { EventId = 3, StudentIdentifier = "860000003", CreateDate = DateTime.Now },
                new CheckIn { EventId = 4, StudentIdentifier = "860000004", CreateDate = DateTime.Now },
                new CheckIn { EventId = 5, StudentIdentifier = "860000005", CreateDate = DateTime.Now },
                new CheckIn { EventId = 6, StudentIdentifier = "860000006", CreateDate = DateTime.Now },
                new CheckIn { EventId = 7, StudentIdentifier = "860000007", CreateDate = DateTime.Now },
                new CheckIn { EventId = 8, StudentIdentifier = "860000008", CreateDate = DateTime.Now },
                new CheckIn { EventId = 9, StudentIdentifier = "860000009", CreateDate = DateTime.Now },
                new CheckIn { EventId = 10, StudentIdentifier = "860000010", CreateDate = DateTime.Now },
                new CheckIn { EventId = 1, StudentIdentifier = "860000001", CreateDate = DateTime.Now },
                new CheckIn { EventId = 2, StudentIdentifier = "860000002", CreateDate = DateTime.Now },
                new CheckIn { EventId = 3, StudentIdentifier = "860000003", CreateDate = DateTime.Now },
                new CheckIn { EventId = 4, StudentIdentifier = "860000004", CreateDate = DateTime.Now },
                new CheckIn { EventId = 5, StudentIdentifier = "860000005", CreateDate = DateTime.Now },
                new CheckIn { EventId = 6, StudentIdentifier = "860000006", CreateDate = DateTime.Now },
                new CheckIn { EventId = 7, StudentIdentifier = "860000007", CreateDate = DateTime.Now },
                new CheckIn { EventId = 8, StudentIdentifier = "860000008", CreateDate = DateTime.Now },
                new CheckIn { EventId = 9, StudentIdentifier = "860000009", CreateDate = DateTime.Now },
                new CheckIn { EventId = 10, StudentIdentifier = "860000010", CreateDate = DateTime.Now },
            };

            checkins.ForEach(c => context.CheckIns.Add(c));
            context.SaveChanges();
        }
    }
}