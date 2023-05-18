using Application.Common.Interfaces;
using Application.Libros.Queries.Common;
using Application.Libros.Queries.GetAllLibros;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class GetAllLibrosHandler : IRequestHandler<GetAllLibroQuery, PagedList<LibroDto>>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;
        private readonly FiltersOptions _paginationOptions; 

        public GetAllLibrosHandler(IBrowserTravelTestContext browserTravelTestContext, IMapper mapper, IOptions<FiltersOptions> options)
        {
            _browserTravelTestContext = browserTravelTestContext;
            _mapper = mapper;
            _paginationOptions = options.Value;
        }

        public Task<PagedList<LibroDto>> Handle(GetAllLibroQuery request, CancellationToken cancellationToken)
        {
            request.PageNumber = request.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : request.PageNumber;
            request.PageSize = request.PageSize == 0 ? _paginationOptions.DefaultPageSize : request.PageSize;

            IEnumerable<Libro> libros = _browserTravelTestContext.Libros.Include(x => x.IdEditorialNavigation)
                                                 .Include(x => x.autorLibro)
                                                 .ThenInclude(x => x.Autor)
                                                 .AsQueryable();

            if (request.Titulo != null)
                libros = libros.Where(x => x.Titulo == request.Titulo);

            if (request.IdEditorial != null)
                libros = libros.Where(x => x.IdEditorial == request.IdEditorial);

            if (request.NPaginas != null)
                libros = libros.Where(x => x.NPaginas == request.NPaginas);


            IEnumerable<LibroDto> librosDto = _mapper.Map<IEnumerable<LibroDto>>(libros);

            PagedList<LibroDto> pagedLibro = PagedList<LibroDto>.Create(librosDto, request.PageNumber, request.PageSize);

            return Task.FromResult(pagedLibro);
        }
    }
}
