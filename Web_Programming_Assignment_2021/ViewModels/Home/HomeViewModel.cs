using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Models;

namespace Web_Programming_Assignment_2021.ViewModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Posts = new List<Post>();
        }

        public List<Post> Posts { get; internal set; }

        public string UserName { get; set; }
    }
}
