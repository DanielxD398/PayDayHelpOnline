namespace PayDayHelpOnline.Models
{
    public class MenuOption
    {
        public string Name { get; set; } // Nombre de la opción principal
        public string Controller { get; set; } // Controlador asociado
        public string Action { get; set; } // Acción asociada
        public List<SubOption> SubOptions1 { get; set; } // Sub-opciones asociadas
        public List<SubOption> SubOptions2 { get; set; } // Sub-opciones asociadas
    }

    public class SubOption
    {
        public string Name { get; set; } // Nombre de la sub-opción
        public string Action { get; set; } // Acción asociada
        public string Description { get; set; } // Descripción o tooltip (opcional)
    }

}
