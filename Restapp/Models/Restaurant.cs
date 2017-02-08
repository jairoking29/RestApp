using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        public int IdRestaurantType { get; set; }

        public RestaurantType RestaurantType { get; set; }
    }
}