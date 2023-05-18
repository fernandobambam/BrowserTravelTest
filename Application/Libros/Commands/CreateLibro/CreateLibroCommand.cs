using MediatR;

namespace Application.Libros.Commands.CreateLibro
{
    public class CreateLibroCommand : IRequest<Unit>
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? IdEditorial { get; set; }
    }
}
