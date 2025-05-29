using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeRentAppShared.Models;
using System.Net.Http.Json;

namespace HomeRentAppMaui.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5026") 
            };
        }

        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Usuarios", usuario);
            return response.IsSuccessStatusCode;
        }
        public async Task<Usuario?> IniciarSesionAsync(string usuarioId, string contrasena)
        {
            var loginData = new
            {
                UsuarioId = usuarioId,
                Contrasena = contrasena
            };

            var response = await _httpClient.PostAsJsonAsync("/api/usuarios/login", loginData);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }



    }
}
