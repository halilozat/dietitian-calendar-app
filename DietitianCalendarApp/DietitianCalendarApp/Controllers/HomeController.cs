using DietitianCalendarApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageProcess _imageProcess;

        public HomeController(IImageProcess imageProcess)
        {
            _imageProcess = imageProcess;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //ImageProcessi kullanacağımız controller alanımız.
        public IActionResult AddWatermark()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  AddWatermark(IFormFile image)
        {
            if (image.Length >= 0)
            {
                var imageMemoryStream = new MemoryStream();

                await image.CopyToAsync(imageMemoryStream);

                _imageProcess.AddWaterMark("Asp.Net Core MVC", image.FileName, imageMemoryStream);
            }
            return View();
        }
    }
}
