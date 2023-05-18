using Application.Common.Interfaces;
using Application.Editoriales.Commands.DeleteEditorial;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Editoriales.Handlers
{
    public class DeleteEditorialHandler : IRequestHandler<DeleteEditorialCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public DeleteEditorialHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(DeleteEditorialCommand request, CancellationToken cancellationToken)
        {
            Editorial editorial = await _browserTravelTestContext.Editorials.FindAsync(request.Id);

            if (editorial == null)
                throw new NotFoundException("No se encontró editoral con ese Id");

            _browserTravelTestContext.Editorials.Remove(editorial);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
