using Application.Autores.Queries.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Autores.Queries.GetAllAutores
{
    public class GetAllAutoresQuery : IRequest<IEnumerable<AutorDto>>
    {
    }
}
