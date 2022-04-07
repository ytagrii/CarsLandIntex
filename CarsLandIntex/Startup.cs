﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CarsLandIntex.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using CarsLandIntex.Models;
using Microsoft.Data.SqlClient;
//using Microsoft.ML.OnnxRuntime;

namespace CarsLandIntex
{
    public class Startup
    {
        private string _mainConnection = null;
        private string _authConnection = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //This configures a secret variable for the db password
            //var mainbuilder = new SqlConnectionStringBuilder(
            //Configuration.GetConnectionString("ConnectionStrings: MainConnection"));
            //mainbuilder.Password = Configuration["DbPassword"];
            //_mainConnection = mainbuilder.ConnectionString;

            //var authbuilder = new SqlConnectionStringBuilder(
            //Configuration.GetConnectionString("ConnectionStrings: AuthConnection"));
            //authbuilder.Password = Configuration["DbPassword"];
            //_authConnection = authbuilder.ConnectionString;

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlite(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:AuthConnection"]);
            });

            services.AddDbContext<CrashDataDBContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:MainConnection"]);
            });
            services.AddScoped<ICrashRepository, EFCrashRepo>();
            services.AddScoped<ISeverityRepo, EFSeverityRepo>();
            services.AddScoped<ICountyRepo, EFCountyRepo>();
            services.AddScoped<ICityRepo, EFCityRepo>();
            //This is for the HTTP to HTTPS redirect
            //services.AddHttpsRedirection(options =>
            //{
            //    options.HttpsPort = 443;
            //});

            //This ensures that the user must consent for cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 6;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDistributedMemoryCache();
            services.AddSession();
            //services.AddSingleton<InferenceSession>(
            //    new InferenceSession("Models/carCrash.onnx"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //Enable cookie policies
            app.UseCookiePolicy();

            //Adding in the Content Security Policy HTTP header response
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Content-Security-Policy",
            //        "default-src 'self';" +
            //        "script-src 'self' 'unsafe-inline';" +
            //        "style-src 'self' 'unsafe-inline' 'https://fonts.googleapis.com/css?family=Source+Sans+Pro:300italic,600italic,300,600'; ");
            //    await next();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                
                //endpoints.MapFallbackToPage("/admin/{*catchall}", "/Areas/Identity/Pages/Admin/Index");
            });


        }
    }
}
