using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class registationsController : Controller
    {
        private doctorEntities db = new doctorEntities();

        // GET: registations
        public ActionResult Index()
        {
            var registations = db.registations.Include(r => r.dbo_section).Include(r => r.dbo_unuity);
            return View(registations.ToList());
        }

        // GET: registations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // GET: registations/Create
        public ActionResult Create()
        {
            ViewBag.sectıon_id = new SelectList(db.dbo_section, "id", "section");
            ViewBag.unıty_id = new SelectList(db.dbo_unuity, "id", "unity");
            return View();
        }

        // POST: registations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,sectıon_id,unıty_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.registations.Add(registation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sectıon_id = new SelectList(db.dbo_section, "id", "section", registation.sectıon_id);
            ViewBag.unıty_id = new SelectList(db.dbo_unuity, "id", "unity", registation.unıty_id);
            return View(registation);
        }

        // GET: registations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            ViewBag.sectıon_id = new SelectList(db.dbo_section, "id", "section", registation.sectıon_id);
            ViewBag.unıty_id = new SelectList(db.dbo_unuity, "id", "unity", registation.unıty_id);
            return View(registation);
        }

        // POST: registations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,sectıon_id,unıty_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sectıon_id = new SelectList(db.dbo_section, "id", "section", registation.sectıon_id);
            ViewBag.unıty_id = new SelectList(db.dbo_unuity, "id", "unity", registation.unıty_id);
            return View(registation);
        }

        // GET: registations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // POST: registations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registation registation = db.registations.Find(id);
            db.registations.Remove(registation);
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
