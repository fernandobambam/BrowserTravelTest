using MediatR;

namespace Application.Libros.Commands.AddAutorLibro
{
    public class AddAutorLibroCommand : IRequest<Unit>
    {
        public int LibroId { get; set; }

        public int[] AutorIds { get; set; } 
    }
}
