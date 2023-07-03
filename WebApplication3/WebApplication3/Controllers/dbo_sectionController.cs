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
    public class dbo_sectionController : Controller
    {
        private doctorEntities db = new doctorEntities();

        // GET: dbo_section
        public ActionResult Index()
        {
            return View(db.dbo_section.ToList());
        }

        // GET: dbo_section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_section dbo_section = db.dbo_section.Find(id);
            if (dbo_section == null)
            {
                return HttpNotFound();
            }
            return View(dbo_section);
        }

        // GET: dbo_section/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbo_section/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,section,room_number")] dbo_section dbo_section)
        {
            if (ModelState.IsValid)
            {
                db.dbo_section.Add(dbo_section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbo_section);
        }

        // GET: dbo_section/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_section dbo_section = db.dbo_section.Find(id);
            if (dbo_section == null)
            {
                return HttpNotFound();
            }
            return View(dbo_section);
        }

        // POST: dbo_section/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,section,room_number")] dbo_section dbo_section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbo_section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbo_section);
        }

        // GET: dbo_section/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dbo_section dbo_section = db.dbo_section.Find(id);
            if (dbo_section == null)
            {
                return HttpNotFound();
            }
            return View(dbo_section);
        }

        // POST: dbo_section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dbo_section dbo_section = db.dbo_section.Find(id);
            db.dbo_section.Remove(dbo_section);
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
