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
using FinalProjectSocialzR.Models;

namespace FinalProjectSocialzR.Controllers
{
    public class SavedSocialMessagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();               

        // GET: api/SavedSocialMessages
        public IQueryable<SavedSocialMessage> GetSavedSocialMessages()
        {
            return db.SavedSocialMessages;
        }

        // GET: api/SavedSocialMessages/5
        [ResponseType(typeof(SavedSocialMessage))]
        public IHttpActionResult GetSavedSocialMessage(int id)
        {
            SavedSocialMessage savedSocialMessage = db.SavedSocialMessages.Find(id);
            if (savedSocialMessage == null)
            {
                return NotFound();
            }

            return Ok(savedSocialMessage);
        }

        // PUT: api/SavedSocialMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSavedSocialMessage(int id, SavedSocialMessage savedSocialMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedSocialMessage.Id)
            {
                return BadRequest();
            }

            db.Entry(savedSocialMessage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedSocialMessageExists(id))
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

        // POST: api/SavedSocialMessages
        [ResponseType(typeof(SavedSocialMessage))]
        public IHttpActionResult PostSavedSocialMessage(SavedSocialMessage savedSocialMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //savedSocialMessage.PostTimeStamp = DateTime.Now;
            db.SavedSocialMessages.Add(savedSocialMessage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = savedSocialMessage.Id }, savedSocialMessage);
        }

        // DELETE: api/SavedSocialMessages/5
        [ResponseType(typeof(SavedSocialMessage))]
        public IHttpActionResult DeleteSavedSocialMessage(int id)
        {
            SavedSocialMessage savedSocialMessage = db.SavedSocialMessages.Find(id);
            if (savedSocialMessage == null)
            {
                return NotFound();
            }

            db.SavedSocialMessages.Remove(savedSocialMessage);
            db.SaveChanges();

            return Ok(savedSocialMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SavedSocialMessageExists(int id)
        {
            return db.SavedSocialMessages.Count(e => e.Id == id) > 0;
        }
    }
}