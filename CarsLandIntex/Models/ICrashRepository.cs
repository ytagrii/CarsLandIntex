using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsLandIntex.Models
{
    public interface ICrashRepository
    {
        IQueryable<Crash> Crashes { get; }

        public void UpdateCrash(Crash c)
        {
        }
        public void DeleteCrash(Crash c)
        {
        }
        public void AddCrash(Crash c)
        {
        }
        public List<Crash> GetAll(int id)
        {
            var x = new List<Crash>();
            return x;
        }
    }
}
