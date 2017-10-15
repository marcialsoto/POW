using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UNFV.Portfolio.Models;

namespace UNFV.Portfolio.Controllers
{
    public class EducationsController : Controller
    {
        private UNFVPortfolioContext db = new UNFVPortfolioContext();

        // GET: Educations
        public ActionResult Index()
        {
            var educations = db.Educations.Include(e => e.Degree).Include(e => e.Enterprise);
            return View(educations.ToList());
        }

        // GET: Educations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Name");
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name");
            return View();
        }

        // POST: Educations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationID,Career,Start,End,DegreeID,EnterpriseID")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Name", education.DegreeID);
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", education.EnterpriseID);
            return View(education);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Name", education.DegreeID);
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", education.EnterpriseID);
            return View(education);
        }

        // POST: Educations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EducationID,Career,Start,End,DegreeID,EnterpriseID")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "Name", education.DegreeID);
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", education.EnterpriseID);
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
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
