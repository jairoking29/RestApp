using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Restapp.Models
{
    public class RestaurantBranchesController : Controller
    {
        private RestappDB db = new RestappDB();

        // GET: RestaurantBranches
        public ActionResult Index()
        {
            return View(db.RestaurantBranches.ToList());
        }

        // GET: RestaurantBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantBranch restaurantBranch = db.RestaurantBranches.Find(id);
            if (restaurantBranch == null)
            {
                return HttpNotFound();
            }
            return View(restaurantBranch);
        }

        // GET: RestaurantBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IdRestaurant,IdLocation,Phone")] RestaurantBranch restaurantBranch)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantBranches.Add(restaurantBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantBranch);
        }

        // GET: RestaurantBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantBranch restaurantBranch = db.RestaurantBranches.Find(id);
            if (restaurantBranch == null)
            {
                return HttpNotFound();
            }
            return View(restaurantBranch);
        }

        // POST: RestaurantBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdRestaurant,IdLocation,Phone")] RestaurantBranch restaurantBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantBranch);
        }

        // GET: RestaurantBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantBranch restaurantBranch = db.RestaurantBranches.Find(id);
            if (restaurantBranch == null)
            {
                return HttpNotFound();
            }
            return View(restaurantBranch);
        }

        // POST: RestaurantBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantBranch restaurantBranch = db.RestaurantBranches.Find(id);
            db.RestaurantBranches.Remove(restaurantBranch);
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
