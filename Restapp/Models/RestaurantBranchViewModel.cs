using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    [NotMapped]
    public class RestaurantBranchViewModel : RestaurantBranch
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public void SetLocation()
        {
            if (Location == null)
            {
                Location = new Location();
            }
            Location.Id = IdLocation;
            Location.Latitude = Latitude;
            Location.Longitude = Longitude;
        }

        public RestaurantBranch GetRestaurantBranch()
        {
            var restaurantBranch = new RestaurantBranch();
            SetLocation();
            restaurantBranch.Id = Id;
            restaurantBranch.Location = Location;
            restaurantBranch.Name = Name;
            restaurantBranch.Phone = Phone;
            restaurantBranch.IdRestaurant = IdRestaurant;
            restaurantBranch.IdLocation = IdLocation;
            return restaurantBranch;
        }

        public RestaurantBranchViewModel() : base()
        {
            SetLocation();
        }

        public RestaurantBranchViewModel(RestaurantBranch rb)
        {
            Id = rb.Id;
            IdRestaurant = rb.IdRestaurant;
            IdLocation = rb.IdLocation;
            Name = rb.Name;
            Phone = rb.Phone;
            if (rb.Location != null)
            {
                Location = rb.Location;
                Latitude = rb.Location.Latitude;
                Longitude = rb.Location.Longitude;
            }
        }
    }
}