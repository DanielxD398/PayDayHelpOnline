using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayDayHelpOnline.Models;

namespace PayDayHelpOnline.Controllers
{
    public class PayDayController : Controller
    {
        private readonly List<MenuOption> _menuOptions;

        public PayDayController()
        {
            _menuOptions = new List<MenuOption>
        {
            new MenuOption
            {
                Name = "Planillas",
                Controller = "PayDay",
                Action = "Planillas",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Reloj", Action = "Reloj" },
                    new SubOption { Name = "Quincenal", Action = "Quincenal" }
                }
            },
            new MenuOption
            {
                Name = "Mantenimiento",
                Controller = "PayDay",
                Action = "Mantenimiento",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Empleados", Action = "Empleados" },
                    new SubOption { Name = "Deudas", Action = "Deudas" }
                }
            },
            new MenuOption
            {
                Name = "Informes",
                Controller = "PayDay",
                Action = "Informes",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Reporte de Ventas", Action = "ReporteVentas" },
                    new SubOption { Name = "Reporte de Inventarios", Action = "ReporteInventarios" }
                }
            }
        };
        }

        public IActionResult MenuPrincipal()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }
    }

}
