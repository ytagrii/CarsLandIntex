using System;
using Microsoft.EntityFrameworkCore;

namespace CarsLandIntex.Models
{
    public class CrashDataDBContext : DbContext
    {
        public CrashDataDBContext() { }
        public CrashDataDBContext(DbContextOptions<CrashDataDBContext> options) : base(options)
        {

        }

        //this is what migrations will reconize
        public DbSet<Crash> master { get; set; }
        public DbSet<Severity> Severity { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<County> counties { get; set; }
    }
}
