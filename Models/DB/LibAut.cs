using System;
using System.Collections.Generic;

namespace App_Libreria.Models.DB
{
    public partial class LibAut
    {
        public int IdLibAut { get; set; }
        public int? IdAutor { get; set; }
        public int? IdLibro { get; set; }

        public virtual Autor? IdAutorNavigation { get; set; }
        public virtual Libro? IdLibroNavigation { get; set; }
    }
}
