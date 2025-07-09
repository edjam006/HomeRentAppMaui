using HomeRentAppShared.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeRentAppMaui.Services
{
    public class UsuarioDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public UsuarioDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> SaveUsuarioAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<Usuario?> GetUsuarioPorIdAsync(string id) =>
            _database.Table<Usuario>().FirstOrDefaultAsync(u => u.UsuarioId == id);


        public Task<Usuario?> ValidarLoginAsync(string id, string contrasena)
        {
            return _database.Table<Usuario>()
                .Where(u => u.UsuarioId == id && u.Contrasena == contrasena)
                .FirstOrDefaultAsync();
        }


        public Task<List<Usuario>> GetUsuariosAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

    }
}
