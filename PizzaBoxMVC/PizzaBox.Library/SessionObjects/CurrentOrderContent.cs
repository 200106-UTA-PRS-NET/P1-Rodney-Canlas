using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.SessionObjects
{
    public static class CurrentOrderContent
    {
        public static List<Pizza> orderContent = new List<Pizza>();

        public static decimal totalCost = Convert.ToDecimal(0.00);
    }
}
