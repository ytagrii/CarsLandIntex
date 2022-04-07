using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarsLandIntex.Models
{
    public class EFCrashRepo : ICrashRepository
    {
        private CrashDataDBContext context { get; set; }
        public EFCrashRepo(CrashDataDBContext temp)
        {
            context = temp;
        }

        public IQueryable<Crash> Crashes => context.master.Include(x => x.CITY).Include(x => x.County).Include(x => x.Severity);

        public void UpdateCrash(Crash c)
        {
            context.master.Update(c);
            context.SaveChanges();
        }
        public void DeleteCrash(Crash c)
        {
            context.master.Remove(c);
            context.SaveChanges();
        }
        public void AddCrash(Crash c)
        {
            context.master.Add(c);
            context.SaveChanges();
        }
        public List<Crash> GetAll(int id)
        {
            var c = context.master.ToList();
            return c;
        }
        
    }
}
