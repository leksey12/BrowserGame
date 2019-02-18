using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrowserGame.Controllers
{
        public class ErrorsController : Controller
        {
            // GET: /<controller>/
            public IActionResult Index()
            {
                return View("Error");
            }

            public IActionResult Error(int? id)
            {
                    return View("Error404");
            }
        }
    }