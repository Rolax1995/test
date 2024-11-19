using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class Autor
    {
        public Autor()
        {
            LibAuts = new HashSet<LibAut>();
        }

        public int IdAutor { get; set; }
        public string NombreAutor { get; set; } = null!;
        public string Nacionalidad { get; set; } = null!;

        public virtual ICollection<LibAut> LibAuts { get; set; }
    }
}
