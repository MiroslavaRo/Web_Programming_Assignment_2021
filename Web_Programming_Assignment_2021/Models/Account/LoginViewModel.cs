using System.ComponentModel.DataAnnotations;

namespace Web_Programming_Assignment_2021.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}