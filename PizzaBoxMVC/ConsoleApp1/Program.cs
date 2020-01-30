using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            static List<string> Toppings()
            {
                return new List<string>()
            {
                "Cheese",
                "Vegetarian",
                "Pepperoni"
            };
            }

            List<string> toppings = Toppings();

            foreach (string topping in toppings)
            {
                Console.WriteLine(topping);
            }
        }
    }
}
