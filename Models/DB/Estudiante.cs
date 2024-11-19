using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdEstudiante { get; set; }
        public string Ci { get; set; } = null!;
        public string NombreEstudiante { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Carrera { get; set; } = null!;
        public int? Edad { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
