﻿using System.ComponentModel.DataAnnotations;

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
