using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name..."), MaxLength(256)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password..."), DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required(ErrorMessage = "Please Confirm Password...")]
        public string ConfirmPassword { get; set; }

        public bool ErrorMessageVisible { get; set; }

      //  public IFormFile Avatar { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Please Enter Email...")]
        public string Email { get; set; }
       // public string Message { get; set; }

    }
}
