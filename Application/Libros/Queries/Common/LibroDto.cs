using Application.Autores.Queries.Common;
using Application.Editoriales.Queries.Common;
using System.Collections.Generic;

namespace Application.Libros.Queries.Common
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public EditorialDto Editorial { get; set; }
        public ICollection<AutorDto> Autores { get; set; }
    }
}
