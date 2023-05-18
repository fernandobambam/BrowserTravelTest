using System.Collections.Generic;

namespace Domain.Entities
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
