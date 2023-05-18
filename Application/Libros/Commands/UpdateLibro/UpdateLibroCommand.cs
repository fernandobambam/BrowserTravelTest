using MediatR;

namespace Application.Libros.Commands.UpdateLibro
{
    public class UpdateLibroCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? IdEditorial { get; set; }
    }
}
