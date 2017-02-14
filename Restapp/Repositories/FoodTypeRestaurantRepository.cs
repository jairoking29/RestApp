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
            if (restaurant?.FoodTypeIds != null && restaurant.FoodTypeIds.Count > 0)
            {
                var savedFoodTypeRestaurants = GetByRestaurantReturningDictionary(restaurant.Id);
                foreach (var foodTypeId in restaurant.FoodTypeIds)
                {
                    if (!savedFoodTypeRestaurants.ContainsKey(foodTypeId))
                    {
                        var foodTypeRestaurant = new FoodTypeRestaurant()
                        {
                            IdFoodType = foodTypeId,
                            IdRestaurant = restaurant.Id
                        };
                        Save(foodTypeRestaurant);
                    }
                }

                foreach (var foodTypeRestaurant in savedFoodTypeRestaurants)
                {
                    if (!restaurant.FoodTypeIds.Contains(foodTypeRestaurant.Key))
                    {
                        Delete(foodTypeRestaurant.Value.Id);
                    }
                }
            }
        }

        public FoodTypeRestaurant GetByRestaurantAndFoodType(int idRestaurant, int idFoodType)
        {
            return _table.FirstOrDefault(ftr => ftr.IdRestaurant == idRestaurant && ftr.IdFoodType == idFoodType);
        }

        public List<FoodTypeRestaurant> GetByRestaurant(int idRestaurant)
        {
            return _table.Where(ftr => ftr.IdRestaurant == idRestaurant).ToList();
        }

        public Dictionary<int, FoodTypeRestaurant> GetByRestaurantReturningDictionary(int idRestaurant)
        {
            return GetByRestaurant(idRestaurant).ToDictionary(ftr => ftr.IdFoodType);
        }
    }
}