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
        public DbSet<Crash> Crashes { get; set; }
        public DbSet<Severity> Severities { get; set; }
    }
}
