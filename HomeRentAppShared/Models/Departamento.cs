using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRentAppShared.Models
{
    //Esta libreria de clases se uso con el objetivo de poder reutilizar las clases tanto en el backend de las Apis como en el frotn Maui, y no estar duplicando los modelos por ejemplo en cada proyecto
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Required]
        public string Imagen { get; set; } = string.Empty;

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;


        [Required]
        [Precision(18, 2)]
        public decimal Precio { get; set; }


        [Required]
        public int CuartosDisponibles { get; set; }

        public string UsuarioId { get; set; } = string.Empty;
    }
}
