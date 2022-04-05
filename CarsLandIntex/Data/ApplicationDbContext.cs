using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarsLandIntex.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //private DbContextOptions<ApplicationDbContext> context { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //context = options;
        }
    }
}
