using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;
using System.Web.Http.Description;
using QuestionnaireAPI.Models;

namespace QuestionnaireAPI.Controllers
{
    public class tbl_OptionsController : ApiController
    {
        private Options db = new Options();

        // GET: api/tbl_Options
        [HttpGet]
        public IQueryable<tbl_Options> Gettbl_Options()
        {
            return db.tbl_Options;
        }

        // GET: api/tbl_Options/5
        [HttpGet]
        [ResponseType(typeof(tbl_Options))]
        public IHttpActionResult Gettbl_Options(long id)
        {
            tbl_Options tbl_Options = db.tbl_Options.Find(id);
            if (tbl_Options == null)
            {
                return NotFound();
            }

            return Ok(tbl_Options);
        }

        //Define custom route : Override default route as defined in WebApiConfig.cs
        [Route("api/tbl_Options/Gettbl_OptionsByQuestionId/{quesId}")]
        [HttpGet]
        [ResponseType(typeof(tbl_Options))]
        public IHttpActionResult Gettbl_OptionsByQuestionId(long quesId)
        {
            List<tbl_Options> tbl_Options = (List<tbl_Options>)(from res in db.tbl_Options where res.QuestionID == quesId select res).ToList();
            if (tbl_Options == null)
            {
                return NotFound();
            }

            return Ok(tbl_Options);
        }

        // PUT: api/tbl_Options/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Options(long id, tbl_Options tbl_Options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Options.OptionID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Options).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_OptionsExists(id))
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

        // POST: api/tbl_Options
        [HttpPost]
        [ResponseType(typeof(tbl_Options))]
        public IHttpActionResult Posttbl_Options(tbl_Options tbl_Options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Options.Add(tbl_Options);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Options.OptionID }, tbl_Options);
        }

        // DELETE: api/tbl_Options/5
        [HttpDelete]
        [ResponseType(typeof(tbl_Options))]
        public IHttpActionResult Deletetbl_Options(long id)
        {
            tbl_Options tbl_Options = db.tbl_Options.Find(id);
            if (tbl_Options == null)
            {
                return NotFound();
            }

            db.tbl_Options.Remove(tbl_Options);
            db.SaveChanges();

            return Ok(tbl_Options);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_OptionsExists(long id)
        {
            return db.tbl_Options.Count(e => e.OptionID == id) > 0;
        }
    }
}