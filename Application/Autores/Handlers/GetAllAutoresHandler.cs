using Application.Autores.Queries.Common;
using Application.Autores.Queries.GetAllAutores;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Autores.Handlers
{
    public class GetAllAutoresHandler : IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorDto>>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;

        public GetAllAutoresHandler(IBrowserTravelTestContext browserTravelTestContext, IMapper mapper)
        {
            _browserTravelTestContext = browserTravelTestContext;
            _mapper = mapper;
        }


        Task<IEnumerable<AutorDto>> IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorDto>>.Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Autor> autores = _browserTravelTestContext.Autors.AsEnumerable();    

            IEnumerable<AutorDto> autoresDto = _mapper.Map<IEnumerable<AutorDto>>(autores.ToList());

            return Task.FromResult(autoresDto);
        }
    }
}
