using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.SessionObjects
{
    public class CurrentStore
    {
        public static int Id { get; set; }
        public static string StoreName { get; set; }
        public static string City { get; set; }
        public static string State { get; set; }
        public static int Zipcode { get; set; }
    }
}
