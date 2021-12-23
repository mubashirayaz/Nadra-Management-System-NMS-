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
    public class B_FormController : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();
        // GET: B_Form
        public ActionResult Index()
        {
            return View(db.B_Form.ToList());
        }

        // GET: B_Form/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            B_Form B_Form = db.B_Form.Find(id);
            if (B_Form == null)
            {
                return HttpNotFound();
            }
            return View(B_Form);
        }

        // GET: B_Form/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BForm_ID,Gender,C_Name,F_Name,F_CNIC_No,M_Name,M_CNIC_No,District,DOB")] B_Form B_Form)
        {
            if (ModelState.IsValid)
            {
                db.B_Form.Add(B_Form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(B_Form);
        }

        // GET: B_Form/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            B_Form B_Form = db.B_Form.Find(id);
            if (B_Form == null)
            {
                return HttpNotFound();
            }
            return View(B_Form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BForm_ID,Gender,C_Name,F_Name,F_CNIC_No,M_Name,M_CNIC_No,District,DOB")] B_Form B_Form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(B_Form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(B_Form);
        }

        // GET: B_Form/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            B_Form B_Form = db.B_Form.Find(id);
            if (B_Form == null)
            {
                return HttpNotFound();
            }
            return View(B_Form);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            B_Form B_Form = db.B_Form.Find(id);
            db.B_Form.Remove(B_Form);
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