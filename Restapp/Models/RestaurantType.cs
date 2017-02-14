using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class RestaurantType
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(128)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}