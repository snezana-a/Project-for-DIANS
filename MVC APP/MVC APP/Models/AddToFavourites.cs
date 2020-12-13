using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_APP.Models
{
    public class AddToFavourites
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string BarName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int BarId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string UserId { get; set; }

        public List<CoffeeBar> bars { get; set; }
        [Required(ErrorMessage = "Required")]
        public int selectedCoffeeBar { get; set; }
        public AddToFavourites()

        {
            bars = new List<CoffeeBar>();
        }
    }
}