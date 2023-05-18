using System.Collections.Generic;

namespace Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public ICollection<AutorLibro> autorLibro { get; set; } = new List<AutorLibro>();
    }
}
