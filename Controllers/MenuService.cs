using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayDayHelpOnline.Models;
using PayDayHelpOnline.Services;
using PayDayHelpOnline.Controllers;

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
                            Id = "pla",
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
                                    Action = "Reloj"
                                },
                                new MenuOption
                                {
                                    Id = "pla-regulares",
                                    Name = "Planillas Regulares",
                                    Controller = "PayDay",
                                    Action = "Regulares",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption
                                        {
                                            Id = "pla-regulares-generar",
                                            Name = "Generar Transacciones",
                                            Controller = "PayDay",
                                            Action = "GenerarTransacciones",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "pla-regulares-generar-vencevacas", Name = "Empleados que Venció su Periodo de Vacaciones", Controller = "PayDay", Action = "VenceVacaciones"},
                                                new MenuOption { Id = "pla-regulares-generar-noactivos", Name = "Empleados No Activos", Controller = "PayDay", Action = "EmpNoAct"},
                                                new MenuOption { Id = "pla-regulares-generar-multiples", Name = "Múltiples Planillas", Controller = "PayDay", Action = "MultiPlanillas"}
                                            },
                                        },
                                        new MenuOption
                                        {
                                            Id = "pla-regulares-introducir",
                                            Name = "Introducir Datos",
                                            Controller = "PayDay",
                                            Action = "IntroducirDatos",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "pla-regulares-introducir-seleccionar", Name = "Seleccionar Empleados", Controller = "PayDay", Action = "Planillas"},
                                                new MenuOption
                                                {
                                                    Id = "pla-regulares-introducir-salariosysob",
                                                    Name = "Salarios y Sobretiempos",
                                                    Controller = "PayDay",
                                                    Action = "Sobretiempos",
                                                    SubOptions = new List<MenuOption>
                                                    {
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-hehs", Name = "Hora Entrada / Hora Salida", Controller = "PayDay", Action = "hehs"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-sess", Name = "ST Entrada / ST Salida", Controller = "PayDay", Action = "sess"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-standard", Name = "Estándar", Controller = "PayDay", Action = "standard"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-relojhehs", Name = "Reloj HE / HS", Controller = "PayDay", Action = "relojhehs"},
                                                        new MenuOption { Id = "pla-regulares-introducir-salariosysob-relojres", Name = "Reloj Resumen", Controller = "PayDay", Action = "relojres"}
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
                                        new MenuOption { Id = "pla-eliminar", Name = "Eliminar Planilla", Controller = "PayDay", Action = "Planillas", List = false }
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
                            Id = "mant",
                            Name = "Mantenimiento",
                            Controller = "PayDay",
                            Action = "Mantenimiento",
                            Description = "Aquí están los registros o las bases de datos del sistema en general.",
                            SubOptions = new List<MenuOption>
                            {
                                new MenuOption
                                {
                                    Id = "mant-empleados",
                                    Name = "Empleados",
                                    Controller = "PayDay",
                                    Action = "Empleados",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "mant-emp-datosgenerales", Name = "Datos Generales", Controller = "PayDay", Action = "EmpleadosGenerales", Description = "" },
                                        new MenuOption { Id = "mant-emp-cambiarsalarios", Name = "Cambiar Salarios / Ingresos", Controller = "PayDay", Action = "cambiarsalarios", Description = "" }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "mant-acreedores",
                                    Name = "Acreedores",
                                    Controller = "PayDay",
                                    Action = "Acreedores",
                                    Description = ""
                                },
                                new MenuOption
                                {
                                    Id = "mant-deudas",
                                    Name = "Deudas",
                                    Controller = "PayDay",
                                    Action = "Deudas",
                                    Description = "",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption 
                                        {
                                            Id = "mant-deu-datosgenerales", 
                                            Name = "Datos de la Deuda", 
                                            Controller = "PayDay", 
                                            Action = "DeudasGenerales",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "mant-deu-datosgenerales-historia", Name = "Historial de Deducciones", Controller = "PayDay", Action = "DeudasHistorial" }
                                            }
                                        },
                                        new MenuOption { Id = "mant-deu-ajussaldo", Name = "Ajustar Saldo de Deudas", Controller = "PayDay", Action = "DeudasSaldo" },
                                        new MenuOption { Id = "mant-deu-reversar", Name = "Reversar Deducciones", Controller = "PayDay", Action = "DeudasReversar" }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "mant-sucursales",
                                    Name = "Sucursales",
                                    Controller = "PayDay",
                                    Action = "Sucursales"  
                                },
                                new MenuOption
                                {
                                    Id = "mant-departamentos",
                                    Name = "Departamentos",
                                    Controller = "PayDay",
                                    Action = "Departamentos"
                                },
                                new MenuOption
                                {
                                    Id = "mant-horarios",
                                    Name = "Horarios",
                                    Controller = "PayDay",
                                    Action = "Horarios",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "mant-horarios-datos", Name = "Datos del Horario", Controller = "PayDay", Action = "DatosHorario" },
                                        new MenuOption { Id = "mant-horarios-otros", Name = "Otros", Controller = "PayDay", Action = "HorOtros" },
                                        new MenuOption 
                                        { Id = "mant-horarios-metodos", 
                                            Name = "Metodos de Captura de Datos", 
                                            Controller = "PayDay", 
                                            Action = "MetodosCaptura",
                                            SubOptions = new List<MenuOption>
                                            {
                                                new MenuOption { Id = "mant-horarios-metodos-hehs", Name = "Hora Entrada / Hora Salida", Controller = "PayDay", Action = "manthehs"},
                                                new MenuOption { Id = "mant-horarios-metodos-sess", Name = "ST Entrada / ST Salida", Controller = "PayDay", Action = "mantsess"},
                                                new MenuOption { Id = "mant-horarios-metodos-standard", Name = "Estándar", Controller = "PayDay", Action = "mantstandard"},
                                                new MenuOption { Id = "mant-horarios-metodos-relojres", Name = "Reloj", Controller = "PayDay", Action = "mantrelojres"}
                                            }
                                        }
                                    }
                                },
                                new MenuOption
                                {
                                    Id = "mant-grupos",
                                    Name = "Grupos de Pago",
                                    Controller = "PayDay",
                                    Action = "GruposDePago",
                                    SubOptions = new List<MenuOption>
                                    {
                                        new MenuOption { Id = "mant-grupos-borradores", Name = "Metodos de Captura de Datos", Controller = "PayDay", Action = "FormatosBorrador" },
                                        new MenuOption { Id = "mant-grupos-totales", Name = "Otros", Controller = "PayDay", Action = "FormatosTotales" },
                                        new MenuOption { Id = "mant-grupos-talonarios", Name = "Otros", Controller = "PayDay", Action = "FormatosTalonarios" },
                                        new MenuOption { Id = "mant-grupos-vouchers", Name = "Otros", Controller = "PayDay", Action = "FormatosVouchers" }

                                    }
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
                                        new MenuOption { Id = "otros-otrosproc-anularck", Name = "Anular Cheques", Controller = "PayDay", Action = "OtrosAnularCk" },
                                        new MenuOption { Id = "otros-otrosproc-anexo03", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosAnexo03" },
                                        new MenuOption { Id = "otros-otrosproc-recalcxiii", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcXIII" },
                                        new MenuOption { Id = "otros-otrosproc-recalcvacas", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcVacas" },
                                        new MenuOption { Id = "otros-otrosproc-recalcmesanho", Name = "Configurar Entrada", Controller = "PayDay", Action = "OtrosRecalcMes" }
                                    }
                                }
                            }
                        },
                        new MenuOption
                        {
                            Id = "pdp",
                            Name = "PayDayPortal",
                            Controller = "PayDay",
                            Action = "PayDayPortal",
                            Description = "Próximamente disponible."
                        },
                        new MenuOption
                        {
                            Id = "ayuda",
                            Name = "Ayuda",
                            Controller = "PayDay",
                            Action = "Ayuda",
                            Description = "Nos brinda información de ayuda sobre PayDay."
                        },
                        new MenuOption
                        {
                            Id = "salir",
                            Name = "Salir",
                            Controller = "PayDay",
                            Action = "Salir",
                            Description = "Es la opción para salir del programa."
                        }
                    }
                }
            };
        }
    }

}