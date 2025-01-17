using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using PayDayHelpOnline.Models;
using PayDayHelpOnline.Services;
using System.Diagnostics;

namespace PayDayHelpOnline.Controllers
{
    public class PayDayController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICompositeViewEngine _viewEngine; // Inyección del motor de vistas

        public PayDayController(IMenuService menuService, ICompositeViewEngine viewEngine)
        {
            _menuService = menuService;
            _viewEngine = viewEngine; // Asignación del motor de vistas
        }

        public IActionResult MenuPrincipal()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult Planillas(string subTopic)
        {
            var menu = _menuService.GetMenu();
            ViewData["Menu"] = menu;

            if (string.IsNullOrEmpty(subTopic))
            {
                return View(); // Vista principal de Planillas
            }
            return View($"Planillas/{subTopic}"); // Carga la subvista dentro de la carpeta Planillas
        }

        public IActionResult Index(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return View("Inicio"); // Ruta por defecto si no se especifica nada
            }

            // Construir la ruta a la vista basada en el path
            var viewPath = "Menu/" + path.Replace("-", "/"); // Convierte los "-" a "/" para manejar subcarpetas

            // Verificar si la vista existe antes de renderizar
            if (ViewExists(viewPath))
            {
                return View(viewPath);
            }

            // Si la vista no existe, puedes pasar un modelo de error específico
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = "La vista solicitada no existe: " + viewPath
            };
            return View("Blank"); // Mostrar el error con más contexto
        }

        // Helper para verificar si una vista existe
        private bool ViewExists(string viewPath)
        {
            var result = _viewEngine.FindView(ControllerContext, viewPath, false);
            return result.View != null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
