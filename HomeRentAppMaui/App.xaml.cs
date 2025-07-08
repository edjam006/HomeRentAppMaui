using HomeRentAppMaui.Services;
using HomeRentAppShared.Models;

namespace HomeRentAppMaui
{
    public partial class App : Application
    {
        public static DepartamentoDatabase DepartamentoDB { get; private set; }
        public static UsuarioDatabase UsuarioDB { get; private set; }
        public App()
        {
            InitializeComponent();

            string userPath = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db3");
            UsuarioDB = new UsuarioDatabase(userPath);


            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "departamentos.db3");
            DepartamentoDB = new DepartamentoDatabase(dbPath);


            MainPage = new AppShell();
        }
    }
}
