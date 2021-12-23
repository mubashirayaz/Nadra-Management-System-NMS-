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
    public class citizen_tblController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();

        // GET: citizen_tbl
        public ActionResult Index()
        {
            var citizen_tbl = db.citizen_tbl.Include(c => c.cnic_info_tbl);
            return View(citizen_tbl.ToList());
        }

        // GET: citizen_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizen_tbl citizen_tbl = db.citizen_tbl.Find(id);
            if (citizen_tbl == null)
            {
                return HttpNotFound();
            }
            return View(citizen_tbl);
        }

        // GET: citizen_tbl/Create
        public ActionResult Create()
        {
            ViewBag.Cnic_Id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no");
            return View();
        }

        // POST: citizen_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Citizen_id,F_name,curent_postal_code,Email,perm_house_no,year,month,date,phone_no,Cnic_Id")] citizen_tbl citizen_tbl)
        {
            if (ModelState.IsValid)
            {
                db.citizen_tbl.Add(citizen_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cnic_Id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", citizen_tbl.Cnic_Id);
            return View(citizen_tbl);
        }

        // GET: citizen_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizen_tbl citizen_tbl = db.citizen_tbl.Find(id);
            if (citizen_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cnic_Id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", citizen_tbl.Cnic_Id);
            return View(citizen_tbl);
        }

        // POST: citizen_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Citizen_id,F_name,curent_postal_code,Email,perm_house_no,year,month,date,phone_no,Cnic_Id")] citizen_tbl citizen_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citizen_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cnic_Id = new SelectList(db.cnic_info_tbl, "cnic_id", "cnic_no", citizen_tbl.Cnic_Id);
            return View(citizen_tbl);
        }

        // GET: citizen_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizen_tbl citizen_tbl = db.citizen_tbl.Find(id);
            if (citizen_tbl == null)
            {
                return HttpNotFound();
            }
            return View(citizen_tbl);
        }

        // POST: citizen_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            citizen_tbl citizen_tbl = db.citizen_tbl.Find(id);
            db.citizen_tbl.Remove(citizen_tbl);
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
