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
            // Esto se ejecuta cuando acceden a localhost:puerto
            return View();  // Muestra la vista "Index" del controlador Home
        }

        // Redirige desde la ra�z a una acci�n o p�gina personalizada
        public IActionResult RedirectToInicio()
        {
            return RedirectToAction("Inicio", "Home");
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
