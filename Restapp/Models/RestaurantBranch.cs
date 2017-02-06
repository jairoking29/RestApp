using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RestaurantBranch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdRestaurant { get; set; }

        public int IdLocation { get; set; }

        public string Phone { get; set; }

        public Restaurant Restaurant { get; set; }

        public Location Location { get; set; }
    }
}