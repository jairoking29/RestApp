﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class FoodType
    {
         
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(1024)]
        public string Description { get; set; }

        public List<FoodTypeRestaurant> FoodTypeRestaurants { get; set; }
    }
}