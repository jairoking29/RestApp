using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RestaurantBranch
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public int IdRestaurant { get; set; }

        public int IdLocation { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        public Restaurant Restaurant { get; set; }

        public Location Location { get; set; }
    }
}