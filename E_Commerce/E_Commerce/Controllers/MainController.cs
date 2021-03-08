using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using E_Commerce.ViewModels;

namespace E_Commerce.Controllers
{
    public class MainController : Controller
    {
        private IUserRepository _UserRepository;
        public MainController(IUserRepository userRepository )
        {
            _UserRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Register(String UserName , String UserPassword , String UserRole)
        {
            if (UserName!=null && UserPassword!=null) { 
          
            User user = new User { UserName= UserName ,UserPassword= UserPassword , UserRole= UserRole };

            _UserRepository.SetUser(user);

            }



            return View();
        }
        public IActionResult Register()
        {
          

            return View();
        }

        public IActionResult Login()
        {



            return View(new UserItems() { TheName = null , TheRole = null});
        }
        public IActionResult LogOut()
        {

            HttpContext.Session.Clear(); 

            return RedirectToAction("Login");

            
        }

        [HttpPost]
        public IActionResult Login(String UserName , String UserPassword)
        {
            User us = new User(); 

           us = _UserRepository.Users.Where(x=> x.UserName == UserName && x.UserPassword == UserPassword).FirstOrDefault();

            if (us != null)
            {

                HttpContext.Session.SetString("UserName", us.UserName);
                HttpContext.Session.SetString("UserRole", us.UserRole);
                HttpContext.Session.SetString("UserId", Convert.ToString(us.UserId));

                ViewBag.name = us.UserName;
                return RedirectToAction("List","Home");

            }

            return View(us);
        }
    }
}
