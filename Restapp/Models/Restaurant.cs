using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public int IdRestaurantType { get; set; }

        public RestaurantType RestaurantType { get; set; }
    }
}