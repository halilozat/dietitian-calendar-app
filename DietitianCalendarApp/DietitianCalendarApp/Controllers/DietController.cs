using DietitianCalendarApp.Data;
using DietitianCalendarApp.Data.Entity;
using DietitianCalendarApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Controllers
{
    public class DietController : Controller
    {

        private ApplicationDbContext _context;

        public DietController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult GetDiets()
        {
            var model = _context.Diets
                .Include(x => x.Name).Select(x => new DietViewModel()
                {
                    Name = x.Name,
                    Color = x.Color
                });
                
            return Json(model);
        }

        public JsonResult GetDietsById(string dietId = "")
        {
            var model = _context.Diets.Where(x => x.Id.ToString() == dietId)
                .Include(x => x.Name).Select(x => new DietViewModel()
                {
                    Name = x.Name,
                    Color = x.Color
                });

            return Json(model);
        }


        [HttpPost]
        public JsonResult AddOrUpdateDiet(AddOrUpdateDietModel model)
        {
            //Validasyon
            if (model.Id == 0)
            {
                Diet entity = new Diet()
                {
                    Name = model.Name,
                    Color = model.Color
                };

                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.Diets.SingleOrDefault(x => x.Id == model.Id);
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                };

                entity.Name = model.Name;
                entity.Color = model.Color;

                _context.Update(entity);
                _context.SaveChanges();
            }

            return Json("200");
        }

        public JsonResult DeleteDiet(int id = 0)
        {
            var entity = _context.Diets.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return Json("Kayıt bulunamadı.");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return Json("200");
        }
    }
}
