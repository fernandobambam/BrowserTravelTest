using Application.Autores.Queries.Common;
using Application.Autores.Queries.GetAutorById;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Autores.Handlers
{
    public class GetAutoresByIdHandler : IRequestHandler<GetAutorByIdQuery, AutorDto>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;

        public GetAutoresByIdHandler(IBrowserTravelTestContext browserTravelTestContext, IMapper mapper)
        {
            _browserTravelTestContext = browserTravelTestContext;
            _mapper = mapper;
        }

        public Task<AutorDto> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            Autor autor = _browserTravelTestContext.Autors
                .Where(x => x.Id == request.Id).FirstOrDefault();

            if (autor == null)
                throw new NotFoundException("No se encontró autor con ese Id");

            AutorDto autorDto = _mapper.Map<AutorDto>(autor);

            return Task.FromResult(autorDto);
        }
    }
}
