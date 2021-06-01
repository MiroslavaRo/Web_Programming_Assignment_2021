using Web_Programming_Assignment_2021.Models.Blog;
using System.Collections.Generic;

namespace Web_Programming_Assignment_2021.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Categories = new List<CategoryViewModel>();
            Posts = new List<PostViewModel>();
        }

        public List<CategoryViewModel> Categories { get; internal set; }

        public List<PostViewModel> Posts { get; internal set; }

        public string UserName { get; set; }
    }
}