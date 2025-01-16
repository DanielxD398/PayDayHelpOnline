using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayDayHelpOnline.Models;
using PayDayHelpOnline.Services;
using PayDayHelpOnline.Controllers;

namespace PayDayHelpOnline.Controllers
{
    public class PayDayController : Controller
    {

        private readonly IMenuService _menuService;

        public PayDayController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult MenuPrincipal()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult Planillas(string subTopic)
        {
            // Obtener el menú
            var menu = _menuService.GetMenu();

            // Pasar el menú a la vista
            ViewData["Menu"] = menu;

            if (string.IsNullOrEmpty(subTopic))
            {
                return View(); // Vista principal de Planillas
            }
            return View($"Planillas/{subTopic}"); // Carga la subvista dentro de la carpeta Planillas
        }

        public IActionResult Mantenimiento()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult Informes()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult Otros()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult Ayuda()
        {
            return View(); // Pasar las opciones al menú principal
        }

        public IActionResult PayDayPortal()
        {
            return View(); // Pasar las opciones al menú principal
        }

        [Route("Help/GetTopicContent")]
        public IActionResult GetTopicContent(string topic, string subTopic)
        {
            switch (topic.ToLower())
            {
                case "planillas":
                    return RedirectToAction("Planillas", "PayDay", new { subTopic }); // Redirigir a la acción Planillas con el subtopic
                case "reloj":
                    return View("Planillas/Reloj"); // Cargar la vista "Planillas/Reloj.cshtml"
            }
            return View("NotFound"); // Si el topic no se encuentra, retornar la vista "NotFound"
        }
    }

}

namespace PayDayHelpOnline.Services
{
    public interface IMenuService
    {
        MainMenu GetMenu();
    }

    public class MenuService : IMenuService
    {
        public MainMenu GetMenu()
        {
            // Carga o construye el menú dinámicamente
            return new MainMenu
            {
                Menu = new MenuModel
                {
                    MenuOptions = new List<MenuOption>
                    {
                        new MenuOption
                        {
                            Id = "planillas",
                            Name = "Planillas",
                            Controller = "PayDay",
                            Action = "Planillas",
                            Description = "Es la opción para confeccionar las planillas para pagar a los trabajadores, ya sean pagos regulares, extraordinarios o especiales.",
                            SubOptions = new List<MenuOption>
                            {
                                new MenuOption
                                {
                                    Id = "pla-reloj",
                                    Name = "Reloj",
                                    Controller = "PayDay",
                                    Action = "PlaReloj"
                                },
                                new MenuOption
                                {
                                    Id = "pla-regulares",
                                    Name = "Planillas Regulares",
                                    Controller = "PayDay",
                                    Action = "PlaRegulares",
                                    Description = "Planillas para pagos extraordinarios.",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption
                                        {
                                            Id = "pla-regulares-generar",
                                            Name = "Generar Transacciones",
                                            Controller = "PayDay",
                                            Action = "Planillas",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "pla-regulares-generar-vencevacas", Name = "Empleados que Venció su Periodo de Vacaciones", Controller = "PayDay", Action = "Planillas"},
                                                new MenuOption { Id = "pla-regulares-generar-noactivos", Name = "Empleados No Activos", Controller = "PayDay", Action = "Planillas"},
                                                new MenuOption { Id = "pla-regulares-generar-multiples", Name = "Múltiples Planillas", Controller = "PayDay", Action = "Planillas"}
                                            },
                                        },
                                        new MenuOption
                                        {
                                            Id = "pla-regulares-introducir",
                                            Name = "Introducir Datos",
                                            Controller = "PayDay",
                                            Action = "Planillas",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "pla-regulares-introducir-seleccionar", Name = "Seleccionar Empleados", Controller = "PayDay", Action = "Planillas"},
                                                new MenuOption
                                                {
                                                    Id = "pla-regulares-introducir-salariosysob",
                                                    Name = "Salarios y Sobretiempos",
                                                    Controller = "PayDay",
                                                    Action = "Planillas",
                                                    SubOptions = new List<MenuOption>
                                                    {
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-hehs", Name = "Hora Entrada / Hora Salida", Controller = "PayDay", Action = "Planillas"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-sess", Name = "ST Entrada / ST Salida", Controller = "PayDay", Action = "Planillas"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-standard", Name = "Estándar", Controller = "PayDay", Action = "Planillas"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-relojhehs", Name = "Reloj HE / HS", Controller = "PayDay", Action = "Planillas"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-relojres", Name = "Reloj Resumen", Controller = "PayDay", Action = "Planillas"}
                                                    },
                                                },
                                                new MenuOption { Id = "pla-regulares-introducir-otrosing", Name = "Otros Ingresos", Controller = "PayDay", Action = "Planillas"},
                                                new MenuOption { Id = "pla-regulares-introducir-deudasrap", Name = "Deudas Rápidas", Controller = "PayDay", Action = "Planillas"}
                                            },
                                        },
                                        new MenuOption { Id = "pla-borrador", Name = "Borrador", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-vouchers", Name = "Vouchers / Comprobantes", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-infbanco", Name = "Informes al Banco", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-respaldo", Name = "Respaldo de Archivos", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-postear", Name = "Cheques / Postear", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-eliminar", Name = "Eliminar Planilla", Controller = "PayDay", Action = "Planillas"}
                                    }

                                },
                                new MenuOption
                                {
                                    Id = "pla-extra",
                                    Name = "Extraordinaria",
                                    Controller = "PayDay",
                                    Action = "Planillas"
                                },
                                new MenuOption
                                {
                                    Id = "pla-xiii",
                                    Name = "XIII Mes",
                                    Controller = "PayDay",
                                    Action = "Planillas"
                                },
                                new MenuOption
                                {
                                    Id = "pla-vacas",
                                    Name = "Vacaciones",
                                    Controller = "PayDay",
                                    Action = "Planillas",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "pla-vacas-datos", Name = "Datos de la Vacación", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-vacas-otrosing", Name = "Otros Ingresos de la Vacación", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-vacas-distrib", Name = "Distribuir Vacaciones", Controller = "PayDay", Action = "Planillas"}
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "pla-liquidacion",
                                    Name = "Liquidación",
                                    Controller = "PayDay",
                                    Action = "Planillas",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "pla-liquidadcion-calculo", Name = "Cálculo de Liquidación", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-liquidacion-otrosing", Name = "Otros Ingresos de la Liquidación", Controller = "PayDay", Action = "Planillas"},
                                        new MenuOption { Id = "pla-liquidacion-informe", Name = "Informe de Liquidación", Controller = "PayDay", Action = "Planillas"}
                                    }
                                }
                            }
                        },
                        new MenuOption
                        {
                            Id = "mantenimiento",
                            Name = "Mantenimiento",
                            Controller = "PayDay",
                            Action = "Mantenimiento",
                            Description = "Aquí están los registros o las bases de datos del sistema en general.",
                            SubOptions = new List<MenuOption>
                            {
                                new MenuOption
                                {
                                    Id = "mantempleados",
                                    Name = "Empleados",
                                    Controller = "PayDay",
                                    Action = "Empleados",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "empd-atosgenerales", Name = "Datos Generales", Controller = "PayDay", Action = "EmpleadosGenerales", Description = "" },
                                        new MenuOption { Id = "cambiarsalarios", Name = "Cambiar Salarios / Ingresos", Controller = "PayDay", Action = "cambiarsalarios", Description = "" }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "acreedores",
                                    Name = "Acreedores",
                                    Controller = "PayDay",
                                    Action = "Acreedores",
                                    Description = ""
                                },
                                new MenuOption
                                {
                                    Id = "deudas",
                                    Name = "Deudas",
                                    Controller = "PayDay",
                                    Action = "Deudas",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "deu-datosgenerales", Name = "Datos Generales", Controller = "PayDay", Action = "DeudasGenerales", Description = "" },
                                        new MenuOption { Id = "cambiarsalarios", Name = "Cambiar Salarios / Ingresos", Controller = "PayDay", Action = "cambiarsalarios", Description = "" }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "sucursales",
                                    Name = "Sucursales",
                                    Controller = "PayDay",
                                    Action = "Sucursales",
                                    Description = ""
                                },
                                new MenuOption
                                {
                                    Id = "departamentos",
                                    Name = "Departamentos",
                                    Controller = "PayDay",
                                    Action = "Departamentos",
                                    Description = "Planillas de Vacaciones."
                                },
                                new MenuOption
                                {
                                    Id = "horarios",
                                    Name = "Horarios",
                                    Controller = "PayDay",
                                    Action = "Horarios",
                                    Description = "Planillas de Vacaciones."
                                },
                            }
                        },
                        new MenuOption
                        {
                            Id = "informes",
                            Name = "Informes",
                            Controller = "PayDay",
                            Action = "Informes",
                            Description = "Nos presenta una variedad de reportes muy útiles para consultar la información.",
                            SubOptions = new List<MenuOption>
                            {
                                new MenuOption
                                {
                                    Id = "inf-empleados",
                                    Name = "Empleados",
                                    Controller = "PayDay",
                                    Action = "InfEmpleados",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "inf-emp-muestras", Name = "Muestra de Informes", Controller = "PayDay", Action = "InfEmplMuestra", Description = "" }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "inf-rrhh",
                                    Name = "Recursos Humanos",
                                    Controller = "PayDay",
                                    Action = "InfRRHH",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "inf-rrhh-muestras", Name = "Configurar Entrada", Controller = "PayDay", Action = "InfRRHHMuestra", Description = "" },
                                        new MenuOption { Id = "inf-rrhh-cartas", Name = "Configurar Entrada", Controller = "PayDay", Action = "InfRRHHCartas", Description = "" }
                                    }
                                }
                            }
                        },
                        new MenuOption
                        {
                            Id = "otros",
                            Name = "Otros",
                            Controller = "PayDay",
                            Action = "Otros",
                            Description = "Desde aquí se realizan los respaldos de archivos, cierres mensuales, entre otros procesos que no se realizan constantemente.",
                            SubOptions = new List<MenuOption>
                            {
                                new MenuOption
                                {
                                    Id = "otros-fecha",
                                    Name = "Fecha de Proceso",
                                    Controller = "PayDay",
                                    Action = "OtrosFecha",
                                    Description = ""
                                },
                                new MenuOption
                                {
                                    Id = "otros-otrosproc",
                                    Name = "Otros Procesos",
                                    Controller = "PayDay",
                                    Action = "OtrosProc",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "otros-otrosproc-anularck", Name = "Anular Cheques", Controller = "PayDay", Action = "OtrosAnularCk", Description = "" },
                                        new MenuOption { Id = "otros-otrosproc-anexo03", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosAnexo03", Description = "" },
                                        new MenuOption { Id = "otros-otrosproc-recalcxiii", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcXIII", Description = "" },
                                        new MenuOption { Id = "otros-otrosproc-recalcvacas", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcVacas", Description = "" },
                                        new MenuOption { Id = "otros-otrosproc-recalcmesanho", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcMes", Description = "" }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }

}