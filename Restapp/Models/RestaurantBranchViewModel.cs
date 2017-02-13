using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RestaurantBranchViewModel : RestaurantBranch
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}