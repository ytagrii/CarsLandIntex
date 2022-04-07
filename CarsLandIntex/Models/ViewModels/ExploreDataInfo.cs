using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsLandIntex.Models.ViewModels
{
    public class ExploreDataInfo
    {
        public IQueryable<Crash> Crashes { get; set; }
        public Filtering Filter { get; set; }
        public IQueryable<City> Cities { get; set; }
        public List<string> cityF { get; set; }
        public IQueryable<County> County { get; set; }
        public IQueryable<Severity> Severity { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<string>? weekday { get; set; }
        public List<int>? year { get; set; }
        public List<MonthData> month { get; set; }
    }
}
