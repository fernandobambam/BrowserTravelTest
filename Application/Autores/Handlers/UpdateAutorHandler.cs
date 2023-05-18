using Application.Autores.Commands.UpdateAutor;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Autores.Handlers
{
    public class UpdateAutorHandler : IRequestHandler<UpdateAutorCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public UpdateAutorHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext;
        }

        public async Task<Unit> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            Autor autor = _browserTravelTestContext.Autors.Where(x => x.Id == request.Id).FirstOrDefault();

            if (autor == null)
                throw new NotFoundException("No se encontró autor con ese Id"); 

            autor.Nombre = request.Nombre;
            autor.Apellidos = request.Apellidos; 
            
            _browserTravelTestContext.Autors.Update(autor);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;  
        }
    }
}
