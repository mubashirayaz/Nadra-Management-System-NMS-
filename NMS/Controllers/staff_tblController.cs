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
    public class staff_tblController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();

        // GET: staff_tbl
        public ActionResult Index()
        {
            var staff_tbl = db.staff_tbl.Include(s => s.cnic_info_tbl);
            return View(staff_tbl.ToList());
        }

        // GET: staff_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_tbl staff_tbl = db.staff_tbl.Find(id);
            if (staff_tbl == null)
            {
                return HttpNotFound();
            }
            return View(staff_tbl);
        }

        // GET: staff_tbl/Create
        public ActionResult Create()
        {
            ViewBag.cnic_id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no");
            return View();
        }

        // POST: staff_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staff_id,designation,contact_staff,cnic_id")] staff_tbl staff_tbl)
        {
            if (ModelState.IsValid)
            {
                db.staff_tbl.Add(staff_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cnic_id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", staff_tbl.cnic_id);
            return View(staff_tbl);
        }

        // GET: staff_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_tbl staff_tbl = db.staff_tbl.Find(id);
            if (staff_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.cnic_id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", staff_tbl.cnic_id);
            return View(staff_tbl);
        }

        // POST: staff_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staff_id,designation,contact_staff,cnic_id")] staff_tbl staff_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cnic_id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", staff_tbl.cnic_id);
            return View(staff_tbl);
        }

        // GET: staff_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_tbl staff_tbl = db.staff_tbl.Find(id);
            if (staff_tbl == null)
            {
                return HttpNotFound();
            }
            return View(staff_tbl);
        }

        // POST: staff_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff_tbl staff_tbl = db.staff_tbl.Find(id);
            db.staff_tbl.Remove(staff_tbl);
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
