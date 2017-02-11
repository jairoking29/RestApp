using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public class FoodTypeRestaurantRepository : BaseRepository<FoodTypeRestaurant>
    {
        public FoodTypeRestaurantRepository()
        {
            _table = _db.FoodTypeRestaurants;
        }

        public void SaveFromRestaurant(Restaurant restaurant)
        {
            if (restaurant.FoodTypeIds.Count > 0)
            {
                foreach (var foodTypeId in restaurant.FoodTypeIds)
                {
                    FoodType foodType = RepositoryHandler.FoodTypeRepository.Get(foodTypeId);
                    if (foodType != null)
                    {
                        var foodTypeRestaurant = new FoodTypeRestaurant()
                        {
                            IdFoodType = foodTypeId,
                            IdRestaurant = restaurant.Id
                        };
                        Save(foodTypeRestaurant);
                    }
                }
            }
        }
    }
}