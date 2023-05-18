using Application.Libros.Queries.Common;
using System.Collections.Generic;

namespace Application.Autores.Queries.Common
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
