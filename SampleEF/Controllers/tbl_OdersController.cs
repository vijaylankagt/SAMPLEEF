using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleEF.Models;

namespace SampleEF.Controllers
{
    public class tbl_OdersController : Controller
    {
        private SampleEntities1 db = new SampleEntities1();

        // GET: tbl_Oders
        public ActionResult Index()
        {
            return View(db.tbl_Oders.ToList());
        }

        // GET: tbl_Oders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Oders tbl_Oders = db.tbl_Oders.Find(id);
            if (tbl_Oders == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Oders);
        }

        // GET: tbl_Oders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Oders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PId,ordername,Active")] tbl_Oders tbl_Oders)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Oders.Add(tbl_Oders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Oders);
        }

        // GET: tbl_Oders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Oders tbl_Oders = db.tbl_Oders.Find(id);
            if (tbl_Oders == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Oders);
        }

        // POST: tbl_Oders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PId,ordername,Active")] tbl_Oders tbl_Oders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Oders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Oders);
        }

        // GET: tbl_Oders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Oders tbl_Oders = db.tbl_Oders.Find(id);
            if (tbl_Oders == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Oders);
        }

        // POST: tbl_Oders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Oders tbl_Oders = db.tbl_Oders.Find(id);
            db.tbl_Oders.Remove(tbl_Oders);
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
