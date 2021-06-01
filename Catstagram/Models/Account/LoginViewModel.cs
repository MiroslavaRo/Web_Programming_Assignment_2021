using System.ComponentModel.DataAnnotations;

namespace Catstagram.Models.Account
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