using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_Programming_Assignment_2021.Data;
using Web_Programming_Assignment_2021.Models;
using Web_Programming_Assignment_2021.ViewModels.Accounts;

namespace Web_Programming_Assignment_2021.Controllers
{
    
    public class AccountsController : Controller
    {
        private CatstagramContext context;
        private readonly IConfiguration configuration;
        private IWebHostEnvironment hostEnvironment;

        public AccountsController(CatstagramContext context, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }
        [Authorize]
        public IActionResult Profile()
        {
            User user = context.Users.FirstOrDefault(a => a.Username == this.HttpContext.User.Identity.Name);
            return View(user);
        }


        /*
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            User user = new User();
            user.Password = model.Password;
            user.Username = model.Username;
            user.Email = model.Email;
            user.Status = model.Status;
            user.AvatarFile = null;
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("Login");
        }*/


        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            List<User> users = context.Users.ToList();

            foreach (var u in users)
            {
                if (u.Username == model.Username)
                {
                    model.ErrorMessageVisible = true;
                    return RedirectToAction("Register");
                }
                if (u.Password == model.Password)
                {
                    model.ErrorMessageVisible = true;
                    return RedirectToAction("Register");
                }
            }
            User user = new User();
            user.Password = model.Password;
            user.Username = model.Username;
            user.Email = model.Email;
            user.Status = model.Status;
            user.AvatarFile = null;
            context.Users.Add(user);
            context.SaveChanges();
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            User user = await context.Users.FirstOrDefaultAsync(a => a.Username == userName);

            if (user == null || user.Password != password)
            {
                return RedirectToAction("Login");
            }

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit()
        {
            User user = context.Users.FirstOrDefault(a => a.Username == this.HttpContext.User.Identity.Name);

            EditProfileViewModel editProfileViewModel = new EditProfileViewModel();
            editProfileViewModel.ProfileToBeEdited = user;

            return View(editProfileViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditProfileViewModel viewModel)
        {
            User editedUser = viewModel.ProfileToBeEdited;

            User originalUser = context.Users.FirstOrDefault(a => a.UserId == editedUser.UserId);
            originalUser.Status = editedUser.Status;
            editedUser.Email = originalUser.Email;

            if (originalUser.Password != viewModel.Password)
            {
                editedUser.AvatarFile = originalUser.AvatarFile;
                viewModel.ErrorMessageVisible = true;
                return View(viewModel);

            }

            if (viewModel.AvatarChange == null)
            {
                editedUser.AvatarFile = originalUser.AvatarFile;
            }
            else
            {
                if (viewModel.AvatarChange.Length > (2 * 1024 * 1024))
                {
                    editedUser.AvatarFile = originalUser.AvatarFile;
                    viewModel.ErrorMessageVisible = true;
                    return View(viewModel);
                }
                string wwwRootPath = hostEnvironment.WebRootPath;
                string imagesPath = configuration.GetValue<string>("AvatarLocation");

                string directoryPath = Path.Combine(imagesPath, originalUser.UserId.ToString());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }

                string fileName = string.Format($"{Path.GetFileNameWithoutExtension(Path.GetRandomFileName())}.jpg");
                originalUser.AvatarFile = fileName;
                string filePath = Path.Combine(directoryPath, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.AvatarChange.CopyTo(fileStream);
                }
                editedUser.AvatarFile = originalUser.AvatarFile;

            }

           
            context.SaveChanges();
            return RedirectToAction("Profile");
        }




        
        [Authorize]
        public IActionResult Delete()
        {
            User user = context.Users.FirstOrDefault(a => a.Username == this.HttpContext.User.Identity.Name);

            DeleteViewModel deleteViewModel = new DeleteViewModel();
            deleteViewModel.ProfileToBeDeleted = user;

            return View(deleteViewModel);
        }
        [HttpPost]
        public IActionResult Delete(DeleteViewModel u)
        {
            User User = context.Users.FirstOrDefault(a => a.Username == this.HttpContext.User.Identity.Name);

            DeleteViewModel user = new DeleteViewModel();
            user.ProfileToBeDeleted = User;
            User deleteUser = user.ProfileToBeDeleted;
            User originalUser = context.Users.FirstOrDefault(a => a.Username == this.HttpContext.User.Identity.Name);
           
            string imagesPath = configuration.GetValue<string>("AvatarLocation");

            string directoryPath = Path.Combine(imagesPath, user.ProfileToBeDeleted.UserId.ToString());
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    System.IO.File.Delete(file);
                }
                Directory.Delete(directoryPath);
            }
           

            List<Post> posts = context.Posts.Where(a=>a.User.Username==deleteUser.Username).ToList();
            foreach(var post in posts)
            {
                Post postToDelete = context.Posts.FirstOrDefault(a => a.PostId == post.PostId);

                string imagespath = configuration.GetValue<string>("PostLocation");

                string directorypath = Path.Combine(imagespath, post.PostId.ToString());
                if (Directory.Exists(directorypath))
                {
                    var files = Directory.GetFiles(directorypath);
                    foreach (var file in files)
                    {
                        System.IO.File.Delete(file);
                    }
                    Directory.Delete(directorypath);
                }
                context.Posts.Remove(postToDelete);
                context.SaveChanges();
            }
            
            
           
            context.Users.Remove(originalUser);
            context.SaveChanges();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        
    }
    
}
