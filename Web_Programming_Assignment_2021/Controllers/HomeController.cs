﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
            List<Post> posts = context.Posts.Include(a => a.User).OrderBy(a => a.DateCreated).ToList();
            return View(posts);
        }

        public ActionResult Posts()
        {
            List<Post> posts = context.Posts.Include(a => a.User).OrderBy(a => a.DateCreated).ToList();
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
                editedPost.DateCreated = originalPost.DateCreated;
                originalPost.DateModified= editedPost.DateModified= DateTime.Now;


                viewModel.SuccessMessageVisible = true;
                context.SaveChanges();
            }
            return View(viewModel);
        } 
        
       // [Authorize]
        public IActionResult Create()
        {
            PostCreateViewModel createProductViewModel = new PostCreateViewModel();
            return View(createProductViewModel);
        }


        [HttpPost]
        public IActionResult Create(PostCreateViewModel model)
        {

            model.CreatedOn = DateTime.Now;
            model.EditedOn = DateTime.Now;
            model.UserName = this.HttpContext.User.Identity.Name;

            Post post = new Post();
            post.Comment = model.Comment;
            post.Hashtag = model.Hashtag;
            post.DateCreated = model.CreatedOn;
            post.DateModified = model.EditedOn;
            //  post.UserId = context.Users.FirstOrDefault(a => a.Username == model.UserName).UserId;
            post.UserId = context.Users.FirstOrDefault(a => a.Username == "LolitaKit").UserId;
            context.Posts.Add(post);
            context.SaveChanges();

            var photo = model.photo;
            if (photo != null&&photo.Length<(2*1024))
            {
                    model.ErrorMessageVisible = false;
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string imagesPath = configuration.GetValue<string>("PostLocation");

                    string directoryPath = Path.Combine(imagesPath, post.PostId.ToString());
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = string.Format($"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}.jpg");
                    context.Posts.FirstOrDefault(a => a == post).PhotoFile = fileName;
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
            
                context.Posts.Remove(context.Posts.FirstOrDefault(a => a == post));
                context.SaveChanges();
                model.ErrorMessageVisible = true;
                return View(model);
            }

        }

        
       // [Authorize]

        public ActionResult Delete(int id)
        {
            Post post = context.Posts.FirstOrDefault(a => a.PostId == id);

            return View(post);


        }
       

        [HttpPost]
        public ActionResult Delete(Post post)
        {
            Post postToDelete = context.Posts.FirstOrDefault(a => a.PostId == post.PostId);
           
            string imagesPath = configuration.GetValue<string>("PostLocation");

            string directoryPath = Path.Combine(imagesPath, post.PostId.ToString());
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }
                Directory.Delete(directoryPath);
            }
            context.Posts.Remove(postToDelete);
            context.SaveChanges();

            return RedirectToAction("Posts");

        }
    }
}
