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
    public class Birth_Cirtificate_Controller : Controller
    {
        private NadraDbEntities3 db = new NadraDbEntities3();
        // GET: Birth_Cirtificate_
        public ActionResult Index()
        {
            return View(db.Birth_Cir.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birth_Cir Birth_Cir = db.Birth_Cir.Find(id);
            if (Birth_Cir == null)
            {
                return HttpNotFound();
            }
            return View(Birth_Cir);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "B_ID,A_CNIC,Relation,C_Name,F_Name,F_CNIC_No,M_Name,M_CNIC_No,Religion,P_Adrs,District,DOB")] Birth_Cir Birth_Cir)
        {
            if (ModelState.IsValid)
            {
                db.Birth_Cir.Add(Birth_Cir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Birth_Cir);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birth_Cir Birth_Cir = db.Birth_Cir.Find(id);
            if (Birth_Cir == null)
            {
                return HttpNotFound();
            }
            return View(Birth_Cir);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "B_ID,A_CNIC,Relation,C_Name,F_Name,F_CNIC_No,M_Name,M_CNIC_No,Religion,P_Adrs,District,DOB")] Birth_Cir Birth_Cir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Birth_Cir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Birth_Cir);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birth_Cir Birth_Cir = db.Birth_Cir.Find(id);
            if (Birth_Cir == null)
            {
                return HttpNotFound();
            }
            return View(Birth_Cir);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birth_Cir Birth_Cir = db.Birth_Cir.Find(id);
            db.Birth_Cir.Remove(Birth_Cir);
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