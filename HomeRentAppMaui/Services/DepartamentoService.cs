using HomeRentAppShared.Models;
using System.Net.Http.Json;

namespace HomeRentAppMaui.Services
{
    public class DepartamentoService
    {
        private readonly HttpClient _httpClient;

        public DepartamentoService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5026") 
            };
        }

        public async Task<List<Departamento>> ObtenerDepartamentosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Departamento>>("/api/departamento")
                ?? new List<Departamento>(); //Aqui se retorna una lista vacia en caso de ser null
        }

    }
}
