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

namespace EventAttendanceAdmin.Web.Controllers
{
    public class CheckInController : ApiController
    {
        private EventContext db = new EventContext();

        public IQueryable<CheckIn> GetCheckIns()
        {
            return db.CheckIns.Include(x => x.Event);
        }

        public IQueryable<CheckIn> GetCheckIns(int eventId)
        {
            return db.CheckIns.Where(x => x.EventId == eventId).Include(x => x.Event);
        }

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
        public IHttpActionResult PostCheckIn(CheckIn checkIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CheckIns.Add(checkIn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = checkIn.CheckInId }, checkIn);
        }

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