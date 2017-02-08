using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RatingRestaurant
    {
        public int Id { get; set; }

        public int IdRestaurant { get; set; }

        public int IdUser { get; set; }

        [Range(0, 5)]
        public double Value { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}