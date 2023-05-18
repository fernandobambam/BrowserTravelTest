using Application.Common.Interfaces;
using Application.Libros.Commands.CreateLibro;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class CreateLibroHandler : IRequestHandler<CreateLibroCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public CreateLibroHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            Libro libro = new Libro
            {
                Titulo = request.Titulo,
                Sinopsis = request.Sinopsis,
                NPaginas = request.NPaginas,
                IdEditorial = request.IdEditorial,
            };

            await _browserTravelTestContext.Libros.AddAsync(libro);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
