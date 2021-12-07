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
    public class login_tblController : Controller
    {
        private NadraDbContext db = new NadraDbContext();

        // GET: login_tbl
        public ActionResult Index()
        {
            var login_tbl = db.login_tbl.Include(l => l.staff_tbl);
            return View(login_tbl.ToList());
        }

        // GET: login_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login_tbl login_tbl = db.login_tbl.Find(id);
            if (login_tbl == null)
            {
                return HttpNotFound();
            }
            return View(login_tbl);
        }

        // GET: login_tbl/Create
        public ActionResult Create()
        {
            ViewBag.staff_id = new SelectList(db.staff_tbl, "staff_id", "designation");
            return View();
        }

        // POST: login_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "login_id,login_email,login_password,staff_id")] login_tbl login_tbl)
        {
            if (ModelState.IsValid)
            {
                db.login_tbl.Add(login_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.staff_id = new SelectList(db.staff_tbl, "staff_id", "designation", login_tbl.staff_id);
            return View(login_tbl);
        }

        // GET: login_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login_tbl login_tbl = db.login_tbl.Find(id);
            if (login_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.staff_id = new SelectList(db.staff_tbl, "staff_id", "designation", login_tbl.staff_id);
            return View(login_tbl);
        }

        // POST: login_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "login_id,login_email,login_password,staff_id")] login_tbl login_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.staff_id = new SelectList(db.staff_tbl, "staff_id", "designation", login_tbl.staff_id);
            return View(login_tbl);
        }

        // GET: login_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login_tbl login_tbl = db.login_tbl.Find(id);
            if (login_tbl == null)
            {
                return HttpNotFound();
            }
            return View(login_tbl);
        }

        // POST: login_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            login_tbl login_tbl = db.login_tbl.Find(id);
            db.login_tbl.Remove(login_tbl);
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
