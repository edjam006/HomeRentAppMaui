using HomeRentAppMaui.Services;
using HomeRentAppShared.Models;

namespace HomeRentAppMaui
{
    public partial class App : Application
    {
        public static DepartamentoDatabase DepartamentoDB { get; private set; }
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "departamentos.db3");
            DepartamentoDB = new DepartamentoDatabase(dbPath);
            MainPage = new AppShell();
        }
    }
}
