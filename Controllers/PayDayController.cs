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
                Description = "Es la opción para confeccionar las planillas para pagar a los trabajadores, ya sean pagos regulares, extraordinarios o especiales.",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Reloj", Action = "Planillas", Parameters = "Reloj" },
                    new SubOption { Name = "Semanal", Action = "Planillas", Parameters = "Semanal" },
                    new SubOption { Name = "Bisemanal", Action = "Planillas", Parameters = "Bisemanal" },
                    new SubOption { Name = "Quincenal", Action = "Planillas", Parameters = "Quincenal" },
                    new SubOption { Name = "Mensual", Action = "Planillas", Parameters = "Mensual" },

                    new SubOption { Name = "Extraordinaria", Action = "Planillas", Parameters = "Extraordinaria" },
                    new SubOption { Name = "Décimo III", Action = "Planillas", Parameters = "XIII" },
                    new SubOption { Name = "Vacaciones", Action = "Planillas", Parameters = "Vacaciones" },
                    new SubOption { Name = "Liquidación", Action = "Planillas", Parameters = "Liquidación" },
                },
                SubOptions2 = new List<SubOption>
                {
                    new SubOption { Name = "Generar Transacciones", Action = "GenerarTransacciones" },
                    new SubOption { Name = "Introducir Datos", Action = "IntroducirDatos" },
                    new SubOption { Name = "Borrador", Action = "Borrador" },
                    new SubOption { Name = "Vouchers o Comprobantes", Action = "Vouchers" },
                    new SubOption { Name = "Informes al Banco", Action = "InformesAlBanco" },
                    new SubOption { Name = "Respaldo de Archivos", Action = "Respaldos" },
                    new SubOption { Name = "Cheques / Postear", Action = "Postear" },
                }
            },
            new MenuOption
            {
                Name = "Mantenimiento",
                Controller = "PayDay",
                Action = "Mantenimiento",
                Description = "Aquí están los registros o las bases de datos del sistema en general.",
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
                Description = "Nos presenta una variedad de reportes muy útiles para consultar la información.",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Reporte de Ventas", Action = "ReporteVentas" },
                    new SubOption { Name = "Reporte de Inventarios", Action = "ReporteInventarios" }
                }
            },
            new MenuOption
            {
                Name = "Otros",
                Controller = "PayDay",
                Action = "Otros",
                Description = "Desde aquí se realizan los respaldos de archivos, cierres mensuales, y se gestionan los roles y usuarios de la compañía.",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Respaldo de Archivos", Action = "Respaldos" },
                    new SubOption { Name = "Cierre Mensual", Action = "CierreMensual" }
                }
            },
            new MenuOption
            {
                Name = "PayDayPortal",
                Controller = "PayDay",
                Action = "PayDayPortal",
                Description = "Portal de auto-gestión",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Respaldo de Archivos", Action = "Respaldos" },
                    new SubOption { Name = "Cierre Mensual", Action = "CierreMensual" }
                }
            },
            new MenuOption
            {
                Name = "Ayuda",
                Controller = "PayDay",
                Action = "Ayuda",
                Description = "Nos brinda información de ayuda sobre PayDay.",
                SubOptions1 = new List<SubOption>
                {
                    new SubOption { Name = "Respaldo de Archivos", Action = "Respaldos" },
                    new SubOption { Name = "Cierre Mensual", Action = "CierreMensual" }
                }
            },
            new MenuOption
            {
                Name = "Salir",
                Controller = "PayDay",
                Action = "Salir",
                Description = "Es la opción para salir del programa.",
                SubOptions1 = null
            }
        };
        }

        public IActionResult MenuPrincipal()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }

        public IActionResult Planillas(string subTopic)
        {
            if (string.IsNullOrEmpty(subTopic))
            {
                return View(_menuOptions); // Vista principal de Planillas
            }
            return View($"Planillas/{subTopic}"); // Carga la subvista dentro de la carpeta Planillas
        }

        public IActionResult Mantenimiento()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }

        public IActionResult Informes()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }

        public IActionResult Otros()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }

        public IActionResult Ayuda()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }

        public IActionResult PayDayPortal()
        {
            return View(_menuOptions); // Pasar las opciones al menú principal
        }
    }

}
