using System;
using System.Linq;

namespace CarsLandIntex.Models
{
    public class EFSeverityRepo : ISeverityRepo
    {
        private CrashDataDBContext context { get; set; }
        public EFSeverityRepo(CrashDataDBContext temp)
        {
            context = temp;
        }

        public IQueryable<Severity> Severities => context.Severity;
       
    }
}
