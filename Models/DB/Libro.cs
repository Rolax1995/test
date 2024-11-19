using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class Libro
    {
        public Libro()
        {
            LibAuts = new HashSet<LibAut>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string? Area { get; set; }

        public virtual ICollection<LibAut> LibAuts { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
