using DietitianCalendarApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Models
{
    public class SecretaryViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Dietitians { get; set; }
    }
}
