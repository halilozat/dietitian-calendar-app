using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianCalendarApp.Models
{
    public class DietViewModel
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public string Color { get; internal set; }
    }
}
