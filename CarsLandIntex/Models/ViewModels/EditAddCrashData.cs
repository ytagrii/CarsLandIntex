using System;
using System.Linq;

namespace CarsLandIntex.Models.ViewModels
{
    public class EditAddCrashData
    {
        public Crash crash { get; set; }
        public IQueryable<City> Cities { get; set; }
        public IQueryable<County> County { get; set; }
        public IQueryable<Severity> Severity { get; set; }
    }
}
