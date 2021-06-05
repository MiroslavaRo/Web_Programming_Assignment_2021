using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Models;

namespace Web_Programming_Assignment_2021.ViewModels.Accounts
{
    public class EditProfileViewModel
    {
        public User ProfileToBeEdited { get; set; }
        public IFormFile AvatarChange { get; set; }

        [Required(ErrorMessage = "Please Enter Password..."), DataType(DataType.Password)]
        public string Password { get; set; }


        public bool SuccessMessageVisible { get; set; }
        public bool ErrorMessageVisible { get; set; }
    }
}
