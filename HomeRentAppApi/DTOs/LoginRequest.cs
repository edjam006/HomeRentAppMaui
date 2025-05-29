using HomeRentAppShared.Models;

namespace HomeRentAppApi.DTOs
{
    public class LoginRequest
    {
        public string? UsuarioId { get; set; }
        public string? Contrasena { get; set; }
    }
}
