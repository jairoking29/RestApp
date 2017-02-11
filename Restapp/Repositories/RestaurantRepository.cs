using Restapp.Models;
using System.Data.Entity;
using System.Linq;

namespace Restapp.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository()
        {
            _table = _db.Restaurants;
        }

        public Restaurant GetWithFoodTypes(int id)
        {
            var restaurant = _db.Restaurants.Include(r => r.FoodTypeRestaurants).FirstOrDefault(r => r.Id == id);
            restaurant.FoodTypeIds = restaurant.FoodTypeRestaurants.Select(ftr => ftr.IdFoodType).ToList();
            return restaurant;
        }
    }
}