using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Catstagram.Models.Blog;
using Catstagram.Services.Interfaces;
using Catstagram.Models.Home;

namespace Catstagram.Controllers
{
    public class AdminController : Controller
    {
        #region Private fields and constructor

        private readonly IBlogService blogService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public AdminController(IBlogService blogService, IWebHostEnvironment hostingEnvironment)
        {
            this.blogService = blogService;
            this.hostingEnvironment = hostingEnvironment;
        }

        #endregion Private fields and constructor

        public IActionResult Index()
        {

            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.UserName = User.Identity.Name;

            homeViewModel.Categories = blogService.GetCategories();

            homeViewModel.Posts = blogService.GetPosts();

            return View(homeViewModel);
        }

        public IActionResult Categories()
        {
            // 1. Get list of all categories
            var categories = blogService.GetCategories();

            // 2. Render page
            return View(categories);
        }

        public IActionResult EditCategory(int? id)
        {
            // 1. Get post details
            // If parameter id is null or 0 then we will provide an empty view model, to indicate Create new post mode, otherwise we will get Post by ID from Database
            var post = new CategoryViewModel();

            if (id != null && id > 0)
            {
                post = blogService.GetCategory(id.Value);
            }

            // 2. Render page
            return View(post);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // 1. Update category
                var updateSuccess = blogService.UpdateCategory(categoryViewModel);

                if (updateSuccess)
                {
                    TempData["Message"] = "Category was updated successfully.";
                }
                else
                {
                    TempData["Message"] = "Category was NOT updated successfully.";
                }
            }

            return RedirectToAction(nameof(EditCategory), new { id = categoryViewModel.Id });
        }

        public IActionResult Posts()
        {
            // 1. Get list of all posts
            var posts = blogService.GetPosts();

            // 2. Render page
            return View(posts);
        }

        public IActionResult EditPost(int? id)
        {
            // 1. Get post details
            // If parameter id is null or 0 then we will provide an empty view model, to indicate Create new post mode, otherwise we will get Post by ID from Database
            var post = new PostViewModel();

            if (id != null && id > 0)
            {
                post = blogService.GetPost(id.Value);
            }

            // 2. Load ViewBag data
            ViewBag.Categories = new SelectList(blogService.GetCategories(), "Id", "Title");

            // 3. Render page
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                // 1. Upload file
                if (postViewModel.PhotoFile != null)
                {
                    var uniqueFileName = GetUniqueFileName(postViewModel.PhotoFile.FileName);
                    var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    var fileFullName = Path.Combine(uploadsFolder, uniqueFileName);

                    await postViewModel.PhotoFile.CopyToAsync(new FileStream(fileFullName, FileMode.Create));

                    postViewModel.Photo = uniqueFileName;
                }

                // 2. Update post
                var updateSuccess = blogService.UpdatePost(postViewModel);

                if (updateSuccess)
                {
                    TempData["Message"] = "Blog post was updated successfully.";
                }
                else
                {
                    TempData["Message"] = "Blog post was NOT updated successfully.";
                }

                // 3. Load ViewBag data
                ViewBag.Categories = new SelectList(blogService.GetCategories(), "Id", "Title");
            }

            // 4. Redirect to details
            return RedirectToAction(nameof(EditPost), new { id = postViewModel.Id });
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}