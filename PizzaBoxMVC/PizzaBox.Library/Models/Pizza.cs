using System.Collections.Generic;

namespace PizzaBox.Library.Models
{
    public class Pizza
    {
        public string PizzaType { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}
