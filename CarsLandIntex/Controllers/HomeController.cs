using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsLandIntex.Models;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.ML.OnnxRuntime;
//using Microsoft.ML.OnnxRuntime.Tensors;
using CarsLandIntex.Models.ViewModels;
using CarsLandIntex.Infastructure;

namespace CarsLandIntex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICrashRepository repo;
        private ICountyRepo countyRepo;
        private ICityRepo cityRepo;
        private ISeverityRepo sevRepo;
        //private InferenceSession _session;

        public HomeController(ILogger<HomeController> logger, ICrashRepository temp, ICountyRepo con, ICityRepo cr, ISeverityRepo sr)
        {
            _logger = logger;
            //_session = session;
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
        public IActionResult ExploreData(int pageNum = 1)
        {
            int numberPerPage = 50;
            Filtering filter = HttpContext.Session.GetJson<Filtering>("filter") ?? new Filtering();
            if(filter.county == 0)
            {
                filter.county = null;
            }
            var data = new ExploreDataInfo
            {
                Crashes = repo.Crashes
                .Where(x => (filter.severity == null ? x.CRASH_SEVERITY_ID != null : x.CRASH_SEVERITY_ID == filter.severity)
                    && (filter.county == null ? x.COUNTY_ID != null : x.COUNTY_ID == filter.county)
                    && (filter.city == null ? x.CITY_ID != null : x.CITY.CITY == filter.city)
                    && (filter.year == null ? x.year != null : x.year == filter.year)
                    && (filter.month == null ? x.month != null : x.month == filter.month)
                    && (filter.weekday == null ? x.weekday != null : x.weekday == filter.weekday)
                )
                .Skip((pageNum - 1) * (numberPerPage))
                .Take(numberPerPage),
                Filter = filter,
                Cities = cityRepo.cities,
                County = countyRepo.counties,
                Severity = sevRepo.Severities,
                PageInfo = new PageInfo
                {
                    TotalCrashes = repo.Crashes
                    .Where(x => (filter.severity == null ? x.CRASH_SEVERITY_ID != null : x.CRASH_SEVERITY_ID == filter.severity)
                    && (filter.county == null ? x.COUNTY_ID != null : x.COUNTY_ID == filter.county)
                    && (filter.city == null ? x.CITY_ID != null : x.CITY.CITY == filter.city)
                    && (filter.year == null ? x.year != null : x.year == filter.year)
                    && (filter.month == null ? x.month != null : x.month == filter.month)
                    && (filter.weekday == null ? x.weekday != null : x.weekday == filter.weekday)
                )
                    .Count(),
                    CrashesPerPage = numberPerPage,
                    CurrentPage = pageNum
                }

            };
            List<MonthData> x = new List<MonthData>();
            List<int> years = new List<int>();
            x.Add(new MonthData { monthId = 1, monthName = "January" });
            x.Add(new MonthData { monthId = 2, monthName = "February" });
            x.Add(new MonthData { monthId = 3, monthName = "March" });
            x.Add(new MonthData { monthId = 4, monthName = "April" });
            x.Add(new MonthData { monthId = 5, monthName = "May" });
            x.Add(new MonthData { monthId = 6, monthName = "June" });
            x.Add(new MonthData { monthId = 7, monthName = "July" });
            x.Add(new MonthData { monthId = 8, monthName = "August" });
            x.Add(new MonthData { monthId = 9, monthName = "September" });
            x.Add(new MonthData { monthId = 10, monthName = "October" });
            x.Add(new MonthData { monthId = 11, monthName = "November" });
            x.Add(new MonthData { monthId = 12, monthName = "December" });
            data.month = x;
            years.Add(2016);
            years.Add(2017);
            years.Add(2019);
            data.year = years;
            data.weekday = data.Crashes.Select(x => x.weekday).Distinct().ToList();


            return View(data);
        }

        [HttpPost]
        public IActionResult ExploreData(Filtering filter)
        {
            HttpContext.Session.SetJson("filter", filter);
            return RedirectToAction("ExploreData");
        }

        public IActionResult ClearFilter()
        {
            HttpContext.Session.SetJson("filter", new Filtering());
            return RedirectToAction("ExploreData");
        }

        //[HttpGet]
        //public IActionResult EditCrash(int id)
        //{
        //    var data = new EditAddCrashData
        //    {
        //        crash = repo.Crashes.FirstOrDefault(x => x.CRASH_ID == id),
        //        Cities = cityRepo.cities,
        //        County = countyRepo.counties,
        //        Severity = sevRepo.Severities
        //    };
        //    return View(data);
        //}

        [HttpPost]
        public IActionResult EditCrash(Crash crash)
        {
            repo.UpdateCrash(crash);

            return RedirectToAction("ExploreData");
        }

        //[HttpGet]
        //public IActionResult DeleteCrash(int id)
        //{
        //    Crash c = repo.Crashes.FirstOrDefault(x => x.CRASH_ID == id);
        //    return View(c);
        //}

        [HttpPost]
        public IActionResult DeleteCrash(Crash crash)
        {
            var x = repo.Crashes.FirstOrDefault(r => r.CRASH_ID == crash.CRASH_ID);
            repo.DeleteCrash(x);

            return RedirectToAction("ExploreData");
        }

        [HttpGet]
        public IActionResult AddCrash()
        {
            var data = new EditAddCrashData
            {
                crash = new Crash(),
                Cities = cityRepo.cities,
                County = countyRepo.counties,
                Severity = sevRepo.Severities
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult AddCrash(Crash crash)
        {
            repo.AddCrash(crash);

            return RedirectToAction("ExploreData");
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
            var data = new EditAddCrashData
            {
                crash = repo.Crashes.FirstOrDefault(x => x.CRASH_ID == id),
                Cities = cityRepo.cities,
                County = countyRepo.counties,
                Severity = sevRepo.Severities
            };
           

            return View(data);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Machine Learning Model Stuff
        public IActionResult MachineLearning()
        {
            return View();
        }
        
        //// Actual Machine Learning Call
        //[HttpPost]
        //public IActionResult Score(CrashData data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        data.AttributeSetting(data);

        //        var result = _session.Run(new List<NamedOnnxValue>
        //    {
        //        NamedOnnxValue.CreateFromTensor("int64_input", data.AsTensor())
        //    });
        //        Tensor<long> score = result.First().AsTensor<long>();
        //        var prediction = new Prediction { PredictedValue = score.First() };
        //        result.Dispose();
        //        return View(prediction);
        //    }
        //    return MachineLearning();
        //}
    }
}

//https://www.codeproject.com/Articles/875547/Custom-Roles-Based-Access-Control-RBAC-in-ASP-NET#:~:text=Roles%20Based%20Access%20Control%20is,do%20not%20need%20to%20see.
