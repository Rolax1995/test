using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int? IdLector { get; set; }
        public int? IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public bool? Devuelto { get; set; }

        public virtual Estudiante? IdLectorNavigation { get; set; }
        public virtual Libro? IdLibroNavigation { get; set; }
    }
}
