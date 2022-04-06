﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsLandIntex.Models;
using Microsoft.AspNetCore.Authorization;
using CarsLandIntex.Models.ViewModels;

namespace CarsLandIntex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICrashRepository repo;
        private ICountyRepo countyRepo;
        private ICityRepo cityRepo;
        private ISeverityRepo sevRepo;

        public HomeController(ILogger<HomeController> logger, ICrashRepository temp, ICountyRepo con, ICityRepo cr, ISeverityRepo sr)
        {
            _logger = logger;
            repo = temp;
            countyRepo = con;
            cityRepo = cr;
            sevRepo = sr;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Severity()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExploreData()
        {
            int numberPerPage = 500;
            var data = new ExploreDataInfo
            {
                Crashes = repo.Crashes.Take(numberPerPage),
                Filter = new Filtering(),
                County = countyRepo.counties,
                Cities = cityRepo.cities,
                Severity = sevRepo.Severities,
                PageInfo = new PageInfo
                {
                    //this is where the total pages needed comes into play
                    //TotalCrashes = (bookCategory == null ? repo.Books.Count() :
                    //    repo.Books.Where(b => b.Category == bookCategory).Count()
                    //),
                    TotalCrashes = repo.Crashes.Count(),
                    CrashesPerPage = numberPerPage,
                    CurrentPage = 1
                }

            };
            
            
            return View(data);
        }

        [HttpPost]
        public IActionResult ExploreData(Filtering filter)
        {
            int numberPerPage = 500;
            var data = new ExploreDataInfo
            {
                Crashes = repo.Crashes
                .Where(x =>x.CRASH_SEVERITY_ID == filter.severity)
                .Where(x => x.COUNTY_ID == filter.county)
                .Where(x => x.CITY.CITY == filter.city)
                .Take(numberPerPage),
                Filter = filter,
                County = countyRepo.counties,
                Cities = cityRepo.cities,
                Severity = sevRepo.Severities,
                PageInfo = new PageInfo
                {
                    //this is where the total pages needed comes into play
                    //TotalCrashes = (bookCategory == null ? repo.Books.Count() :
                    //    repo.Books.Where(b => b.Category == bookCategory).Count()
                    //),
                    TotalCrashes = repo.Crashes.Count(),
                    CrashesPerPage = numberPerPage,
                    CurrentPage = 1
                }

            };


            return View(data);
        }

        public IActionResult FullSummary()
        {
            int numberPerPage = 500;
            var data = new ExploreDataInfo
            {
                Crashes = repo.Crashes.Take(numberPerPage),
                Filter = new Filtering(),
                County = countyRepo.counties,
                Cities = cityRepo.cities,
                Severity = sevRepo.Severities,
                PageInfo = new PageInfo
                {
                    //this is where the total pages needed comes into play
                    //TotalCrashes = (bookCategory == null ? repo.Books.Count() :
                    //    repo.Books.Where(b => b.Category == bookCategory).Count()
                    //),
                    TotalCrashes = repo.Crashes.Count(),
                    CrashesPerPage = numberPerPage,
                    CurrentPage = 1
                }

            };


            return View(data);
        }

        public IActionResult SingleRecord(int id)
        {
            Crash c = repo.Crashes.FirstOrDefault(x => x.CRASH_ID == id);

            return View(c);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//https://www.codeproject.com/Articles/875547/Custom-Roles-Based-Access-Control-RBAC-in-ASP-NET#:~:text=Roles%20Based%20Access%20Control%20is,do%20not%20need%20to%20see.
