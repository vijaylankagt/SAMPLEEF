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
    public class ProductController : Controller
    {
        private AdventureWorksDW2019Entities1 db = new AdventureWorksDW2019Entities1();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.DimProductCategories.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryKey,ProductCategoryAlternateKey,EnglishProductCategoryName,SpanishProductCategoryName,FrenchProductCategoryName")] DimProductCategory dimProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.DimProductCategories.Add(dimProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimProductCategory);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryKey,ProductCategoryAlternateKey,EnglishProductCategoryName,SpanishProductCategoryName,FrenchProductCategoryName")] DimProductCategory dimProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimProductCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimProductCategory);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            if (dimProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(dimProductCategory);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(id);
            db.DimProductCategories.Remove(dimProductCategory);
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
