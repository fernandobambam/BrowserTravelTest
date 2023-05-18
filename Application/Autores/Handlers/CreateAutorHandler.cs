using Application.Autores.Commands.CreateAutor;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Autores.Handlers
{
    public class CreateAutorHandler : IRequestHandler<CreateAutorCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public CreateAutorHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            Autor autor = new Autor
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos
            };

            await _browserTravelTestContext.Autors.AddAsync(autor);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
