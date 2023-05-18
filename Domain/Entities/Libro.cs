using System.Collections.Generic;

namespace Domain.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? IdEditorial { get; set; }

        public virtual Editorial IdEditorialNavigation { get; set; }

        public ICollection<AutorLibro> autorLibro { get; set; } = new List<AutorLibro>();
    }
}
