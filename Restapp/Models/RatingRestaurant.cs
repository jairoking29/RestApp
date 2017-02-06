using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RatingRestaurant
    {
        public int Id { get; set; }

        public int IdRestaurant { get; set; }

        public int IdUser { get; set; }

        public double Value { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}