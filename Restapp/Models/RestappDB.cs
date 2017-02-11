using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RestappDB : DbContext
    {
        public RestappDB() : base( "RestappDB" )
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantBranch> RestaurantBranches { get; set; }

        public DbSet<FoodType> FoodTypes { get; set; }

        public DbSet<FoodTypeRestaurant> FoodTypeRestaurants { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<RatingRestaurant> RatingRestaurants { get; set; }

        public DbSet<RestaurantType> RestaurantTypes { get; set; }
    }
}