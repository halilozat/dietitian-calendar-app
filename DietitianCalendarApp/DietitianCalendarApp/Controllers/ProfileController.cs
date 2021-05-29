using DietitianCalendarApp.Data.Entity;
using DietitianCalendarApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            if (user == null)
            {
                return View("Error");
            }

            if (_userManager.IsInRoleAsync(user, "Secretary").Result)
            {
                var dietitians = _userManager.Users.Where(x => x.IsDietitian);
                SecretaryViewModel model = new SecretaryViewModel()
                {
                    User = user,
                    Dietitians = dietitians,
                    DietitiansSelectList = dietitians.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dr. {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Secretary", model);
            }
            else
            {

                return View("Dietitian");
            }
        }


        public IActionResult Secretary()
        {
            return View();
        }

        [Authorize(Roles = "Dietitian")]
        public IActionResult Dietitian()
        {
            return View();
        }

    }
}
