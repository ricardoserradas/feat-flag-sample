using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using full_featflag_sample.Models;
using Microsoft.Extensions.Configuration;

namespace full_featflag_sample.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        
        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        
        public IActionResult Index()
        {
            ViewBag.SomeKey = this._configuration.GetValue<string>("KeyVault:Name");
            ViewBag.DataFromKeyVault = this._configuration.GetValue<string>("Data:MainDatabaseConnectionString");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
