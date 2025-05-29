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
                BaseAddress = new Uri("https://localhost:7003") 
            };
        }

        public async Task<List<Departamento>> ObtenerDepartamentosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Departamento>>("/api/departamento")
                ?? new List<Departamento>(); //Aqui se retorna una lista vacia en caso de ser null
        }
        public async Task<bool> CrearDepartamentoAsync(Departamento nuevo)
        {
            nuevo.Imagen ??= "dGVzdA==";
            nuevo.UsuarioId ??= Preferences.Get("UsuarioId", string.Empty);

            var response = await _httpClient.PostAsJsonAsync("/api/departamento", nuevo);
            return response.IsSuccessStatusCode;
        }


    }
}
