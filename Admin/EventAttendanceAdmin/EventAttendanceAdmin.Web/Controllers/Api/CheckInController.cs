using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EventAttendanceAdmin.Web.DAL;
using EventAttendanceAdmin.Web.Models;
using System.Web.Http.Cors;

namespace EventAttendanceAdmin.Web.Controllers.Api
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class CheckInController : ApiController
    {
        private EventContext db = new EventContext();
        [Authorize]
        public IQueryable<CheckIn> GetCheckIns()
        {
            return db.CheckIns.Include(x => x.Event);
        }

        [Authorize]
        public IQueryable<CheckIn> GetCheckIns(int eventId)
        {
            return db.CheckIns.Where(x => x.EventId == eventId).Include(x => x.Event);
        }

        [Authorize]
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult GetCheckIn(int id)
        {
            CheckIn checkIn = db.CheckIns.Find(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return Ok(checkIn);
        }

        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCheckIn(int id, CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkIn.CheckInId)
            {
                return BadRequest();
            }

            db.Entry(checkIn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckInExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult PostCheckIn([FromBody] CheckInDTO checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate event pin
            var e = db.Events.FirstOrDefault(x => x.Id == checkIn.EventId);
            if (e.Pin != null)
            {
                if (e.Pin != checkIn.Pin)
                {
                    return BadRequest("Invalid pin. Please check your entries and try again.");
                }
            }

            // Make sure this user hasn't already checked in
            var existing = db.CheckIns.FirstOrDefault(x => x.EventId == checkIn.EventId && x.StudentIdentifier == checkIn.StudentId);
            if (existing != null)
            {
                return BadRequest("You have already checked in to this event.");
            }

            var c = new CheckIn
            {
                CreateDate = DateTime.Now,
                EventId = checkIn.EventId,
                StudentIdentifier = checkIn.StudentId
            };
            db.CheckIns.Add(c);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c.CheckInId }, c);
        }

        [Authorize]
        [ResponseType(typeof(CheckIn))]
        public IHttpActionResult DeleteCheckIn(int id)
        {
            CheckIn checkIn = db.CheckIns.Find(id);
            if (checkIn == null)
            {
                return NotFound();
            }

            db.CheckIns.Remove(checkIn);
            db.SaveChanges();

            return Ok(checkIn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckInExists(int id)
        {
            return db.CheckIns.Count(e => e.CheckInId == id) > 0;
        }

    }
}