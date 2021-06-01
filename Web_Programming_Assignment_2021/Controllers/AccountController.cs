using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programming_Assignment_2021.Controllers
{
    /*
    public class AccountController : Controller
    {
        private ProductMarketDBContext context;

        public AccountsController(ProductMarketDBContext context)
        {
            this.context = context;
        }

        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            List<User> users = context.Users.ToList();

            foreach (var u in users)
            {
                if (u.UserName == model.Username)
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
            user.UserName = model.Username;
            user.RoleId = 2;


            model.ErrorMessageVisible = false;
            context.Users.Add(user);
            context.SaveChanges();
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

            User user = await context.Users.Include(a => a.Role).FirstOrDefaultAsync(a => a.UserName == userName);

            if (user == null || user.Password != password)
            {
                return RedirectToAction("Login");
            }

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
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
    }
    */
}
