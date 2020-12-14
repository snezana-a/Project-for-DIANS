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

        /* READ FROM CSV FILE AND INPUT IN BASE
         * SOME ATTR ARE ADDED LATER
        public void readDb()
        {
            string csvData = System.IO.File.ReadAllText("C:\\Users\\Damchevski\\Desktop\\DizajnProekt\\Project-for-DIANS\\MVC APP\\MVC APP\\data\\readdata.txt");
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    CoffeeBar for_add = new CoffeeBar();
                    String disc = row.Split(',')[2].Split('.')[0];
                      for_add.Distance = (float)Convert.ToDouble(disc);
                      for_add.Name = row.Split(',')[1];
                      for_add.ImageUrl = "nema";
                      for_add.WebPage = "nema";
                      for_add.Location = "nema";
                      for_add.Rating = 0;

                    db.Bars.Add(for_add);
                    db.SaveChanges();
                }
            }

        }
        */

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
        public ActionResult Create([Bind(Include = "Id,Name,Distance,WebPage,ImageUrl,Location,Rating")] CoffeeBar coffeeBar)
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
        public ActionResult Edit([Bind(Include = "Id,Name,Distance,WebPage,ImageUrl,Location,Rating")] CoffeeBar coffeeBar)
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

        public class AlphabeticalComparer : IComparer<CoffeeBar>
        {
            public int Compare(CoffeeBar a, CoffeeBar b)
            {
                return String.Compare(a.Name, b.Name);
            }
        }

        public class RatingComparer : IComparer<CoffeeBar>
        {
            public int Compare(CoffeeBar a, CoffeeBar b)
            {
                return a.Rating.CompareTo(b.Rating);
            }
        }
        public ActionResult AlphabeticalSort()
        {
            List<CoffeeBar> all_bars = db.Bars.ToList();
            AlphabeticalComparer comparer = new AlphabeticalComparer();

            all_bars.Sort(comparer);

            return View("Index", all_bars);
        }

        public ActionResult RatingSort()
        {
            List<CoffeeBar> all_bars = db.Bars.ToList();
            RatingComparer comparer = new RatingComparer();

            all_bars.Sort(comparer);

            return View("Index",all_bars);
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
