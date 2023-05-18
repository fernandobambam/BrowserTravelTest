using Application.Autores.Commands.DeleteAutor;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Autores.Handlers
{
    public class DeleteAutorHandler : IRequestHandler<DeleteAutorCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public DeleteAutorHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext;
        }

        public async Task<Unit> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            Autor autor = await _browserTravelTestContext.Autors.FindAsync(request.Id);

            if (autor == null)
                throw new NotFoundException("No se encontró autor con ese Id");

            _browserTravelTestContext.Autors.Remove(autor);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
