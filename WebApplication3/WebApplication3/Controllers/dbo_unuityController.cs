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
    public class dbo_unuityController : Controller
    {
        private doctorEntities db = new doctorEntities();

        // GET: dbo_unuity
        public ActionResult Index()
        {
            return View(db.dbo_unuity.ToList());
        }

        // GET: dbo_unuity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_unuity dbo_unuity = db.dbo_unuity.Find(id);
            if (dbo_unuity == null)
            {
                return HttpNotFound();
            }
            return View(dbo_unuity);
        }

        // GET: dbo_unuity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbo_unuity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,unity,year")] dbo_unuity dbo_unuity)
        {
            if (ModelState.IsValid)
            {
                db.dbo_unuity.Add(dbo_unuity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbo_unuity);
        }

        // GET: dbo_unuity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_unuity dbo_unuity = db.dbo_unuity.Find(id);
            if (dbo_unuity == null)
            {
                return HttpNotFound();
            }
            return View(dbo_unuity);
        }

        // POST: dbo_unuity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,unity,year")] dbo_unuity dbo_unuity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbo_unuity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbo_unuity);
        }

        // GET: dbo_unuity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_unuity dbo_unuity = db.dbo_unuity.Find(id);
            if (dbo_unuity == null)
            {
                return HttpNotFound();
            }
            return View(dbo_unuity);
        }

        // POST: dbo_unuity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dbo_unuity dbo_unuity = db.dbo_unuity.Find(id);
            db.dbo_unuity.Remove(dbo_unuity);
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
