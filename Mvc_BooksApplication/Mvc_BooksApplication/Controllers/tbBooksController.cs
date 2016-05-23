using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_BooksApplication;

namespace Mvc_BooksApplication.Controllers
{
    public class tbBooksController : Controller
    {
        private DbBooksEntities db = new DbBooksEntities();

        // GET: tbBooks
        public ActionResult Index()
        {
            return View(db.tbBooks.ToList());
        }

        // GET: tbBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBooks tbBooks = db.tbBooks.Find(id);
            if (tbBooks == null)
            {
                return HttpNotFound();
            }
            return View(tbBooks);
        }

        // GET: tbBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,Author,Publisher,Price")] tbBooks tbBooks)
        {
            if (ModelState.IsValid)
            {
                db.tbBooks.Add(tbBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbBooks);
        }

        // GET: tbBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBooks tbBooks = db.tbBooks.Find(id);
            if (tbBooks == null)
            {
                return HttpNotFound();
            }
            return View(tbBooks);
        }

        // POST: tbBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,Author,Publisher,Price")] tbBooks tbBooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbBooks);
        }

        // GET: tbBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbBooks tbBooks = db.tbBooks.Find(id);
            if (tbBooks == null)
            {
                return HttpNotFound();
            }
            return View(tbBooks);
        }

        // POST: tbBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbBooks tbBooks = db.tbBooks.Find(id);
            db.tbBooks.Remove(tbBooks);
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
