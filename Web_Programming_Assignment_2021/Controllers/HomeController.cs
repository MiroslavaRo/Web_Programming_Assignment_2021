using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Data;
using Web_Programming_Assignment_2021.Models;
using Web_Programming_Assignment_2021.ViewModels;

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


        public ActionResult Details(int id)
        {
            Post post = context.Posts.Include(a => a.User).FirstOrDefault(a => a.PostId == id);

            return View(post);


        }

      //  [Authorize]
        public IActionResult Edit(int id)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Post post = context.Posts.FirstOrDefault(a => a.PostId == id);

            PostEditViewModel viewModel = new PostEditViewModel();
            viewModel.PostToBeEdited = post;


            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(PostEditViewModel viewModel)
        {
            if (!base.ModelState.IsValid)
            {
                viewModel.ErrorMessageVisible = true;
            }
            else
            {

                Post editedPost = viewModel.PostToBeEdited;

                Post originalPost = context.Posts.FirstOrDefault(a => a.PostId == editedPost.PostId);
                originalPost.Comment = editedPost.Comment;
                originalPost.Hashtag = editedPost.Hashtag;
                editedPost.PhotoFile = originalPost.PhotoFile;

                originalPost.DateModified= editedPost.DateModified= DateTime.Now;


                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        } 
        /*
        [Authorize]
        public IActionResult Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            createProductViewModel.Suppliers = GetSuppliers();

            return View(createProductViewModel);
        }


        [HttpPost]
        public IActionResult Create(CreateProductViewModel model, IFormFile photo)
        {
            ProductChange changeLog = new ProductChange();
            changeLog.CreatedBy = this.HttpContext.User.Identity.Name;
            changeLog.CreatedOn = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
            changeLog.EditedBy = changeLog.CreatedBy;
            changeLog.EditedOn = changeLog.CreatedOn;
            context.ProductChanges.Add(changeLog);
            context.SaveChanges();
            model.ProductChangeId = context.ProductChanges.First(a => a.CreatedOn == changeLog.CreatedOn).ProductChangeId;



            Product product = new Product();
            product.ProductName = model.ProductName;
            product.ProductChangeId = model.ProductChangeId;
            model.Suppliers = GetSuppliers();
            product.SupplierId = model.SelectedSupplierId;
            context.Products.Add(product);
            context.SaveChanges();


            if (photo != null)
            {
                model.ErrorMessageVisible = false;
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = configuration.GetValue<string>("ProductPhotosLocation");

                string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = string.Format("{0}.jpg", Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                context.Products.FirstOrDefault(a => a == product).ImageFileName = fileName;
                string filePath = Path.Combine(directoryPath, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }


                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }


        [Authorize]

        public ActionResult Delete(int id)
        {
            Product product = context.Products
                .Include(a => a.Supplier).Include(a => a.ProductChange)
               .FirstOrDefault(a => a.ProductId == id);

            return View(product);


        }
       

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            Product productToDelete = context.Products.Include(a => a.ProductChange).FirstOrDefault(a => a.ProductId == product.ProductId);
            ProductChange deletelog = context.ProductChanges.FirstOrDefault(a => a.ProductChangeId == productToDelete.ProductChangeId);

            string imagesPath = configuration.GetValue<string>("ProductPhotosLocation");

            string directoryPath = Path.Combine(imagesPath, product.ProductId.ToString());
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }
                Directory.Delete(directoryPath);
            }
            context.ProductChanges.Remove(deletelog);
            context.Products.Remove(productToDelete);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
        */
    }
}
