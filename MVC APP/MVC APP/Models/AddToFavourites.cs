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
        public int Id { get; set; }
        public string BarName { get; set; }
        public string UserName { get; set; }
        public int BarId { get; set; }
        public string UserId { get; set; }

        public List<CoffeeBar> bars { get; set; }
        public int selectedCoffeeBar { get; set; }
        public AddToFavourites()

        {
            bars = new List<CoffeeBar>();
        }
    }
}