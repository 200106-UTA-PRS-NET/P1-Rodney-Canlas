﻿using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.WebUI.Models
{
    public class OrderHistoryViewModel 
    {
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime OrderDateTime { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Pizzas Ordered")]
        public List<Pizza> OrderContent { get; set; }
    }
}
