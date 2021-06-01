using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Data;
using Web_Programming_Assignment_2021.Models;
using Web_Programming_Assignment_2021.Models.Home;
using Web_Programming_Assignment_2021.Services.Interfaces;

namespace Web_Programming_Assignment_2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CatstagramContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;

        private readonly ILogger<HomeController> logger;
        private readonly IBlogService blogService;
        public HomeController(ILogger<HomeController> logger, CatstagramContext context, IBlogService blogService, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;

            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
            this.blogService = blogService;
        }
        public ActionResult Index()
        {
            //  List<Post> posts = context.Posts.Include(a => a.User).ToList();
            //return View(posts);
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.UserName = User.Identity.Name;

            homeViewModel.Categories = blogService.GetCategories();

            homeViewModel.Posts = blogService.GetPosts();

            return View(homeViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
