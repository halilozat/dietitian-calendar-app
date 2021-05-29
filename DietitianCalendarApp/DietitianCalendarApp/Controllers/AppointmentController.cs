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
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult GetAppointments()
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dietitian = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurnameName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    UserId = x.User.Id,
                    Color = x.User.Color
                });

            return Json(model);
        }

        public JsonResult GetAppointmentsByDietitian(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dietitian = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurnameName,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    UserId = x.User.Id,
                    Color = x.User.Color
                });

            return Json(model);
        }


        [HttpPost]
        public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentModel model)
        {
            //Validasyon
            if (model.Id == 0)
            {
                Appointment entity = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PatientName = model.PatientName,
                    PatientSurnameName = model.PatientSurname,
                    Description = model.Description,
                    UserId = model.UserId
                };

                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.Appointments.SingleOrDefault(x => x.Id == model.Id);
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.UpdatedDate = DateTime.Now;
                entity.PatientName = model.PatientName;
                entity.PatientSurnameName = model.PatientSurname;
                entity.Description = model.Description;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.UserId = model.UserId;

                _context.Update(entity);
                _context.SaveChanges();
            }

            return Json("200");
        }


        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _context.Appointments.SingleOrDefault(x => x.Id == id);
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
