using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class FoodTypeRestaurant
    {
        public int Id { get; set; }

        public int IdFoodType { get; set; }

        public int IdRestaurant { get; set; }

        public Restaurant Restaurant { get; set; }

        public FoodType FoodType { get; set; }
    }
}