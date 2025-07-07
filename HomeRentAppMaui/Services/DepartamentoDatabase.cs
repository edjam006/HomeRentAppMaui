using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeRentAppShared.Models;
using SQLite;


namespace HomeRentAppMaui.Services
{
    public class DepartamentoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public DepartamentoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Departamento>().Wait();
        }

        public Task<List<Departamento>> GetDepartamentosAsync() =>
            _database.Table<Departamento>().ToListAsync();

        public Task<int> SaveDepartamentoAsync(Departamento departamento) =>
            _database.InsertAsync(departamento);
    }
}
