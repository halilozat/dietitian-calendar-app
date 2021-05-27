using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Data.Entity
{
    public class AppUser : IdentityUser
    {

        public bool IsDietitian { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        public string Color { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
