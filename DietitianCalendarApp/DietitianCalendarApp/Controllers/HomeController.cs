using Microsoft.AspNetCore.Mvc;

namespace DietitianCalendarApp.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
