using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.WebUI.Models
{
    public class StoreViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}
