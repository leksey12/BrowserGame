using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrowserGame.Models;
using Microsoft.Extensions.Logging;

namespace BrowserGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            logger.LogInformation("Действие главной страницы");
            return View();
        }

        public IActionResult Privacy()
        {
            logger.LogInformation("Действие privacy страницы");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
