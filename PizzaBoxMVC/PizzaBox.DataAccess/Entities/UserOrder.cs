﻿using System;

namespace PizzaBox.DataAccess.Entities
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
