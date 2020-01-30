using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.Dependencies
{
    public static class PresetType
    {
        public static List<string> Toppings()
        {
            return new List<string>()
            {
                "Cheese",
                "Vegetarian",
                "Pepperoni"
            };
        }

        public static List<string> Crusts()
        {
            return new List<string>()
            {
                "Thin",
                "Thick"
            };
        }

        public static List<string> Sizes()
        {
            return new List<string>()
            {
                "Small",
                "Medium",
                "Large"
            };
        }
    }
}
