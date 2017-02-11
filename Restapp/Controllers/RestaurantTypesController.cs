using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restapp.Models;

namespace Restapp.Controllers
{
    public class RestaurantTypesController : Controller
    {
        private RestappDB db = new RestappDB();

        // GET: RestaurantTypes
        public ActionResult Index()
        {
            return View(db.RestaurantTypes.ToList());
        }

        // GET: RestaurantTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantType restaurantType = db.RestaurantTypes.Find(id);
            if (restaurantType == null)
            {
                return HttpNotFound();
            }
            return View(restaurantType);
        }

        // GET: RestaurantTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] RestaurantType restaurantType)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantTypes.Add(restaurantType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantType);
        }

        // GET: RestaurantTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantType restaurantType = db.RestaurantTypes.Find(id);
            if (restaurantType == null)
            {
                return HttpNotFound();
            }
            return View(restaurantType);
        }

        // POST: RestaurantTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] RestaurantType restaurantType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantType);
        }

        // GET: RestaurantTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantType restaurantType = db.RestaurantTypes.Find(id);
            if (restaurantType == null)
            {
                return HttpNotFound();
            }
            return View(restaurantType);
        }

        // POST: RestaurantTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantType restaurantType = db.RestaurantTypes.Find(id);
            db.RestaurantTypes.Remove(restaurantType);
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
