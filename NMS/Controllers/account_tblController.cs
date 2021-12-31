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
    public class account_tblController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();

        // GET: account_tbl
        public ActionResult Index()
        {
            var account_tbl = db.account_tbl.Include(a => a.invoice_tbl);
            return View(account_tbl.ToList());
        }

        // GET: account_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_tbl account_tbl = db.account_tbl.Find(id);
            if (account_tbl == null)
            {
                return HttpNotFound();
            }
            return View(account_tbl);
        }

        // GET: account_tbl/Create
        public ActionResult Create()
        {
            ViewBag.invoice_id = new SelectList(db.invoice_tbl, "invoice_id", "invoice_id");
            return View();
        }

        // POST: account_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "account_id,accound_No,invoice_id")] account_tbl account_tbl)
        {
            if (ModelState.IsValid)
            {
                db.account_tbl.Add(account_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.invoice_id = new SelectList(db.invoice_tbl, "invoice_id", "invoice_id", account_tbl.invoice_id);
            return View(account_tbl);
        }

        // GET: account_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_tbl account_tbl = db.account_tbl.Find(id);
            if (account_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.invoice_id = new SelectList(db.invoice_tbl, "invoice_id", "invoice_id", account_tbl.invoice_id);
            return View(account_tbl);
        }

        // POST: account_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "account_id,accound_No,invoice_id")] account_tbl account_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.invoice_id = new SelectList(db.invoice_tbl, "invoice_id", "invoice_id", account_tbl.invoice_id);
            return View(account_tbl);
        }

        // GET: account_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_tbl account_tbl = db.account_tbl.Find(id);
            if (account_tbl == null)
            {
                return HttpNotFound();
            }
            return View(account_tbl);
        }

        // POST: account_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account_tbl account_tbl = db.account_tbl.Find(id);
            db.account_tbl.Remove(account_tbl);
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
