using Application.Libros.Queries.Common;
using Domain.Common;
using MediatR;

namespace Application.Libros.Queries.GetAllLibros
{
    public class GetAllLibroQuery : IRequest<PagedList<LibroDto>>
    {
        public string Titulo { get; set; }
        public int? IdEditorial { get; set; }
        public string NPaginas { get; set; }
        public int? IdAutor { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
