using Cyber_Safe_Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cyber_Safe_Academy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public async Task<IActionResult> Index()        
        {
            // This method is called when the user navigates to the home page.
            // It returns a view that will be displayed in the browser.
            return View();
        }

        public IActionResult Privacy()
        {
            // This method is called when the user navigates to the privacy page.
            // It returns a view that will be displayed in the browser.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // This method is called when there is an error.
            // It creates an ErrorViewModel object with the error details and returns a view to display the error.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
