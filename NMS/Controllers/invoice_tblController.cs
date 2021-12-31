using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NMS.Models;

namespace NMS.Controllers
{
    public class invoice_tblController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();

        // GET: invoice_tbl
        public ActionResult Index()
        {
            return View(db.invoice_tbl.ToList());
        }

        // GET: invoice_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice_tbl invoice_tbl = db.invoice_tbl.Find(id);
            if (invoice_tbl == null)
            {
                return HttpNotFound();
            }
            return View(invoice_tbl);
        }

        // GET: invoice_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: invoice_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "invoice_id,invoice_no")] invoice_tbl invoice_tbl)
        {
            if (ModelState.IsValid)
            {
                db.invoice_tbl.Add(invoice_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice_tbl);
        }

        // GET: invoice_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice_tbl invoice_tbl = db.invoice_tbl.Find(id);
            if (invoice_tbl == null)
            {
                return HttpNotFound();
            }
            return View(invoice_tbl);
        }

        // POST: invoice_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "invoice_id,invoice_no")] invoice_tbl invoice_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice_tbl);
        }

        // GET: invoice_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            invoice_tbl invoice_tbl = db.invoice_tbl.Find(id);
            if (invoice_tbl == null)
            {
                return HttpNotFound();
            }
            return View(invoice_tbl);
        }

        // POST: invoice_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            invoice_tbl invoice_tbl = db.invoice_tbl.Find(id);
            db.invoice_tbl.Remove(invoice_tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
