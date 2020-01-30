using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.SessionObjects
{
    public static class CurrentUser
    {
        public static bool isAdmin { get; set; }
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Passphrase { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
    }
}
