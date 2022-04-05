using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public class EFCountyRepo : ICountyRepo
    {
        private CrashDataDBContext context { get; set; }
        public EFCountyRepo(CrashDataDBContext temp)
        {
            context = temp;
        }

        public IQueryable<County> Counties => context.counties;
    }
}
