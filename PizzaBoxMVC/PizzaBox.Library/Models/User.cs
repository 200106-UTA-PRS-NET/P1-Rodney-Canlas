using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Passphrase { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
