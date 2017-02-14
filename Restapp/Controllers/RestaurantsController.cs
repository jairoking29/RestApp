using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Restapp.Models;
using Restapp.Repositories;
using System.Collections.Generic;

namespace Restapp.Controllers
{
    [Authorize]
    public class RestaurantsController : Controller
    {
        private RestappDB db = new RestappDB();

        private List<RestaurantType> RestaurantTypes
        {
            get
            {
                return RepositoryHandler.RestaurantTypeRepository.GetAll();
            }
        }

        private List<FoodType> FoodTypes
        {
            get
            {
                return RepositoryHandler.FoodTypeRepository.GetAll();
            }
        }

        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        public ActionResult Create()
        {
            var hue = RestaurantTypes;
            ViewBag.RestaurantTypes = RestaurantTypes;
            ViewBag.FoodTypes = FoodTypes;
            return View(new Restaurant());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Phone,IdRestaurantType,FoodTypeIds")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                RepositoryHandler.FoodTypeRestaurantRepository.SaveFromRestaurant(restaurant);
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = RepositoryHandler.RestaurantRepository.GetWithFoodTypes(id ?? 0);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantTypes = RestaurantTypes;
            ViewBag.FoodTypes = FoodTypes;
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Phone,IdRestaurantType,FoodTypeIds")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                RepositoryHandler.FoodTypeRestaurantRepository.SaveFromRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
