using Application.Common.Interfaces;
using Application.Editoriales.Commands.UpdateEditorial;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Editoriales.Handlers
{
    public class UpdateEditorialHandler : IRequestHandler<UpdateEditorialCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public UpdateEditorialHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(UpdateEditorialCommand request, CancellationToken cancellationToken)
        {
            Editorial editorial = _browserTravelTestContext.Editorials.Where(x => x.Id == request.Id).FirstOrDefault();

            if (editorial == null)
                throw new NotFoundException("No se encontró editoral con ese Id");

            editorial.Nombre = request.Nombre;
            editorial.Sede = request.Sede;

            _browserTravelTestContext.Editorials.Update(editorial);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
