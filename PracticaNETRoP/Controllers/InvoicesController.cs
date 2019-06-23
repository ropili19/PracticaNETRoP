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
using PracticaNETRoP.Models;

namespace PracticaNETRoP.Controllers
{
    public class InvoicesController : ApiController
    {
        private VirtualShopEntities db = new VirtualShopEntities();

        // GET: api/Invoices
        public IQueryable<Invoices> GetInvoices()
        {
            return db.Invoices;
        }

        // GET: api/Invoices/5
        [ResponseType(typeof(Invoices))]
        public IHttpActionResult GetInvoices(int id)
        {
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return NotFound();
            }

            return Ok(invoices);
        }

        // PUT: api/Invoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvoices(int id, Invoices invoices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoices.Id)
            {
                return BadRequest();
            }

            db.Entry(invoices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesExists(id))
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

        // POST: api/Invoices
        [ResponseType(typeof(Invoices))]
        public IHttpActionResult PostInvoices(Invoices invoices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Invoices.Add(invoices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InvoicesExists(invoices.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = invoices.Id }, invoices);
        }

        // DELETE: api/Invoices/5
        [ResponseType(typeof(Invoices))]
        public IHttpActionResult DeleteInvoices(int id)
        {
            Invoices invoices = db.Invoices.Find(id);
            if (invoices == null)
            {
                return NotFound();
            }

            db.Invoices.Remove(invoices);
            db.SaveChanges();

            return Ok(invoices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvoicesExists(int id)
        {
            return db.Invoices.Count(e => e.Id == id) > 0;
        }
    }
}