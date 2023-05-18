using Application.Common.Interfaces;
using Application.Editoriales.Queries.Common;
using Application.Editoriales.Queries.GetAllEditoriales;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Editoriales.Handlers
{
    public class GetAllEditorialesHandler : IRequestHandler<GetAllEditorialesQuery, IEnumerable<EditorialDto>>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;
        private readonly IMapper _mapper;

        public GetAllEditorialesHandler(IBrowserTravelTestContext browserTravelTestContext, IMapper mapper)
        {
            _browserTravelTestContext = browserTravelTestContext;  
            _mapper = mapper;
        }

        public Task<IEnumerable<EditorialDto>> Handle(GetAllEditorialesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Editorial> editoriales = _browserTravelTestContext.Editorials.AsEnumerable();

            IEnumerable<EditorialDto> editorialesDto = _mapper.Map<IEnumerable<EditorialDto>>(editoriales.ToList());

            return Task.FromResult(editorialesDto);
        }
    }
}
