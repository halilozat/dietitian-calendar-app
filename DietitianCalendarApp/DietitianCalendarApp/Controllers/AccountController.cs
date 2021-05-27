using DietitianCalendarApp.Data.Entity;
using DietitianCalendarApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInUser;
        private RoleManager<AppRole> _roleManager;

        //Dependency Injection
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInUser, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInUser = signInUser;
            _roleManager = roleManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = new AppUser()
            {
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Color = model.Color,
                IsDietitian = model.IsDietitian
            };

            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                bool roleCheck = model.IsDietitian ? AddRole("Dietitian") : AddRole("Secretary");
                if (!roleCheck)
                {
                    return View("Error");
                }
                _userManager.AddToRoleAsync(user, model.IsDietitian ? "Dietitian" : "Secretary").Wait();
                return RedirectToAction("Index","Home");
            }

            return View("Error");
        
        }



        private bool AddRole(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {

                AppRole role = new AppRole()
                {
                    Name = roleName
                };

                IdentityResult result = _roleManager.CreateAsync(role).Result;
                return result.Succeeded;
            }
            return true;

        }

    }

    
}
