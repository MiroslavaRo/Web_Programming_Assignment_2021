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

namespace Web_Programming_Assignment_2021.Controllers
{
    public class HomeController : Controller
    {

        private CatstagramContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;
        
        private readonly ILogger<HomeController> logger;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IWebHostEnvironment hostEnvironment, CatstagramContext context)
        {
           this.logger = logger;
            
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment; 
        }
        public ActionResult Index()
        {
            List<Post> posts = context.Posts.Include(a => a.User).ToList();
            return View(posts);
        }

        public ActionResult Posts()
        {
            List<Post> posts = context.Posts.Include(a => a.User).ToList();
            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
