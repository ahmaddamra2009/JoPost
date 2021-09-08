using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext context;
        public AccountController(AppDbContext _context)
        {
            context = _context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var chkUser = context.Users.Where(
                m => m.UserName.Equals(user.UserName) &&
                m.Password.Equals(user.Password) && m.isDeleted == false
                );
            if (chkUser.Any())
            {
                HttpContext.Session.SetString("uName", user.UserName);
                return RedirectToAction("AllEmployees", "Employees");
            }
            ViewBag.userStatus = "Invalid User / Password";
            return View(user);
        }
    }
}
