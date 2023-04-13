using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiByMVC.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }

        [StringLength(maximumLength:30, MinimumLength = 2)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string Message { get; set; }

        
    }
}