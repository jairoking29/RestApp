using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public static class RepositoryHandler
    {

        private static RestaurantRepository _restaurantRepository;
        public static RestaurantRepository RestaurantRepository
        {
            get
            {
                if (_restaurantRepository == null)
                {
                    _restaurantRepository = new RestaurantRepository();
                }
                return _restaurantRepository;
            }
        }

        private static RestaurantTypeRepository _restaurantTypeRepository;
        public static RestaurantTypeRepository RestaurantTypeRepository
        {
            get
            {
                if (_restaurantTypeRepository == null)
                {
                    _restaurantTypeRepository = new RestaurantTypeRepository();
                }
                return _restaurantTypeRepository;
            }
        }

        private static RestaurantBranchRepository _restaurantBranchRepository;
        public static RestaurantBranchRepository RestaurantBranchRepository
        {
            get
            {
                if (_restaurantBranchRepository == null)
                {
                    _restaurantBranchRepository = new RestaurantBranchRepository();
                }
                return _restaurantBranchRepository;
            }
        }

        private static FoodTypeRepository _foodTypeRepository;

        public static FoodTypeRepository FoodTypeRepository
        {
            get
            {
                if (_foodTypeRepository == null)
                {
                    _foodTypeRepository = new FoodTypeRepository();
                }
                return _foodTypeRepository;
            }
        }

        private static FoodTypeRestaurantRepository _foodTypeRestaurantRepository;

        public static FoodTypeRestaurantRepository FoodTypeRestaurantRepository
        {
            get
            {
                if (_foodTypeRestaurantRepository == null)
                {
                    _foodTypeRestaurantRepository = new FoodTypeRestaurantRepository();
                }
                return _foodTypeRestaurantRepository;
            }
        }
    }
}