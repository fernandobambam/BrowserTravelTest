using Application.Common.Interfaces;
using Application.Libros.Commands.UpdateLibro;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class UpdateLibroHandler : IRequestHandler<UpdateLibroCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public UpdateLibroHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
        {
            Libro libro = _browserTravelTestContext.Libros.Where(x => x.Id == request.Id).FirstOrDefault();

            if (libro == null)
                throw new NotFoundException("No se encontró libro con ese Id");

            libro.Titulo = request.Titulo;
            libro.Sinopsis = request.Sinopsis;
            libro.NPaginas = request.NPaginas;
            libro.IdEditorial = request.IdEditorial;

            _browserTravelTestContext.Libros.Update(libro);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
