using Application.Libros.Queries.Common;
using MediatR;

namespace Application.Libros.Queries.GetLibroById
{
    public class GetLibroByIdQuery : IRequest<LibroDto>
    {
        public int Id { get; set; }
    }
}
