using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.WebUI.Models
{
    public class PizzaViewModel
    {
        public string Topping { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }

        public int Count { get; set; }
    }
}
