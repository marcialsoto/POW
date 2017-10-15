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
    public class EnterprisesController : Controller
    {
        private UNFVPortfolioContext db = new UNFVPortfolioContext();

        // GET: Enterprises
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Enterprises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Clients.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // GET: Enterprises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enterprises/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnterpriseID,Name,URL,Logo")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(enterprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enterprise);
        }

        // GET: Enterprises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Clients.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // POST: Enterprises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnterpriseID,Name,URL,Logo")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enterprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enterprise);
        }

        // GET: Enterprises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enterprise enterprise = db.Clients.Find(id);
            if (enterprise == null)
            {
                return HttpNotFound();
            }
            return View(enterprise);
        }

        // POST: Enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enterprise enterprise = db.Clients.Find(id);
            db.Clients.Remove(enterprise);
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
