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
    public class Vaccine_Controller : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();
        // GET: Vaccine_
        public ActionResult Index()
        {
            return View(db.Vaccination_Cif.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccination_Cif Vaccination_Cif = db.Vaccination_Cif.Find(id);
            if (Vaccination_Cif == null)
            {
                return HttpNotFound();
            }
            return View(Vaccination_Cif);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vac_ID,V_Name,R_Dose,D1_Date,D2_Date,Health_Center,Manufacture,Batch_NO#")] Vaccination_Cif Vaccination_Cif)
        {
            if (ModelState.IsValid)
            {
                db.Vaccination_Cif.Add(Vaccination_Cif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Vaccination_Cif);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccination_Cif Vaccination_Cif = db.Vaccination_Cif.Find(id);
            if (Vaccination_Cif == null)
            {
                return HttpNotFound();
            }
            return View(Vaccination_Cif);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vac_ID,V_Name,R_Dose,D1_Date,D2_Date,Health_Center,Manufacture,Batch_NO#")] Vaccination_Cif Vaccination_Cif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Vaccination_Cif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Vaccination_Cif);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccination_Cif Vaccination_Cif = db.Vaccination_Cif.Find(id);
            if (Vaccination_Cif == null)
            {
                return HttpNotFound();
            }
            return View(Vaccination_Cif);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccination_Cif Vaccination_Cif = db.Vaccination_Cif.Find(id);
            db.Vaccination_Cif.Remove(Vaccination_Cif);
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