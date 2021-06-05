using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Models;

namespace Web_Programming_Assignment_2021.ViewModels.Accounts
{
    public class DeleteViewModel
    {
        public User ProfileToBeDeleted{ get; set; }



        public bool ErrorMessageVisible { get; set; }
    }
}
