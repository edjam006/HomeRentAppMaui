using System.Text;

namespace HomeRentAppMaui.Helpers
{
    public static class FileLoggerService
    {
        private static string fileName = $"Logs_Andrade.txt"; // Cambia "Andrade" por tu apellido

        public static async Task AppendLogAsync(string nombre)
        {
            string mensaje = $"Se incluyó el registro [{nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            string path = Path.Combine(FileSystem.AppDataDirectory, fileName);
            await File.AppendAllTextAsync(path, mensaje, Encoding.UTF8);
        }
    }
}
