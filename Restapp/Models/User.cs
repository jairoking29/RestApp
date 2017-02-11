using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restapp.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [StringLength(256)]
        public string PasswordSalt { get; set; }
    }
}