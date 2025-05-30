using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRentAppShared.Models
{
    public class Usuario
    {
        [Key]
        public string? UsuarioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Apellido { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Contraseña { get; set; }
    }
}