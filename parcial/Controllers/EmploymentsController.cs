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
    public class EmploymentsController : Controller
    {
        private UNFVPortfolioContext db = new UNFVPortfolioContext();

        // GET: Employments
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(e => e.Enterprise);
            return View(jobs.ToList());
        }

        // GET: Employments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Jobs.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // GET: Employments/Create
        public ActionResult Create()
        {
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name");
            return View();
        }

        // POST: Employments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmploymentID,Title,Description,Start,End,EnterpriseID")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(employment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", employment.EnterpriseID);
            return View(employment);
        }

        // GET: Employments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Jobs.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", employment.EnterpriseID);
            return View(employment);
        }

        // POST: Employments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmploymentID,Title,Description,Start,End,EnterpriseID")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnterpriseID = new SelectList(db.Clients, "EnterpriseID", "Name", employment.EnterpriseID);
            return View(employment);
        }

        // GET: Employments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Jobs.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employment employment = db.Jobs.Find(id);
            db.Jobs.Remove(employment);
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
