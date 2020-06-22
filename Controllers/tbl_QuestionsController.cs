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
using QuestionnaireAPI.Models;

namespace QuestionnaireAPI.Controllers
{
    public class tbl_QuestionsController : ApiController
    {
        private Questions db = new Questions();

        // GET: api/tbl_Questions
        [HttpGet]
        public IQueryable<tbl_Questions> Gettbl_Questions()
        {
            return db.tbl_Questions;
        }

        // GET: api/tbl_Questions/5
        [HttpGet]
        [ResponseType(typeof(tbl_Questions))]
        public IHttpActionResult Gettbl_Questions(long id)
        {
            tbl_Questions tbl_Questions = db.tbl_Questions.Find(id);
            if (tbl_Questions == null)
            {
                return NotFound();
            }

            return Ok(tbl_Questions);
        }

        // PUT: api/tbl_Questions/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Questions(long id, tbl_Questions tbl_Questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Questions.QuestionID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Questions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_QuestionsExists(id))
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

        // POST: api/tbl_Questions
        [HttpPost]
        [ResponseType(typeof(tbl_Questions))]
        public IHttpActionResult Posttbl_Questions(tbl_Questions tbl_Questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Questions.Add(tbl_Questions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Questions.QuestionID }, tbl_Questions);
        }

        // DELETE: api/tbl_Questions/5
        [HttpDelete]
        [ResponseType(typeof(tbl_Questions))]
        public IHttpActionResult Deletetbl_Questions(long id)
        {
            tbl_Questions tbl_Questions = db.tbl_Questions.Find(id);
            if (tbl_Questions == null)
            {
                return NotFound();
            }

            db.tbl_Questions.Remove(tbl_Questions);
            db.SaveChanges();

            return Ok(tbl_Questions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_QuestionsExists(long id)
        {
            return db.tbl_Questions.Count(e => e.QuestionID == id) > 0;
        }
    }
}