using Application.Common.Interfaces;
using Application.Libros.Commands.AddAutorLibro;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Libros.Handlers
{
    public class AddAutorLibroHandler : IRequestHandler<AddAutorLibroCommand, Unit>
    {
        private readonly IBrowserTravelTestContext _browserTravelTestContext;

        public AddAutorLibroHandler(IBrowserTravelTestContext browserTravelTestContext)
        {
            _browserTravelTestContext = browserTravelTestContext; 
        }

        public async Task<Unit> Handle(AddAutorLibroCommand request, CancellationToken cancellationToken)
        {
            Libro libro = _browserTravelTestContext.Libros.Where(x => x.Id == request.LibroId).FirstOrDefault();

            if (libro == null)
                throw new NotFoundException("No se encontró el libro con ese Id");

            List<int> autorIdExist = _browserTravelTestContext.Autors
                        .Where(x => request.AutorIds.Contains(x.Id))
                        .Select(x => x.Id)
                        .ToList();

            if (autorIdExist == null && !autorIdExist.Any())
                throw new NotFoundException("No existe ningun autor con ese Id");

            foreach(int id in autorIdExist)
            {
                libro.autorLibro.Add(new AutorLibro()
                {
                    AutorId = id,
                    LibroId = libro.Id,
                }); 
            }

            await _browserTravelTestContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
