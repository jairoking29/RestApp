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
            var restaurant = _db.Restaurants.FirstOrDefault(r => r.Id == id);
            restaurant.FoodTypeIds = RepositoryHandler.FoodTypeRestaurantRepository
                .GetTable().Where(ftr => ftr.IdRestaurant == restaurant.Id).Select(ftr => ftr.IdFoodType).ToList();
            return restaurant;
        }
    }
}