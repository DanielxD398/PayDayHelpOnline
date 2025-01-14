using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayDayHelpOnline.Models;

namespace PayDayHelpOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult qhdn()
        {
            return View();
        }

        public IActionResult PayDayCloud()
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
