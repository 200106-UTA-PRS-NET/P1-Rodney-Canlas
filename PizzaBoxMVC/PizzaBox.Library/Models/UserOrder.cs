using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.Models
{
    public class UserOrder
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public string OrderContent { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
