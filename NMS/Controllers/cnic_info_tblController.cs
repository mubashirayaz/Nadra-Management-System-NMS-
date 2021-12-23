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
    public class cnic_info_tblController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();

        // GET: cnic_info_tbl
        public ActionResult Index()
        {
            return View(db.cnic_info_tbl.ToList());
        }

        // GET: cnic_info_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cnic_info_tbl cnic_info_tbl = db.cnic_info_tbl.Find(id);
            if (cnic_info_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cnic_info_tbl);
        }

        // GET: cnic_info_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cnic_info_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cnic_id,cnic_no,issue_day,issue_year,issue_month,expiry_year,expiry_month,expiry_date")] cnic_info_tbl cnic_info_tbl)
        {
            if (ModelState.IsValid)
            {
                db.cnic_info_tbl.Add(cnic_info_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cnic_info_tbl);
        }

        // GET: cnic_info_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cnic_info_tbl cnic_info_tbl = db.cnic_info_tbl.Find(id);
            if (cnic_info_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cnic_info_tbl);
        }

        // POST: cnic_info_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cnic_id,cnic_no,issue_day,issue_year,issue_month,expiry_year,expiry_month,expiry_date")] cnic_info_tbl cnic_info_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cnic_info_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cnic_info_tbl);
        }

        // GET: cnic_info_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cnic_info_tbl cnic_info_tbl = db.cnic_info_tbl.Find(id);
            if (cnic_info_tbl == null)
            {
                return HttpNotFound();
            }
            return View(cnic_info_tbl);
        }

        // POST: cnic_info_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cnic_info_tbl cnic_info_tbl = db.cnic_info_tbl.Find(id);
            db.cnic_info_tbl.Remove(cnic_info_tbl);
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
