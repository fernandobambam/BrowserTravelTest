using Application.Common.Interfaces;
using Application.Libros.Commands.RemoveAutorLibro;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class RemoveAutorLibroHandler : IRequestHandler<RemoveAutorLibroCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public RemoveAutorLibroHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(RemoveAutorLibroCommand request, CancellationToken cancellationToken)
        {
            Libro libro = _browserTravelTestContext.Libros.Include(x => x.autorLibro).Where(x => x.Id == request.LibroId).FirstOrDefault();

            if (libro == null)
                throw new NotFoundException("No se encontró el libro con ese Id");

            Autor autor = _browserTravelTestContext.Autors.Where(x => x.Id == request.AutorId).FirstOrDefault();

            if (autor == null)
                throw new NotFoundException("No se encontró el libro con ese Id");


            AutorLibro autorLibro = _browserTravelTestContext.AutorLibros.Where(x =>x.LibroId == request.LibroId && x.AutorId == request.AutorId)
                                                .FirstOrDefault(); 

            if (autorLibro == null)
                throw new NotFoundException("No existe tal relación");


            _browserTravelTestContext.AutorLibros.Remove(autorLibro);

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
