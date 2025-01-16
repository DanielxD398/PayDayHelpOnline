using PayDayHelpOnline.Models;

namespace PayDayHelpOnline.Models
{

    public class MainMenu
    {
        public MenuModel Menu { get; set; } = new MenuModel();
    }

    public class MenuModel
    {
        // Lista que contiene las opciones de primer nivel
        public List<MenuOption> MenuOptions { get; set; }
    }

    public class MenuOption
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public List<MenuOption> SubOptions { get; set; } // Submenús de la opción actual
    }

}