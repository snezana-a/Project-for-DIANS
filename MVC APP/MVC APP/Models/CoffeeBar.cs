using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class CoffeeBar
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public float Distance { get; set; }
        public string WebPage { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public float Rating { get; set; }
    }
}