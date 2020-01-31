using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.WebUI.Models
{
    public class CompletedOrdersViewModel
    {

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime OrderDateTime { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Pizzas Ordered")]
        public List<Pizza> OrderContent { get; set; }
    }
}
