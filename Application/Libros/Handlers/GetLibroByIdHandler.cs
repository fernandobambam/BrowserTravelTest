using Application.Common.Interfaces;
using Application.Libros.Queries.Common;
using Application.Libros.Queries.GetLibroById;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class GetLibroByIdHandler : IRequestHandler<GetLibroByIdQuery, LibroDto>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;

        public GetLibroByIdHandler(IBrowserTravelTestContext browserTravelTest, IMapper mapper)
        {
            _browserTravelTestContext = browserTravelTest; 
            _mapper = mapper;   
        }

        public Task<LibroDto> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
        {
            Libro libro = _browserTravelTestContext.Libros.Include(x => x.IdEditorialNavigation)
                                                            .Include(x => x.autorLibro)
                                                            .ThenInclude(x => x.Autor)
                                                            .Where(x => x.Id == request.Id).FirstOrDefault();

            if (libro == null)
                throw new NotFoundException("No se encontró libro con ese Id");

            LibroDto libroDto = _mapper.Map<LibroDto>(libro);

            return Task.FromResult(libroDto); 
        }
    }
}
