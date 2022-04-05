using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public class EFCityRepo : ICityRepo
    {
        private CrashDataDBContext context { get; set; }
        public EFCityRepo(CrashDataDBContext temp)
        {
            context = temp;
        }

        public IQueryable<City> Cities => context.cities;
    }
}
