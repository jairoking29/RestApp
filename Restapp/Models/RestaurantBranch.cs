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

        [Display(Name = "Nombre")]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "Restaurante")]
        public int IdRestaurant { get; set; }

        [Display(Name = "Ubicación")]
        public int IdLocation { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(16)]
        public string Phone { get; set; }


        public Restaurant Restaurant { get; set; }

        public Location Location { get; set; }
    }
}