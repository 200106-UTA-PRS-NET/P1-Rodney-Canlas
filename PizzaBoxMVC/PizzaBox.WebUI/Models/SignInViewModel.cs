using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.WebUI.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Username must have a value.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Passphrase must have a value.")]
        public string Passphrase { get; set; }
    }
}
