using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_APP.Models;

namespace MVC_APP.Controllers
{
    public class CoffeBarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CoffeBar
        public ActionResult Index()
        {
            return View(db.Bars.ToList());
        }

        // GET: CoffeBar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeBar coffeeBar = db.Bars.Find(id);
            if (coffeeBar == null)
            {
                return HttpNotFound();
            }
            return View(coffeeBar);
        }

        // GET: CoffeBar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeBar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Distance,WebPage,Url,Location,Rating")] CoffeeBar coffeeBar)
        {
            if (ModelState.IsValid)
            {
                db.Bars.Add(coffeeBar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeBar);
        }

        // GET: CoffeBar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeBar coffeeBar = db.Bars.Find(id);
            if (coffeeBar == null)
            {
                return HttpNotFound();
            }
            return View(coffeeBar);
        }

        // POST: CoffeBar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Distance,WebPage,Url,Location,Rating")] CoffeeBar coffeeBar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeBar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeBar);
        }

        // GET: CoffeBar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeBar coffeeBar = db.Bars.Find(id);
            if (coffeeBar == null)
            {
                return HttpNotFound();
            }
            return View(coffeeBar);
        }

        // POST: CoffeBar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeBar coffeeBar = db.Bars.Find(id);
            db.Bars.Remove(coffeeBar);
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
