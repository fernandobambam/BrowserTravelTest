using MediatR;

namespace Application.Libros.Commands.RemoveAutorLibro
{
    public class RemoveAutorLibroCommand : IRequest<Unit>
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }
    }
}
