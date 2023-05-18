using Application.Autores.Queries.Common;
using MediatR;

namespace Application.Autores.Queries.GetAutorById
{
    public class GetAutorByIdQuery : IRequest<AutorDto>
    {
        public int Id { get; set; }
    }
}
