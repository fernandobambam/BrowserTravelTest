using Application.Common.Interfaces;
using Application.Editoriales.Queries.Common;
using Application.Editoriales.Queries.GetEdtiroialById;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Editoriales.Handlers
{
    public class GetEditorialByIdHandler : IRequestHandler<GetEditorialByIdQuery, EditorialDto>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;

        public GetEditorialByIdHandler(IBrowserTravelTestContext browserTravelTestContext, IMapper mapper)
        {
            _browserTravelTestContext = browserTravelTestContext;
            _mapper = mapper;
        }

        public Task<EditorialDto> Handle(GetEditorialByIdQuery request, CancellationToken cancellationToken)
        {
            Editorial editorial = _browserTravelTestContext.Editorials.Where(x => x.Id == request.Id).FirstOrDefault();

            if (editorial == null)
                throw new NotFoundException("No se encontró editoral con ese Id");

            EditorialDto editorialDto = _mapper.Map<EditorialDto>(editorial);

            return Task.FromResult(editorialDto);
        }
    }
}
