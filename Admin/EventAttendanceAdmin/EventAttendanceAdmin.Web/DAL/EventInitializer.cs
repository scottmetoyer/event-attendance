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
                new Event { Name = "Coffee Social", Location="The Hub", Pin = 1234, Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Zumba", Location="Recreation Center Room 101", Pin = 2222,Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "How to Win Friends and Influence People", Location="Hub 302",Pin = 3455, Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Career Workshop", Location="Career Center", Pin = 1111, Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Weight Training", Location="Recreation Center Weightroom", Pin = 2126, Start = new DateTime(2016, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 7, 0, 0) },
                new Event { Name = "Technology in the Classroom", Location="Technology Workshop", Pin = 2222, Start = new DateTime(2016, 2, 1, 6, 0, 0), End = new DateTime(2016, 2, 1, 8, 0, 0) },
                new Event { Name = "Oil Painting 101", Location="Arts Buidling Room 1152", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Parent Teacher Conference", Location="Coffee Bean", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "College Roadmap", Location="Career Center Workshop Room 15", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
                new Event { Name = "Tour the Botanic Gardens", Location="The Botanic Gardens", Start = new DateTime(2015, 1, 1, 6, 0, 0), End = new DateTime(2016, 1, 1, 6, 0, 0) },
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