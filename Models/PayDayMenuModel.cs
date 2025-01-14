namespace PayDayHelpOnline.Models
{
    public class MenuOption
    {
        public string Name { get; set; } // Nombre de la opci�n principal
        public string Controller { get; set; } // Controlador asociado
        public string Action { get; set; } // Acci�n asociada
        public List<SubOption> SubOptions1 { get; set; } // Sub-opciones asociadas
        public List<SubOption> SubOptions2 { get; set; } // Sub-opciones asociadas
    }

    public class SubOption
    {
        public string Name { get; set; } // Nombre de la sub-opci�n
        public string Action { get; set; } // Acci�n asociada
        public string Description { get; set; } // Descripci�n o tooltip (opcional)
    }

}
