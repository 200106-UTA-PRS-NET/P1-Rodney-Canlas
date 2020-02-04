using System.ComponentModel.DataAnnotations;

namespace PizzaBox.WebUI.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name"), Required(ErrorMessage = "First Name must have a value.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required(ErrorMessage = "Last Name must have a value.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username must have a value.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Passphrase must have a value.")]
        public string Passphrase { get; set; }
       
    }
}
