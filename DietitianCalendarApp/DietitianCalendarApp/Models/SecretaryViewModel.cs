using DietitianCalendarApp.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<Diet> Diets { get; set; }
        public List<SelectListItem> DietitiansSelectList { get; internal set; }
        public List<SelectListItem> DietSelectList { get; internal set; }

    }
}
