using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class PrestamoView
    {
        public string NombreEstudiante { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string NombreAutor { get; set; } = null!;
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public bool? Devuelto { get; set; }
    }
}
