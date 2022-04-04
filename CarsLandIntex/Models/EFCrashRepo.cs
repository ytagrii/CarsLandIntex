using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsLandIntex.Models
{
    public class EFCrashRepo : ICrashRepository
    {
        private CrashDataDBContext context { get; set; }
        public EFCrashRepo(CrashDataDBContext temp)
        {
            context = temp;
        }

        public IQueryable<Crash> Crashes => context.Crashes;

        public void UpdateCrash(Crash c)
        {
            context.Update(c);
            context.SaveChanges();
        }
        public void DeleteCrash(Crash c)
        {
            context.Remove(c);
            context.SaveChanges();
        }
        public void AddCrash(Crash c)
        {
            context.Add(c);
            context.SaveChanges();
        }
        public List<Crash> GetAll(int id)
        {
            var c = context.Crashes.Where(x => x.CRASH_SEVERITY_ID == id).ToList();
            return c;
        }
        
    }
}
