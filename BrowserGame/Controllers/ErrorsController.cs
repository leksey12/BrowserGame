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

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error(int? id)
            {
                if (id == 404)
                {
                    return View("Error404");
                }
                else if (id == 401)
                {
                    return View("Error401");
                }
                else if (id == 403)
                {
                    return View("Error403");
                }
                else if (id == 500)
                {
                    return View("Error500");
                }
                else
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
        }
    }