using Application.Common.Interfaces;
using Application.Editoriales.Commands.CreateEditorial;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Editoriales.Handlers
{
    public class CreateEditorialHandler : IRequestHandler<CreateEditorialCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public CreateEditorialHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
        {
            Editorial editorial = new Editorial
            {
                Nombre = request.Nombre,
                Sede = request.Sede
            };

            await _browserTravelTestContext.Editorials.AddAsync(editorial);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }  
    }
}
