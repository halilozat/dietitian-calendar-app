using DietitianCalendarApp.Data;
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

        public JsonResult GetAppoinments()
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Dietitian = x.User.Name + " " + x.User.Surname,
                    Patient = x.PatientName + " " + x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    UserId = x.User.Id
                });

            return Json(model);
        }

        public JsonResult GetAppoinments(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Dietitian = x.User.Name + " " + x.User.Surname,
                    Patient = x.PatientName + " " + x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    UserId = x.User.Id
                });

            return Json(model);
        }




    }
}
