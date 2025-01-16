using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayDayHelpOnline.Models;
using PayDayHelpOnline.Services;

namespace PayDayHelpOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menuService;

        public HomeController(ILogger<HomeController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        public IActionResult Inicio()
        {
            var menu = _menuService.GetMenu();
            if (menu == null)
            {
                throw new InvalidOperationException("El servicio de menú devolvió un valor nulo.");
            }

            ViewData["Menu"] = menu;
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
