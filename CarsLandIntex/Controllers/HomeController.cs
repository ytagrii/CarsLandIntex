using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarsLandIntex.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace CarsLandIntex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private InferenceSession _session;

        public HomeController(ILogger<HomeController> logger, InferenceSession session)
        {
            _logger = logger;
            _session = session;
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

        public IActionResult Template()
        {
            return View();
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
            
        [HttpPost]
        public IActionResult Score(CrashData data)
        {
            data.AttributeSetting(data);

            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("int64_input", data.AsTensor())
            });
            Tensor<long> score = result.First().AsTensor<long>();
            var prediction = new Prediction { PredictedValue = score.First()};
            result.Dispose();
            return View(prediction);
        }
    }
}

//https://www.codeproject.com/Articles/875547/Custom-Roles-Based-Access-Control-RBAC-in-ASP-NET#:~:text=Roles%20Based%20Access%20Control%20is,do%20not%20need%20to%20see.
