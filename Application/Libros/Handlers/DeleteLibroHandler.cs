using Application.Common.Interfaces;
using Application.Libros.Commands.DeleteLibro;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class DeleteLibroHandler : IRequestHandler<DeleteLibroCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public DeleteLibroHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
        {
            Libro libro = await _browserTravelTestContext.Libros.FindAsync(request.Id);

            if (libro == null)
                throw new NotFoundException("No se encontró libro con ese Id");

            _browserTravelTestContext.Libros.Remove(libro);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
