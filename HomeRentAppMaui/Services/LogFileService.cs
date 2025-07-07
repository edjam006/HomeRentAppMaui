using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRentAppMaui.Services
{
    public static class LogFileService
    {
        private static readonly string logFilePath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Andrade.txt");

        public static async Task AppendLogAsync(string nombreDepartamento)
        {
            string mensaje = $"Se incluyó el registro [{nombreDepartamento}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            using var writer = File.AppendText(logFilePath);
            await writer.WriteLineAsync(mensaje);
        }

        public static async Task<string> LeerLogsAsync()
        {
            if (!File.Exists(logFilePath))
                return "No hay logs.";

            return await File.ReadAllTextAsync(logFilePath);
        }
    }
}
