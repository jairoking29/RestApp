using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(1024)]
        public string Description { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(16)]
        public string Phone { get; set; }

        [Display(Name = "Tipo de restaurante")]
        public int IdRestaurantType { get; set; }


        [Display(Name = "Tipo de restaurante")]
        public RestaurantType RestaurantType { get; set; }

        [Display(Name = "Tipo de comida")]
        public List<FoodTypeRestaurant> FoodTypeRestaurants { get; set; }

        [NotMapped]
        public List<FoodType> FoodTypes { get; set; }

        [NotMapped]
        public List<int> FoodTypeIds { get; set; }
    }
}